using System;
using System.Runtime.Serialization;
using System.IO;
using System.Xml;
using System.Text;
using System.Xml.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;

class Program
{
    public static void AddNumbers(int fn, int ln)
    {
        Console.WriteLine(fn + ln);
    }

    static void AddNumbers(int fn, int ln, int[] restOfNumbers)
    {
        int result = fn + ln;
        foreach ( int i in restOfNumbers)
        {
            result += i;
        }
        Console.WriteLine(result);
    }

    static void AddNumbers( int fn, int ln, params object[] restOfNumbers)
    {
        double result = fn + ln;
        foreach (object i in restOfNumbers)
        {
            result += Convert.ToInt32(i);
            Console.WriteLine(result);
        }
       
    }
    static void Main()
    {
        AddNumbers(5, 8, .8, .5, .5 );
    }
   
}