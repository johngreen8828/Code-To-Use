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

class Program
{
    //delegate void ReadResponse(IAsyncResult ar);
    private const string url = "http://www.cninnovation.com";

    private static void SynchronizedAPI()
    {
        Console.WriteLine(nameof(SynchronizedAPI));
        using (var client = new WebClient())
        {
            string content = client.DownloadString(url);
            Console.WriteLine(content);
        }
        Console.WriteLine();
    }

    private static void AsynchronousPattern()
    {
        Console.WriteLine(nameof(AsynchronousPattern));
        WebRequest request = WebRequest.Create(url);
        IAsyncResult result = request.BeginGetResponse(ReadResponse, null);

        void ReadResponse(IAsyncResult ar)
        {
            using (WebResponse response = request.EndGetResponse(ar))
            {
                Stream stream = response.GetResponseStream();
                var reader = new StreamReader(stream);
                string content = reader.ReadToEnd();
                Console.WriteLine(content);
                Console.WriteLine();
            }
        }
    }

    private static async Task TaskBasedAsyncPatternAsync()
    {
        Console.WriteLine(nameof(TaskBasedAsyncPatternAsync));
        using (var client = new WebClient())
        {
            string content = await client.DownloadStringTaskAsync(url);
            Console.WriteLine(content.Substring(0, 100));
            Console.WriteLine();
        }
    }

    private static void AsynchronizedAPI()
    {
        Console.WriteLine(nameof(AsynchronizedAPI));
        WebRequest request = WebRequest.Create(url);
        IAsyncResult result = request.BeginGetResponse(ReadResponse, null);
        
        void ReadResponse(IAsyncResult ar)
        {

            var response = request.EndGetResponse(ar);

            Stream stream = response.GetResponseStream();
            var reader = new StreamReader(stream);
            string content = reader.ReadToEnd();
            Console.WriteLine(content);
            Console.WriteLine();

        }
        

    }

    private static void EventBasedAsyncPattern(string address)
    {
        Console.WriteLine(nameof(EventBasedAsyncPattern));
        using (var client = new WebClient())
        {
            client.DownloadStringCompleted += (sender, e) =>
            {
                Console.WriteLine(e.Result);
            };
            client.DownloadStringAsync(new Uri(url));
            Console.WriteLine();
        }
    }

    static async Task Main()
    {
        //SynchronizedAPI();
        //AsynchronizedAPI();
        await TaskBasedAsyncPatternAsync();
        //AsynchronousPattern();
        //EventBasedAsyncPattern(url);
        Console.ReadLine();
    }

}

