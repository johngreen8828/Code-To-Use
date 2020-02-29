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
using System.ServiceModel;


//THis is a WCF application that uses attributes to identify the contracts for hosting the class and method so that a listener can access them
class Program
{
    [ServiceContract] //Uses SOA 
    interface ICow
    {
        [OperationContract]
        void Moo();
    }

    class MeCow : ICow
    {
        public void Moo()
        {
            Console.WriteLine("Mooooo");
        }
    }
    static void Main()
    {
        var host = new ServiceHost(typeof(MeCow));
        host.AddServiceEndpoint(typeof(ICow), new WSHttpBinding(), "http://localhost:1234");
        host.Open();

        var cow = ChannelFactory<ICow>.CreateChannel(new WSHttpBinding(), new EndpointAddress("http://localhost:1234"));
    }
}