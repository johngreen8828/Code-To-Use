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

    class Goo
    {
        public static void Print<T>(List<T> printData)
        {
            if (printData != null)
            {
                for (int i = 0; i < printData.Count; i++)
                {             
                    Console.WriteLine(printData[i].ToString());
                }
            }
        }
         public static void Print(string printData)
            {
            Console.WriteLine(printData);
            }           
    }


    static void Main()
    {

        List<int> myList = new List<int>();
        //Console.WriteLine(typeof(myArray);
        myList.Add(3244);
        myList.Add(1233);
        Goo.Print(myList.ToList());
        Goo.Print("John Green");
    }


    // class Goo
    // {
    //     public static void Print<T>(params T[] item)
    //     {
    //
    //         if (typeof(T).IsArray)
    //         {
    //             private T[] array;
    //             for (int i = 0; i<item.Length(); i++)
    //                 {
    //                   Console.WriteLine(i);               
    //                 }
    //         }
    //         else  
    //         {
    //             Console.WriteLine(item);
    //         }
    //     }
    // }


}