using System;
using System.Runtime.Serialization;
using System.IO;
using System.Xml;
using System.Text;
using System.Xml.Linq;

[DataContract]
class Person
{
    [DataMember]
    public string FirstName { get; set; }
    [DataMember]
    public string LastName { get; set; }
    [DataMember]
    public int Age { get; set; }

}

class MainClass
{
    static void Main()
    {
        var me = new Person
        { 

            FirstName = "John",
            LastName = "Green",
            Age = 56
            };
        //serialize object back out to Ram.  Not a file or network
        var serializer = new DataContractSerializer(me.GetType());
        var someRam = new MemoryStream();
        serializer.WriteObject(someRam, me);
        someRam.Seek(0, SeekOrigin.Begin);
        Console.WriteLine(
            XElement.Parse(
            Encoding.ASCII.GetString(someRam.GetBuffer()).Replace("\0", "")));


    }
}