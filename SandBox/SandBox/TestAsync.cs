using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace SandBox
{
    class TestAsync
    {
        static void Main(string[] args)
        {
            try
            {
                // Start a task - calling an async function in this example
                Task<string> callTask = Task.Run(() => CallHttp());
                // Wait for it to finish
                //callTask.Wait();
                // Get the result
                string astr = callTask.Result;
                // Write it our
                Console.WriteLine(astr);
            }
            catch (Exception ex)  //Exceptions here or in the function will be caught here
            {
                Console.WriteLine("Exception: " + ex.Message);
            }


        }

        // Simple async function returning a string...
        static public async Task<string> CallHttp()
        {
            // Just a demo.  Normally my HttpClient is global (see docs)
            HttpClient aClient = new HttpClient();
            // async function call we want to wait on, so wait
            string astr = await aClient.GetStringAsync("http://microsoftafdf.com");
            // return the value
            return astr;
        }
    }
}
