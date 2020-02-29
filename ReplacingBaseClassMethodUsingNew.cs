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
    class Base
    {
        public void Execute()
        {
            Console.WriteLine("Base.Execute");
        }
        public void BaseExecute() { }
    }

    class Derived : Base
    {
        //This replaces the method in the base class by using the new keyword.  No overriding going on just replacing...Dont use this...stupid
        public void Execute()
        {
            Console.WriteLine("Derived.Execute");
        }
    }
    new 
    static void Main()
    {
        Base b = new Base();
        b.Execute();
        //This does not look at the derived function.  The author may have intended for it to do that. It is suppusedly hidden  
        b = new Base();
        b.Execute();
        //Hides the base function from the derived class
        Derived d = new Derived();
        d.Execute();
        
        
    }
}