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
        //Animal a = new Animal();
       // a.Move();

        //Can pass dog argument into an Animal type parameter and the animal.Move will run b/c a dog is an animal
        Dog d = new Dog();
        MoveAnimal(d);
        d.Move();
    }

    static void MoveAnimal(Animal a)
    {
        a.Move();
    }
   
    class Animal
    {
        public string Name { get; set; }    

        public int Age { get; set; }

        //When I call the animal version of this it will be the Animal.Move
        public virtual void Move()
        {
            Console.WriteLine("Animal.Move");
        }
       
    }

    //Basic base class Animal Derived class Dog
    class Dog : Animal
    {
        //When I call the dog version of the Move from animal it will be Dog.Move
        public override void Move()
        {
            Console.WriteLine("Dog.Move");
            //When I add the base.Move it will also run the Animal.Move
            base.Move();
        }

        public void Bark()
        {
            Console.WriteLine("Dog.Bark");
            
        }
    }
}