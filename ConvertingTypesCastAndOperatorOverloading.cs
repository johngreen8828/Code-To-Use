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
    class Miles
    {
        public Miles(double miles)
        {
            Distance = miles;
        }

        public double Distance { get; }

        public static implicit operator double(Miles t)
        {
            return (t.Distance * 1.6);
        }
        public static explicit operator int(Miles t)
        {
            return (int)(t.Distance + 0.5);
        }
       
    }
    class Kilometers
    {
        public double Distance { get; }

        public Kilometers(double kilometers)
        {
            Distance = kilometers;
        }
        
    }

    static void Main()
    {
        Miles m = new Miles(100);
        double k = m;
        int intMiles = m;
    }

}