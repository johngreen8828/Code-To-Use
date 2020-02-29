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

namespace SandBox
{
    interface IMethodA
    {
        void MthA();
    }
    interface IMethodB
    {
        void MthB();
    }
    class Program
    {//THE BASE CLASS CANNOT ACCESS THE DERIVED CLASS RULE
        class BaseClass
        {
            public virtual void Frog(string m)
            {
                Console.WriteLine("Frog : " + m);
            }
            public void FrogEnd()
            {
                Console.WriteLine("Frog Ended");
            }
        }
        class DerivedClass : BaseClass, IMethodA, IMethodB
        {
            public int MyProperty {  get; private set; }
            
            public override void Frog(string m)
            {
                MyProperty = 2;
                Console.WriteLine(m);
            }
            public new void FrogEnd()
            {
                Console.WriteLine("Derived Done");
            }

            void IMethodA.MthA()
            {
                   
            }

            public void MthB()
            {
                throw new NotImplementedException();
            }
        }
        class Employee
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string ManagerName { get; set; }
            public int ManagerID { get; set; }

            public void a(object obj)
            {
                Console.WriteLine("object a");
            }
            public void a(DerivedClass dc)
            {
                Console.WriteLine("Derived Class dc");
            }
            public void a(BaseClass bc)
            {
                Console.WriteLine("BaseClass bc");
            }
            public void MethodInvoke()
            {
                object obj = new DerivedClass();
                a((BaseClass)obj);
            }
        }
        static void Main()
        {
            Employee emp = new Employee();
            emp.MethodInvoke();
            //create instance of the base class
            var bc = new BaseClass();
            //create instance of the derived class 
            var dc = new DerivedClass();
            var bcdc = new BaseClass();
            //access the virtual frog method in the base class
            bc.Frog("started");
            //access the overriden frog method in the derived class
            //var ac = dc as BaseClass;
            var ac = ((BaseClass)dc);
            bcdc.Frog("dc access");
            //this one is wierd ... it accesses the derived class frog method from the base class cast but goes to the derived method 
            //because of the overriden method.  
            ((BaseClass)dc).Frog("casting to bc");
            //cannot do this access the derived class from a base class instance...runtime error
            //((DerivedClass)bc).Frog("Frog Going");
            //access the base class Frogend from the derived class instance casting to base class
            ((BaseClass)dc).FrogEnd();
            //access to the frogend() in the base class
            bc.FrogEnd();
            //access the frog end in the derived class even though they are both loaded. the base is hidden.
            dc.FrogEnd();


        }
    }

}
       