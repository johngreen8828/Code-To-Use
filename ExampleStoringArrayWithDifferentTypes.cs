using System;
using System.Runtime.Serialization;
using System.IO;
using System.Xml;
using System.Text;
using System.Xml.Linq;
using System.Collections;

public delegate string SampleDelegate();
public class Person
{
    //This is an example of using an array to store different types.  You could also use ArrayList
    //Also makes use of the ToString override method

    static void Main(string[] args)
    {
        object[] array = new object[4];//use object type since object type is the base type for all objects in .net
        array[0] = 1;
        array[1] = "John";

        TempClass tc = new TempClass();
        tc.ClassId = 88;
        tc.ClassFullName = "JimmyJohn";
        TempClass1 tc1 = new TempClass1();
        tc1.ClassId1 = 99;
        tc1.ClassFullName1 = "JoeJoe";
        array[2] = tc;
        array[3] = tc1 ;

        foreach (var item in array)
        {
            Console.WriteLine(item);
        }
    }
   class TempClass
    {
        public int ClassId { get; set; }
        public string ClassFullName { get; set; }

        public override string ToString()
        {
            return $"{ ClassId }\n{ ClassFullName }";
        }
    }

    class TempClass1
    {
        public int ClassId1 { get; set; }
        public string ClassFullName1 { get; set; }

        public override string ToString()
        {
            return $"{ ClassId1 }\n{ ClassFullName1 }";
        }


    }

}