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
//using System.Linq;  Commenting this out drives home the fact that we are using the static extension methods created here 
using System.Data;

static class Program
{
    //This where will run all the items through the predicate...if true the item passed through the predicate delegate, then yield that item
    //      <Return Type> <param Type>           <Type for items>    <Type for items, Return Type for predicate>

    static IEnumerable<T> Where<T>(this IEnumerable<T> items, Func<T, bool> predicate /*i < 5 for this example*/)
    {
        foreach (T item in items) //items is the returned subset of the stuff from select
        {
            Console.WriteLine("Where");
            if (predicate/*i < 5 for this example*/(item))
            {
                yield return item; //In method body yield will result in Compiler translate it into a class and returns instance of that class
            }                      //Also yield will yield the item back to select  
        }
    }
   
    //This Select does not pass each item through the precicate.  Instead we pass each item through a transform delegate
    //      <Return Type> <param Type>           <Type for items>    <Type for items, Return Type for Transform>    

    static IEnumerable<R> Select<T, R>(this IEnumerable<T> items, Func<T, R> transform/*i + 6 for this example*/)
    {
        Console.WriteLine("Select");
        foreach (T item in items) //items is the stuff
        {
            yield return transform/*i + 6 for this example*/(item); //Yields the data back to result and then continues until there is no more datas
        }
    }

    static void Main()
    {
        //Note that if there was no foreach loop or other mechanism to consume the data the output would be nothing.  You need to act on the result assignment
        //for the where and select to be invoked.  Idea is that we don't get data unitl we ask for it.
        int[] stuff = { 1, 2, 4, 6, 7, };
        var result =
            from i in stuff
            where i < 5     //Where and select here will resolve to the extension methods we created here.
            select i + 6;   //Added 6 so it is not a degenerative clause.  Compiler will remove a degenerative clause. eg n => n.  Nothing here
        //output should be 7, 8, 10
        foreach (var item in result)    //This line is consuming the data with the yield classes above. It defers execution until you need it.
        {
            Console.WriteLine(item.ToString());
        }
        //Same code as above only using IEnumerator<int> for the Type
        int[] stufff = { 1, 2, 4, 6, 7, };
        IEnumerable<int> resultt =
            from ii in stufff
            where ii < 5     
            select ii + 6;
        //output should be 7, 8, 10
        IEnumerator<int> rator = result.GetEnumerator();
        while (rator.MoveNext())  //MoveNext is consuming the data with the yield classes above. It defers execution until you need it.
        {
            Console.WriteLine(rator.Current);
        }

        //THis is the translation from the above code
        int[] stuffff = { 1, 2, 4, 6, 7, };
        IEnumerable<int> resulttt =
            //stuff will send its items to where then select will transform the numbers.  Really what happens in order is that select will ask
            //for data from stuff and where will ask for data from select and then pass it to resulttt
            stuffff.Where(i => i < 5).Select(i => i + 6);

        //THis line above can also be written like this...So result is equal to whatever the select returns
        IEnumerable<int> result1 = Select(Where(stufff, i => i < 5), i => i + 6);
        
        //output should be 7, 8, 10
        IEnumerator<int> ratorr = result.GetEnumerator();
        while (rator.MoveNext())  //MoveNext is consuming the data with the yield classes above. It defers execution until you need it.
        {
            Console.WriteLine(rator.Current);
        }
    }
}