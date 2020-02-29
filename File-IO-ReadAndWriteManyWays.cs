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

    static void Main()
    {
        DirectoryInfo currDir = new DirectoryInfo(".");  //Current Directory
        DirectoryInfo myDir = new DirectoryInfo(@"C:\Users\johng\CodeToUse");
        DirectoryInfo dataDir = new DirectoryInfo(@"C:\Users\johng\C#Data");


        string[] Names =
        {
            "John Green",
            "Chris Green",
            "Mike Green"
        };

        string textFilePath = @"C:\Users\johng\C#Data\TestFile3.txt";
        dataDir.Create();
        
        File.WriteAllLines(textFilePath, Names);
        foreach (string name in File.ReadAllLines(textFilePath))
        {
            Console.WriteLine($"Names in File: {name}");
        }


        Console.WriteLine("----------------------");

        DirectoryInfo myDataDir = new DirectoryInfo(@"C:\Users\johng\C#Data");

        FileInfo[] txtFiles = myDataDir.GetFiles("*.txt", SearchOption.AllDirectories);
        Console.WriteLine($"Matches: {txtFiles.Length}");

        foreach (FileInfo file in txtFiles)
        {
            Console.WriteLine(file.Name);
            Console.WriteLine(file.Length);
        }

        Console.WriteLine("----------------------");

        
        Console.WriteLine(dataDir.FullName + " " + dataDir.CreationTime);
        Console.WriteLine(myDir.FullName);
        Console.WriteLine(myDir.Name);
        Console.WriteLine(myDir.Parent);
        Console.WriteLine(myDir.Attributes);
        Console.WriteLine(myDir.CreationTime);


        //Using File Stream to open or create a file
        FileStream fs = File.Open(textFilePath, FileMode.Create);

        //Create a random string for input and output to convert to byte array
        string randString = "Just testing the input to a file.  How about another.";

        //Convert to a byte array
        byte[] rsByteArray = Encoding.Default.GetBytes(randString);

        //Use streamWriter to write byte array. Parameters are byte array, then index to start writing from, and the length to write 
        fs.Write(rsByteArray, 0, rsByteArray.Length);
     
        //reposition the pointer to 0 for the read to start from
        fs.Position = 0;

        //create a new byte array to store the bytes that will be read
        byte[] fileByteArray = new byte[fs.Length];
        
        Console.WriteLine($"****************{fs.Length}************");
        //Read each character of the file and convert it to the byte array.  Read byte is cast into an int32 then you must cast to byte char
        for (int i = 0; i < fs.Length; i++)
        {
            fileByteArray[i] = (byte)fs.ReadByte();
        }
        //convert it from bytes to a string
        Console.WriteLine(Encoding.Default.GetString(fileByteArray));
        fs.Close();
        Console.WriteLine("----------------------");

        //using streamReader and Writer.  Best for working with strings
        string textFilePath4 = @"C:\Users\johng\C#Data\TestFile4.txt";
        //Create a text file with streamWriter
        StreamWriter sw = File.CreateText(textFilePath4);
        //Write to the file without new line
        sw.Write("this is another random string testing ");
        //Write to the file from the last position and ending with new line
        sw.WriteLine("for John.");
        //Write a line and end with new line
        sw.WriteLine("This is another line for reading.");
        sw.Close();
        //Reading from the file just created
        StreamReader sr = File.OpenText(textFilePath4);
        //Peek will look at and return the 1st character as unicode number and then I convert it.  Peek will not consume nor
        // move the pointer. It will still be at position 0.
        Console.WriteLine("Peek : {0}", Convert.ToChar(sr.Peek()));
        //Read a line
        Console.WriteLine("1st String : {0}", sr.ReadLine());
        //read to end of file from current position
        Console.WriteLine($"Reading to the end of file. Here is the text:  {sr.ReadToEnd()}");
        sr.Close();

        Console.WriteLine("----------------------");

        string textFilePath5 = @"C:\Users\johng\C#Data\TestFile5.dat";

        //Get the file
        FileInfo datFile = new FileInfo(textFilePath5);
        //Open the file using binary Writer and open for writing
        BinaryWriter bw = new BinaryWriter(datFile.OpenWrite());
        string bwText = "This is the binary writer writing text.  ";
        int myAge = 39;
        double height = 6.1;
        //Write to the file
        bw.Write(bwText);
        bw.Write(myAge);
        bw.Write(" - ");
        bw.Write(height);
        bw.Close();

        BinaryReader br = new BinaryReader(datFile.OpenRead());
        Console.WriteLine(br.ReadString());
        Console.WriteLine(br.ReadInt32());
        Console.WriteLine(br.ReadString());
        Console.WriteLine(br.ReadDouble());
        br.Close();

       
    }

}