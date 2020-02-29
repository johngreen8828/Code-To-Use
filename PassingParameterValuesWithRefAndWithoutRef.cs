using System;
using System.Reflection;
using System.Runtime.Serialization;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
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
using System.Data.SqlClient;
using System.Configuration;
using System.ServiceModel;

namespace SandBox
{
    class SwappingStrings
    {
        static string SwapStrings(string s1,  string s2)
        // The string parameter is passed by reference.
        // Any changes on parameters will affect the original variables.
        {
            string temp = s1;
            s1 = s2;
            s2 = temp;
            System.Console.WriteLine("Inside the method: {0} {1}", s1, s2);
            return s2;
        }

        static void Main()
        {
            string str1 = "John";
            string str2 = "Smith";
            System.Console.WriteLine("Inside Main, before swapping: {0} {1}", str1, str2);

            SwapStrings(str1,  str2);   // Passing strings by reference
            System.Console.WriteLine("Inside Main, after swapping: {0} {1}", str1, str2);
        }
    }

    class PassingRefByVal
    {
        static void Change( int[] pArray)
        {
            pArray[0] = 888;  // This change affects the original element.
            //pArray = new int[5] { -3, -1, -2, -3, -4 };   // This change is local.
            System.Console.WriteLine("Inside the method, the first element is: {0}", pArray[0]);
        }

        static void Main()
        {
            int[] arr = { 1, 4, 5 };
            System.Console.WriteLine("Inside Main, before calling the method, the first element is: {0}", arr[0]);

            Change( arr);
            System.Console.WriteLine("Inside Main, after calling the method, the first element is: {0}", arr[0]);
        }
    }
    class PassingRefByRef
    {
        static void Change(ref int[] pArray)
        {
            // Both of the following changes will affect the original variables:
            pArray[0] = 888;
            pArray = new int[5] { -3, -1, -2, -3, -4 };
            System.Console.WriteLine("Inside the method, the first element is: {0}", pArray[0]);
        }

        static void Main()
        {
            int[] arr = { 1, 4, 5 };
            System.Console.WriteLine("Inside Main, before calling the method, the first element is: {0}", arr[0]);

            Change(ref arr);
            System.Console.WriteLine("Inside Main, after calling the method, the first element is: {0}", arr[0]);
        }
    }
    class PassingValByVal
    {
        static void SquareIt( int x)
        // The parameter x is passed by value.
        // Changes to x will not affect the original value of x.
        {
            x *= x;
            System.Console.WriteLine("The value inside the method: {0}", x);
        }
        static void Main()
        {
            int n = 5;
            System.Console.WriteLine("The value before calling the method: {0}", n);

            SquareIt( n);  // Passing the variable by value.
            System.Console.WriteLine("The value after calling the method: {0}", n);

            // Keep the console window open in debug mode.
            System.Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }
    }
    class PassingValByRef
    {
        static void SquareIt(ref int x)
        // The parameter x is passed by reference.
        // Changes to x will affect the original value of x.
        {
            x *= x;
            System.Console.WriteLine("The value inside the method: {0}", x);
        }
        static void Main()
        {
            int n = 5;
            System.Console.WriteLine("The value before calling the method: {0}", n);

            SquareIt(ref n);  // Passing the variable by reference.
            System.Console.WriteLine("The value after calling the method: {0}", n);

            // Keep the console window open in debug mode.
            System.Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }
    }
}
