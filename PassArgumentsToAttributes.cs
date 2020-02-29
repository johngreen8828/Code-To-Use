using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Reflection;
using System.Linq;


class MeAttribute : Attribute
{
    public MeAttribute(int value, string secondValue)  //Added parameters to constructor
    {
        Console.WriteLine("MeAttribute()");
        Console.WriteLine(value);
        Console.WriteLine(secondValue);
    }
}


[Me(25, "Johnny")] //Argument to MeAttribute...Btw [Me] is the shortened version of [MeAttribute]
class MainClass
{
    static void Main()
    {
        typeof(MainClass).GetCustomAttributes(false);
    }
}
