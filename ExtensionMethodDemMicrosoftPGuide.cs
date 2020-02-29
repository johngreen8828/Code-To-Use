using System;
using System.Runtime.Serialization;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Text;
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


namespace DefineMyInterface
{
    using System;

    //Any class that implements IMyInterface must define a method that matches the following signature
    public interface IMyInterface
    {
        void MethodB();
    }
}

//Define extention methods for IMyInterface
namespace Extensions
{
    using System;
    using DefineMyInterface;

    //The folowing extension methods can be accessed bu instance of any class that implements IMyInterface
    public static class Extension
    {
        public static void MethodA(this IMyInterface myInterface, int i)
        {
            Console.WriteLine("Extension MethodA(this IMyInterface myInterface, int i)");
        }
        public static void MethodA(this IMyInterface myInterface, string s)
        {
            Console.WriteLine("Extension MethodA(this IMyInterface myInterface, string s)");
        }
        //Never gets called in ExtensionMethodsDemo1, b/c each of the three classes A, B, and C implements a method named MethodB
        //that has a matching signature.
        public static void MethodB(this IMyInterface myInterface, int i)
        {
            Console.WriteLine("Extension MethodB(this IMyInterface myInterface, int i)");
        }
    }
}

//Define three class that impement IMyInterface, and the use them to test the extension methods
namespace ExtensionMethodsDemo1
{
    using System;
    using Extensions;
    using DefineMyInterface;

    class A : IMyInterface
    {
        public void MethodB()
        {
            Console.WriteLine("A.MethodB()");
        }
    }

    class B : IMyInterface
    {
        public void MethodB()
        {
            Console.WriteLine("B.MethodB()");
        }
        public void MethodA(int i)
        {
            Console.WriteLine("B.MethodB(int i)");
        }
    }

    class C : IMyInterface
    {
        public void MethodB()
        {
            Console.WriteLine("C.MethodB()");
        }
        public void MethodA(object obj)
        {
            Console.WriteLine("C.MethodA(object obj)");
        }
    }

    class ExtMethodDemo
    {
        static void Main()
        {
            //Dclare an instance of class A, classB, and class C
            A a = new A();
            B b = new B();
            C c = new C();

            //A contains no MethodA so each call to MethodA resolves to the extension method that has a mtatching signature
            a.MethodA(1);
            a.MethodA("Hello");

            //A has a method that matches the signature of the following call to Method B
            a.MethodB();

            //B has methods that match the signatures of the following method calls
            b.MethodA(1);
            b.MethodB();

            //B has no matching method for the following call, but class extension does
            b.MethodA("Hello");

            //C has instance method that matches these method calls
            c.MethodA(1);
            c.MethodA("Hello");
            c.MethodB();
        }
    }
}