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
using System.Data.SqlClient;
using System.Configuration;
using System.ServiceModel;

namespace SandBox
{
   class Program
    {
        class Box
        {
            private double length;
            private double breadth;
            private double height;

            public double getVolume()
            {
                return length * breadth * height;
            }

            public void setLength(double len)
            {
                length = len;
            }
            public void setBreadth(double bre)
            {
                breadth = bre;
            }
            public void setHeight(double hei)
            {
                height = hei;
            }
            //Overloaded operator that adds a Box object to another Box object
            public static Box operator+ (Box b, Box c)
            {
                Box box = new Box();
                box.length = b.length + c.length;
                box.breadth = b.breadth + c.breadth;
                box.height = b.height + c.height;
                return box;
            }
        }
        class Tester
        {
            static void Main()
            {
                Box Box1 = new Box();
                Box Box2 = new Box();
                Box Box3 = new Box();
                double volume = 0.0;

                Box1.setLength(6.0);
                Box1.setBreadth(7.0);
                Box1.setHeight(5.0);

                Box2.setLength(12.0);
                Box2.setBreadth(13.0);
                Box2.setHeight(10.0);

                volume = Box1.getVolume();
                Console.WriteLine("Volume for Box1: " + volume);

                volume = Box2.getVolume();
                Console.WriteLine("Volume for Box2: " + volume);

                Box3 = Box1 + Box2;
                Console.WriteLine("Box1 + Box2: " + Box3.ToString());

                volume = Box3.getVolume();
                Console.WriteLine("Volume for Box3: " + volume);
                Console.ReadKey();
            }
        }
    }
}
