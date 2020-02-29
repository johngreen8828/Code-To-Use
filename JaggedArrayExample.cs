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
    //This is an example of using a jagged array to print out the list of employees and their associated degrees using jagged array

    static void Main(string[] args)
    {
        string[] EmpNames = new string[3];
        EmpNames[0] = "Mark";
        EmpNames[1] = "Matt";
        EmpNames[2] = "John";

        string[][] jaggedArray = new string[3][];

        jaggedArray[0] = new string[3];
        jaggedArray[1] = new string[1];
        jaggedArray[2] = new string[2];

        jaggedArray[0][0] = "Bachelors";
        jaggedArray[0][1] = "Masters";
        jaggedArray[0][2] = "Doctorate";

        jaggedArray[1][0] = "Masters";

        jaggedArray[2][0] = "Bachelors";
        jaggedArray[2][1] = "Masters";

        for (int i = 0; i < jaggedArray.Length; i++)
        {
            string[] innerArray = jaggedArray[i]; //Get First string array and loop through inner array to get values
            Console.WriteLine(EmpNames[i]);
            Console.WriteLine("---------");
            for (int j = 0; j < innerArray.Length; j++)
            {
                Console.WriteLine(innerArray[j]);
                
            }
            Console.WriteLine();//blank row
        }
        
    }
   
}