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


class TestAttribute : Attribute { }
class TestMethodAttribute : Attribute { }
public class Program 
{
    [Test]
    class MyTestSuite 
    {
        public void HelperMethod()
        {
            //That helps our tests get their job done...
        }

        [TestMethod]
        public void MyTest1()
        {
            HelperMethod();
            Console.WriteLine("Doing some testing...");
        }
        [TestMethod]
        public void MyTestMethod2()
        {
            HelperMethod();
            Console.WriteLine("Doing some other testing...");
        }
    }

    //using reflection 

   static void Main()
    {
        //This one just grabs the testSuites available in teh assembly with Test Attribute
        var testSuites =
             from t in Assembly.GetExecutingAssembly().GetTypes()
             where t.GetCustomAttributes(false).Any(a => a is TestAttribute)
             select t;

        foreach (Type t in testSuites)
        {
            Console.WriteLine("Running tests in suite: " + t.Name);
            //This is reflection at its finest.  It is utilizing types and attributes of the assembly during runtime.
            //Outer loop grabbing the TestMethod Attributes in the testSuite
            var testMethods =
                from m in t.GetMethods()
                where m.GetCustomAttributes(false).Any(a => a is TestMethodAttribute)
                select m;
            //Get an instance of the testMethod at runtime using Activator
            object testSuiteInstance = Activator.CreateInstance(t);
            //Gets all the methods in the testsuites
            foreach (MethodInfo mInfo in testMethods)
            {
                //Invoke each method to test each method in the testSuitInstance
                mInfo.Invoke(testSuiteInstance, new object[0]);
            }
        }

    }
       
}