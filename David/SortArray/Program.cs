using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortArray
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arrayNames = { " Everyone ", " should ", "learn ", " how ", " to code ", " it ", " teaches ", " you " , "how to", " think " };


            //This the current array
            Console.WriteLine(String.Join(", ", arrayNames));

            //sorted array in alphanumerical accending
            Array.Sort(arrayNames);
            Console.WriteLine(String.Join(", ", arrayNames));
          

            Array.Reverse(arrayNames);
            Console.WriteLine(String.Join(", ", arrayNames));
     

            Console.WriteLine(string.Concat( arrayNames));
                        Console.ReadKey();



        }

       

    }

    
}
