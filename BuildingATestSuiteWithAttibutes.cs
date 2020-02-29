using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Reflection;
using System.Linq;




//class TestAttribute : Attribute { }
//class TestMethodAttribute : Attribute { }

//[TestAttribute] //This is an Attribute also called decorating
//class MyTestSuite
//{
//    public void HelperMethod()
//    {
//        //Helps the test
//    }

//    [TestMethod]
//    public void MyTest1()
//    {
//        Console.WriteLine("Doing some testing...");
//    }

//    [TestMethod]
//    public void MyTestMethod2()
//    {
//        Console.WriteLine("Doing some other testing...");
//    }
//}

//class MainClass
//{
//    public static void Main()
//    {
//        var testSuites =
//            from t in Assembly.GetExecutingAssembly().GetTypes()
//            where t.GetCustomAttributes(false).Any(a => a is TestAttribute)
//            select t;

//        foreach (Type t in testSuites)
//        {
//            Console.WriteLine("Running tests in suite: " + t.Name);
//            var TestMethods =
//                from m in t.GetMethods()
//                where m.GetCustomAttributes(false).Any(a => a is TestMethodAttribute)
//                select m;

//            object testSuiteInstance = Activator.CreateInstance(t);
//            foreach (MethodInfo mInfo in TestMethods)
//            {
//                mInfo.Invoke(testSuiteInstance, new object[0]);
//            }
//        }
//    }

//}