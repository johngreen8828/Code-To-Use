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
        //This is an ADO.NET way of Using a stored procedure to insert a row into the Sample db employee table

        //Add this to the config file
        //<connectionStrings>
        // <add name = "DBCS"
        // connectionString="Data Source=DESKTOP-5E4A4I2\SQLEXPRESS; database = Sample; integrated security=True"
        // providerName="System.Data.SQLClient"/>
        //</connectionStrings>
        static void Main(string[] args)
        {
            //Set up Connection String from config file
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            //using statement to create instance the connection object passing in the connection string from the config file
            using(SqlConnection con = new SqlConnection(CS))
            {
                //create instance of sqlcommand cmd passing in the stored procedure and connection object 
                SqlCommand cmd = new SqlCommand("spAddEmployee", con);
                //Need to supply the stored procedure property type of command to the command object
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //These are all of the parameters to the stored procedure.  I supplied input values that must match up with the types in the db
                cmd.Parameters.AddWithValue("@FirstName", "Maritza");
                cmd.Parameters.AddWithValue("@LastName", "Rodriguez");
                cmd.Parameters.AddWithValue("@Gender", "Female");
                cmd.Parameters.AddWithValue("@Salary", 50000);
                cmd.Parameters.AddWithValue("@DepartmentID", 3);
                //Create a sql parameter object This is the employee id that is returned as an out parameter from the stored procedure
                SqlParameter outputParameter = new SqlParameter();
                //specify the name of the sql parameter
                outputParameter.ParameterName = "ID";
                //Have to give the type of sql data type to the parameter
                outputParameter.SqlDbType = SqlDbType.Int;
                //Have to tell the parameter that we are receiving output from the stored procedure
                outputParameter.Direction = ParameterDirection.Output;
                //Pass in the sql parameter object to the command object cmd
                cmd.Parameters.Add(outputParameter);
                con.Open();
                //Use this for inserts, updates, and deletes not a query
                cmd.ExecuteNonQuery();
                string EmpId = outputParameter.Value.ToString();
                Console.WriteLine("Added Employee: " + EmpId);
                
            }
        }
    }
}
