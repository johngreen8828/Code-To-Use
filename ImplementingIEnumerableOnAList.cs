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
   
    class Student
    {
        public int Id { get; set; }

       // public int CompareTo(Student other)
       // {
       //     return this.Id.CompareTo(other.Id);
       // }
      // public override string ToString()
      // {
      //     return Id.ToString();
      // }
    }

    class ClassRoom :IEnumerable<Student>
    {
        public Student[] students;
        public ClassRoom()
        {
           // List<Student> students = new List<Student>();
           // students.Add(new Student() { Id = 5 });
           // students.Add(new Student() { Id = 4 });
           // students.Add(new Student() { Id = 3 });

            students = new Student[3];
            students[0] = new Student() { Id = 2 };
            students[1] = new Student() { Id = 1 };
            students[2] = new Student() { Id = 3 };
        }

        //Generic GetEnumerator implemented by cntrl .
        public IEnumerator<Student> GetEnumerator()
        {
            for (int i = 0; i < students.Length; i++)
            {
                yield return students[i];
            }
        }

        //Non Generic GetEnumerator implemented by cntrl .
        IEnumerator IEnumerable.GetEnumerator()
        {
            //Calls the Genric GetEnumerator above
            return GetEnumerator();
        }
    }

    static void Main()
    {
        ClassRoom c = new ClassRoom();
      

        foreach (var item in c)
        {
            Console.WriteLine(item);
        }
    }
}