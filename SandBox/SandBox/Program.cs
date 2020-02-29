#define DEBUG
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
using System.Collections.Concurrent;
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
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Xml;


namespace SandBox
{
    public class Program :Attribute
    {
        public class Animal : IDisposable
        {
            public void Dispose()
            {
                Console.WriteLine("Dispose Called");
            }
                public void WriteAnimal()
            {
                Console.WriteLine("Animal");
            }
            public void LoveAnimal()
            {
                Console.WriteLine("Animal");
            }

            public IEnumerator GetEnumerator()
            {
                throw new NotImplementedException();
            }
        }
        public class Dog : Animal
        {
            public void Bark()
            {
                Console.WriteLine("Woof");
            }
        }
        static void Main()
        {
            int sum=0;
            int chk = 0;
            int[] intArray = new int[] { 1, 2, 3, 4, 5 };
            for (int i = 0; i < intArray.Length; i++)
            {
                
                
                sum = intArray[i];
                
                intArray[i] = sum * sum ;

                
            }

            foreach (int item in intArray)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
            

           
        }
  
    }

}