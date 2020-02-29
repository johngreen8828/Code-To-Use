using System;
using System.Runtime.Serialization;
using System.IO;
using System.Xml;
using System.Text;
using System.Xml.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;

class Program
{
    //Good program example of using a delegate for a callback
    //Set up the Test with Test()
    //Start the test with StartNewTask passing in the pointer called callBack(string) to taskCompletedCallBack
    //taskCompletedCallback calls the TestCallBack function passing in the string
    //TestCallBack writes the string and the flow passes back to main()

    public delegate void TaskCompletedCallBack(string taskResult);

    public class CallBack
    {
        public void StartNewTask(TaskCompletedCallBack taskCompletedCallBack)
        {
            Console.WriteLine("I have stared a new task");
            if (taskCompletedCallBack != null)
            {
                taskCompletedCallBack("I have completed the task");
            }
        }
    }

    public class CallBackTest
    {
        public void Test()
        {
            TaskCompletedCallBack callBack = TestCallBack;
            CallBack testCallBack = new CallBack();
            testCallBack.StartNewTask(callBack);
        }

        public void TestCallBack(string result)
        {
            Console.WriteLine(result);
        }
    }

    static void Main()
    {
        CallBackTest callBackTest = new CallBackTest();
        callBackTest.Test();
        Console.ReadLine();
    }
}