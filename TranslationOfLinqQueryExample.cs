using System;
using System.Runtime.Serialization;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Text;
using System.Xml.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;
using System.Linq;
using System.Data;

class Program
{
    static void Main()
    {
        int[] numbers = new int[] { 2, 4, -2, 9, 4, 13, 2 };
        var result =
            from n in numbers
            where n < 5
            where 0 < n  //same as writing where n < 5 && 0 < n
            where  new Random().Next() == 23
            orderby n
            select n;

        //Translation of above code
        var result2 =
            //This is the extension method syntax 
            //from n in numbers just resolves to numbers
            numbers
            .Where(n => n < 5)
            .Where(n => 0 < n)
            .Where(n => new Random().Next() == 23)
            .OrderBy(n => n)
            .Select(n => n);

        //Translation of above code
        var result3 =
            //This is the extension method syntax 
            //from n in numbers just resolves to numbers
            //Extension method is just extending Enumerable, cut, and paste then , to extend each
            
            Enumerable.Select(Enumerable.OrderBy(Enumerable.Where(Enumerable.Where(Enumerable.Where(numbers, n => n < 5), n => 0 < n), n => new Random().Next() == 23), n => n), n => n);

        //Better looking format for above statement
        var result4 =
            Enumerable.Select(
                Enumerable.OrderBy(
                    Enumerable.Where(
                        Enumerable.Where(
                            Enumerable.Where(
                                numbers, n => n < 5), 
                            n => 0 < n), 
                        n => new Random().Next() == 23), 
                    n => n), 
                n => n);

        //
}