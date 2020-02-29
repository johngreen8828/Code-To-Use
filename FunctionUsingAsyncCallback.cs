using System;
using System.Runtime.Serialization;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Text;
using System.Xml.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;
using System.Linq;
using System.Data;


class Program
{
    public delegate DataTable myDel(string s);
    public static DataTable dt;
    public static myDel inv;

    static void Main()
    {
        inv = new myDel(Print);
        inv.BeginInvoke("Starting Print Method", new AsyncCallback(Callback),null);
        Console.ReadLine();
    }
    

    public static DataTable Print(string q)
    {
        Thread.Sleep(1000);
        Console.WriteLine(q);
        DataTable dt = new DataTable();
        dt.Columns.Add("Age");
        dt.Rows.Add(11);
        dt.Rows.Add(12);
        dt.Rows.Add(13);
        dt.Rows.Add(31);
        dt.Rows.Add(19);
        dt.Rows.Add(17);
        return dt;

    }

    public static void Callback(IAsyncResult t)
    {
        dt = inv.EndInvoke(t);
        foreach (DataRow row in dt.Rows)
        {
            Console.WriteLine($"Ages:  {row["Age"].ToString()}");
        }
    }
}