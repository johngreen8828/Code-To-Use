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


public class Program
{
    public class Customer : IComparable<Customer>
    {
               
        public int Id { get; set; }
        public string Name { get; set; } 
        public int Salary { get; set; }

        //Created a class to implement CompareTo from IComparable--Sort uses this
        public int CompareTo(Customer other)
        {
            return this.Salary.CompareTo(other.Salary);
          // if (this.Salary > other.Salary)
          // {
          //     return 1;
          // }
          // else if(this.Salary < other.Salary)
          // {
          //     return -1;
          // }
          // else
          // {
          //     return 0;
          // }
        }
    }

    //Created a class to implement Compare from IComparer
    private class SortByName : IComparer<Customer>
    {
        public int Compare(Customer x, Customer y)
        {
            return x.Name.CompareTo(y.Name);
        }
    }

    private static int CompareCustomer(Customer x, Customer y)
    {
        return x.Id.CompareTo(y.Id);
    }

    static void Main()
    {        

        Customer customer1 = new Customer
        {
            Id = 130,
            Name = "John Green",
            Salary = 70000

        };

        Customer customer2 = new Customer
        {
            Id = 150,
            Name = "Chris Green",
            Salary = 30000

        };

        Customer customer3 = new Customer
        {
            Id = 100,
            Name = "Mike Green",
            Salary = 100000

        };

        List<Customer> listCustomers = new List<Customer>();
        listCustomers.Add(customer1);
        listCustomers.Add(customer2);
        listCustomers.Add(customer3);
        listCustomers.Add(customer2);
        foreach (Customer c in listCustomers)
        {
            Console.WriteLine(c.Name);
        }


        //Simple Find Method--------------------parameter here--property to check 
        var returnCustomer = listCustomers.Find(customer => customer.Id == 150);
        Console.WriteLine("Returned :  " + returnCustomer.Name);
        Console.WriteLine("------------------------------");


        Console.WriteLine("Salaries before Sort");

            foreach (Customer c in listCustomers)
             {
            Console.WriteLine(c.Salary);
             }

        Console.WriteLine("------------------------------");
        listCustomers.Sort();
        
        Console.WriteLine("Salaries after Sort");

        foreach (Customer c in listCustomers)
        {
            Console.WriteLine(c.Salary);
        }
        Console.WriteLine("------------------------------");

        listCustomers.Reverse();
        Console.WriteLine("Salaries after Sort Reverse");

        foreach (Customer c in listCustomers)
        {
            Console.WriteLine(c.Salary);
        }
        Console.WriteLine("------------------------------");

        SortByName sortByName = new SortByName();
        listCustomers.Sort(sortByName);
        Console.WriteLine("Sorted by Name");

        foreach (Customer c in listCustomers)
        {
            Console.WriteLine(c.Name);
        }
        #region 
        //This regions describes the Comparison Delegate the long wan
       Console.WriteLine("------------------------------");
      // Console.WriteLine("Before Sort Id using the Comparison Delegate");
      //
      // Comparison <Customer> customerComparer = new Comparison<Customer>(CompareCustomer);
      //
      // foreach(Customer c in listCustomers)
      // {
      //     Console.WriteLine(c.Id);
      // }
      //
      // listCustomers.Sort(customerComparer);
       Console.WriteLine("After Sort Id using the Comparison Delegate");
      //
      // foreach (Customer c in listCustomers)
      // {
      //     Console.WriteLine(c.Id);
      // }
        #endregion

        //This is a shorter way using the delegate keyword for the above Comparison
      //  listCustomers.Sort(delegate (Customer x, Customer y)
      //  {
      //      return x.Id.CompareTo(y.Id);
      //  });
      //  foreach (Customer c in listCustomers)
      //  {
      //     Console.WriteLine(c.Id);
      //  }

        //This is an even shorter way using the lambda expression for the above Comparison
        listCustomers.Sort((x, y) => x.Id.CompareTo(y.Id));
        foreach (Customer c in listCustomers)
        {
            Console.WriteLine(c.Id);
        }

        //Using TrueForAll()  Check all elements to see if they meet a condition in the predicate
        Console.WriteLine($"Are all the employees over 50000 in salary?  {listCustomers.TrueForAll(x => x.Salary > 50000)}");

        //uses System.Collections.ObjectModel for the return.  you cannot just call it on the list customers;
        ReadOnlyCollection<Customer> readonlyCustomers = listCustomers.AsReadOnly();
        //readonlyCustomers.Add(customer1); wont work
        Console.WriteLine( "Items: " + readonlyCustomers.Count);  //you can count them though

        List<Customer> listCapacityCustomers = new List<Customer>(100);
        listCapacityCustomers.Add(customer1);
        listCapacityCustomers.Add(customer2);
        listCapacityCustomers.Add(customer3);
        Console.WriteLine("------------------------------");

        Console.WriteLine("Capacity b4 trimming: " + listCapacityCustomers.Capacity);
        listCapacityCustomers.TrimExcess();
        Console.WriteLine("Capacity After trimming: " + listCapacityCustomers.Capacity );
        Console.WriteLine("------------------------------");
        Console.WriteLine("----------- Queues--------------------------");

        //Using the Queue
        Queue<Customer> queueCustomers = new Queue<Customer>();
        queueCustomers.Enqueue(customer1);
        queueCustomers.Enqueue(customer2);
        queueCustomers.Enqueue(customer3);
        queueCustomers.Enqueue(customer2);

        int cntr = 0;
        foreach (var cust in queueCustomers)
        {
            cntr++;
            Console.WriteLine($"Listing of Customer no. {cntr} : {cust.Name}");
        }

        Console.WriteLine("------------------------------");

        Customer cqp = queueCustomers.Peek();
        Console.WriteLine("Customer Name that was peeked:  " + cqp.Name);

        Console.WriteLine("------------------------------");

        //Removes from the top of the list
        Customer dequedCustomer = queueCustomers.Dequeue();
        Console.WriteLine("Customer Name removed: " + dequedCustomer.Name);
        Console.WriteLine("------------------------------");
        cntr = 0;
        foreach (var cust in queueCustomers)
        {
            cntr++;
            Console.WriteLine($"Listing of Customer no. {cntr} : {cust.Name}");
        }

        Console.WriteLine("--------------Stacks----------------");

        //Stacks
        Stack<Customer> stackCustomers = new Stack<Customer>();
        stackCustomers.Push(customer1);
        stackCustomers.Push(customer2);
        stackCustomers.Push(customer3);
        stackCustomers.Push(customer2);

        cntr = 0;
        foreach (var cust in stackCustomers)
        {
            cntr++;
            Console.WriteLine($"Listing of Customer no. {cntr} : {cust.Name}");
        }

        Console.WriteLine("------------------------------");

        Customer stackCqp = stackCustomers.Peek();
        Console.WriteLine("Customer Name that was peeked:  " + stackCqp.Name);

        Console.WriteLine("------------------------------");

        //Removes from the bottom of the list
        Customer popCustomer = stackCustomers.Pop();
        Console.WriteLine("Customer Name removed: " + popCustomer.Name);
        Console.WriteLine("-------------Stack Result after pop-----------------");

        cntr = 0;
        foreach (var cust in stackCustomers)
        {
            cntr++;
            Console.WriteLine($"Listing of Customer no. {cntr} : {cust.Name}");
        }
    }
}