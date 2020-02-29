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
        static void Main()
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from dbo.Employees", con);
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    //Reader will read throught the rows in the rdr object and print out the values in the rows
                    while (rdr.Read())
                    {
                        //Here the index refers to the columns in the row and returns the value of the row at column []
                        Console.WriteLine(rdr[0] + " " + rdr[1] + " " + rdr[2] + " " + rdr[3] + " " + rdr[4]);
                        
                    }
                }
            }
        }
       



    }
}
