using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Sorting
{
     class Program
    {
        static void Main(string[] args)
        {
            
            string[] namesArray = new string[10];
         
            Console.WriteLine("Enter 10 values");
            // loop to fill the array
            for (int x = 0; x < namesArray.Length; x++)
            {
                // prompt for entries
              
               Console.Write("Enter Value Here: ");
                string value = Console.ReadLine();
                namesArray[x] = value;

            }

            // sort array
            Array.Sort(namesArray);
            //print sorted values
            Console.WriteLine("print sorted values:");
            for (int x = 0; x < namesArray.Length; x++)
            {
                Console.WriteLine("{0} ",namesArray[x]);
            }
           


            //entries Concatenation
            Console.WriteLine("print concatenated values : ");
            Console.Write($" ==> {string.Join(", ", namesArray)}");

            Console.Write("\n press any key to exit");
            Console.ReadKey();

            
        }
        
     }
}
