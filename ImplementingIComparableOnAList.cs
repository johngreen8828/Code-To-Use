using System;
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


public class Program
{
   
    class Student :IComparable<Student>
    {
        public int Id { get; set; }

        public int CompareTo(Student other)
        {
            return this.Id.CompareTo(other.Id);
        }
    }
    static void Main()
    {
        List<Student> students = new List<Student>();
        students.Add(new Student() { Id = 5 });
        students.Add(new Student() { Id = 4 });
        students.Add(new Student() { Id = 3 });

        students.Sort();

        foreach (var item in students)
        {
            Console.WriteLine(item.Id);
        }
    }
}