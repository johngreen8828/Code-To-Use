using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

[Serializable]//Must have this attribute to make Cow serializable
class Cow
{
    public string Name;
    public int Weight;

}

class MainClass
{
    static void Main()
    {
        var betsy = new Cow { Name = "Betsy", Weight = 500 };
        var formatter = new BinaryFormatter();
        var memoryStream = new MemoryStream();
        formatter.Serialize(memoryStream, betsy);
        memoryStream.Seek(0, SeekOrigin.Begin);
        var betsysClone = formatter.Deserialize(memoryStream) as Cow;
        Console.WriteLine(betsysClone.Name);
        Console.WriteLine(betsysClone.Weight);
    }
}

