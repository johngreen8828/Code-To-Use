using System;
using System.Runtime.Serialization;
using System.IO;
using System.Xml;
using System.Text;
using System.Xml.Linq;
using System.Collections;
using System.Runtime.Serialization;


class ExceptionHandling
{
    static void Main()
    {
        try
        {
            StreamReader streamReader = new StreamReader(@"C:\Users\johng\OneDrive\Desktop\ClassTemplate1.txt");
            Console.WriteLine(streamReader.ReadToEnd());
            streamReader.Close();
        }

        catch (FileNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(ex.StackTrace);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(ex.StackTrace);

        }
    }
    class InnerException
    {
        static void Main()
        {
            bool Success = false;
            int Result;
            try
            {
                try
                {

                    do
                    {
                        checked
                        {
                            Console.WriteLine("Enter First Number to divide");
                            int FN = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Enter Second Number to divide");
                            int SN = Convert.ToInt32(Console.ReadLine());
                            if (FN != 0 && SN != 0)
                            {
                                Result = FN / SN;
                                Success = true;
                                Console.WriteLine($"Result of Division: { Result }");
                            }
                            else
                            {
                                Console.WriteLine("Cannot Divide by Zero, Please Re-enter numbers.");
                            }
                        }

                    } while (!Success);

                }
                catch (Exception ex)
                {
                    string filePath = @"C:\Data\db\Log.txt";

                    if (File.Exists(filePath))
                    {

                        using (StreamWriter sw = new StreamWriter(filePath))
                        {
                            sw.Write(ex.GetType().Name);
                            Console.WriteLine();
                            sw.Write(ex.Message);
                            sw.Close();
                            Console.WriteLine($"There is a problem.  See log file. { ex.Message }");
                        }

                    }
                    else
                    {
                        throw new FileNotFoundException(filePath + "is not found.", ex);
                    }

                }

            }
            catch (Exception exception)
            {
                Console.WriteLine($"Current Exception = {exception.GetType().Name}");
                if (exception.InnerException != null)
                {
                    Console.WriteLine($"Inner Exception = {exception.InnerException.GetType().Name}");
                }
            }
        }
    }

    class CustomExceptions
    {
        static void Main()
        {
            try
            {
                throw new UserAlreadyLoggedInException("Sorry!..No Duplicate Sessions allowed.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
    [Serializable]
    class UserAlreadyLoggedInException : Exception
    {
        //Overload constructors based on the Exception class.  F12 on exception class will give you the definitions
        public UserAlreadyLoggedInException() : base()
        {

        }
        //constructor passes the string parameter to the base class constructor to display the message
        public UserAlreadyLoggedInException(string message) : base(message)
        {

        }
        //constructor passes the string and Exception parameters to the base class constructor to display the message and have access to InnerException
        public UserAlreadyLoggedInException(string message, Exception innerException) : base(message, innerException)
        {

        }
        //constructor passes the Serialization and StreamingContext parameters to the base class constructor to access those values
        //Use SerializationInfo to pass tokens? across AppDomains so the other app can see it.  Make class [Serializable]
        public UserAlreadyLoggedInException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
    }
}