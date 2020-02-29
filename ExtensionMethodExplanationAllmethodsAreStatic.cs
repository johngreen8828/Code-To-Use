using System;
using System.Runtime.Serialization;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Text;
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

//How extension methods work

//Proving that all methods are static.  Compiler implicitely creates 'this' for instance members on non-static classes

public class Cow
{
    public int numMoos;

}
static class CowMethod
{
    public static void Moo(this Cow _this)
    {
        _this.numMoos++;
        Console.WriteLine("Mooo " + _this.numMoos);
    }
}
   
class Program
{
    static void Main()
    {

        //Once the cow is intantiated we can call Moo on the instance and the numMoos will have their own separate values for Mooing the 
        //There is a copy for numMoo on each instance but they share the Moo() method.  It uses implicit this.numMoos for each instance
        //set by class cow to look like below

        //    class Cow
        //{
        //    int numMoos;
        //    public void Moo()
        //    {
        //        numMoos++;
        //        Console.WriteLine("Mooo " + numMoos);
        //    }
        //}

        //Run the mooing like below
        //  c.Moo();
        //  c.Moo();
        //  c.Moo();
        //  c2.Moo();

        //Now if we change the Moo method to static and give it a parameter to take in the instantiated Cow object and give it its own _this 
        //referring to the Cow object then _this.numMoos++ refers to the instantiated reference to Cow object's numMoos.  So calling Cow.Moo(c2)
        //is a call to the available static Moo() method
        //call Moo on the c2 object you instantiated above. Moo takes in the c2 Cow object and assings it to _this in the static method declaration
        //Cow c = new Cow();
        //Cow c2 = new Cow();
        //Cow.Moo(c); Cow.Moo(c); Cow.Moo(c);
        //Cow.Moo(c2);

        //Now in the static Moo Declaration add this to refer to the Cow object static void Moo(this Cow _this) and put it into a static class so Cow can 
        //still instantiate and it will now become an extension method.  Make sure class Cow is above the static method otherwise the method won't know
        //where numMoos definition is. 
        Cow c = new Cow();
        Cow c2 = new Cow();
        c.Moo(); c.Moo(); c.Moo();
        c2.Moo();
    }
}