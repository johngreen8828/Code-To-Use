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
    class Program
    {
         class Person
        {
            //Ah so...This constructor takes in a person object and can be used as the copy constructor
            public Person(Person previousPerson)
                : this(previousPerson.Name, previousPerson.Age)
            {
           //     Name = previousPerson.Name;
           //     Age = previousPerson.Age;
            }
            public Person(string name, int age)
            {
                Name = name;
                Age = age;
            }
            public int Age { get; set; }
            public string Name { get; set; }
            public string Details()
            {
                return Name + " Is " + Age.ToString();
            }
        }
        static void Main()
        {
            Person person1 = new Person("George", 40);
            Person person2 = new Person(person1);
            person1.Age = 54;
            person2.Age = 57;
            person2.Name = "Charles";

            Console.WriteLine(person1.Details());
            Console.WriteLine(person2.Details());
            Console.ReadKey();




        }
    }
}
