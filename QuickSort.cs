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
          // Console.WriteLine("Please type the numbers you want to be sorted separated by a comma and press enter");
          //  string preSplitDataToSort = Console.ReadLine();
           //string [] splitDataToSort = preSplitDataToSort.Split(',');
           //int[] dataToSort = Array.ConvertAll(splitDataToSort, int.Parse);
            int[] dataToSort = { 23,56,34,34,5645,57,34,1423,45,2345,234,244,678,76,65,347,86,658 };
            clsSort cls = new clsSort(dataToSort);
            
            cls.quickSort(0, dataToSort.Length-1);

        }
class clsSort
    {
        int[] data;
        /***if you want to preserve the data for some reason replace the data = vals with this code
         *      int[] data = new int[vals.Length];
         *      Array.Copy(vals, data, vals.Length);
         *****/
        public clsSort(int[] vals)
        {
            data = vals;
        }
            
        /*****
         * Purpose:     THis mehtod sorts an array of integers values into 
         *              ascending order via recursive calls to quicksort().
         *              
         * Parameter List:
         *   int first          the first value to sort
         *   int last           the last value to sort
         *   
         * Return Value:
         *   void
         *****/
        public void quickSort(int first, int last)
        {
            int startIndex;
            int endIndex;
                

            startIndex = first;
            endIndex = last;

            if (last - first >= 1)
            {
                int pivot = data[first];

                while (endIndex > startIndex)
                {
                    while (data[startIndex] <= pivot && startIndex <= last && endIndex > startIndex)
                    {
                        startIndex++;
                    }
                    while (data[endIndex] > pivot && endIndex >= first && endIndex >= startIndex)
                    {
                        endIndex--;
                    }
                    if (endIndex > startIndex)
                    {
                        swap(startIndex, endIndex);
                    }
                }
                swap(first, endIndex);
                quickSort(first, endIndex - 1);
                quickSort(endIndex + 1, last);

            }
            else
            {
                    //for (int i = 0; i < data.Length; i++)
                    //{
                    //    Console.WriteLine(data[i]);

                    //}
                    //Console.ReadKey();

                    return;

            }

                
            }
        /*****
         * Purpose:     THis method performs the data swap for quickSort()
         * 
         * Parameter List:      
         *      int pos1        the array index first value
         *      int pos2        the array index to second value
         *      
         * Return value:
         *      void
         *****/
        public void swap(int pos1, int pos2)
        {
            int temp;

            temp = data[pos1];
            data[pos1] = data[pos2];
            data[pos2] = temp;
        }
            //for (int i = 0; i < data.Length; i++)
            //{
            //    Console.WriteLine(data[i]);

            //}
            //Console.ReadKey();
        }
    }

}
