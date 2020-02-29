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
    abstract class Base
    {
        //This will be inherited even though it is virtual.  I did not override it and was able to call it.
       public virtual void MethodWithImplementation()
        {
            Console.WriteLine("I have implementation");
        }
        //abstract cannot have implementation where it is defined and the class must be abstract if a member is.  Derived must implement it.
        public abstract void AbstractMethod();
        
    }

    class Derived : Base
    {
        //This replaces the method in the base class by using the new keyword.  No overriding going on just replacing...Dont use this...stupid
        public void Execute()
        {
            Console.WriteLine("Derived.Execute");
        }
        //Must override abstrace methods inherited
        public override void AbstractMethod()
        {
            Console.WriteLine("Abstract Implementation");
        }
    }
    new 
    static void Main()
    {
        //Base b = new Base();  Cannot have instance of an abstract class
        Derived d = new Derived();
        d.MethodWithImplementation();
        d.AbstractMethod();

       
        
        
        
    }
}