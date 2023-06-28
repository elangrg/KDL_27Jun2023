using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDL_Con_CSharp_Intro27Jun2023
{
    internal class MethodEg
    {


        static void Main()
        {
            int i = 100;
            Console.WriteLine("Before Display  i={0} ", i);
            display(i);
            Console.WriteLine("After Display i={0} ", i);

            displayRef(ref i);
            Console.WriteLine("After DisplayRef i={0} ", i);

            displayOut(out i);
            Console.WriteLine("After DisplayOut i={0} ", i);

            displayParams(10, 20, 30, 40, 70, 100);

            int[] arr = { 1, 2, 3, 4, 5 };

            displayParams(arr);
            displayParams();
            

            // Named and Optional Arg (.net ver 4.0)

            Console.WriteLine(Sum(100, 200));
            Console.WriteLine(Sum(100, 200, 300, 400));

            Console.WriteLine(Sum(100, 200, d: 400));
            Console.WriteLine(Sum(b: 100, c: 200, d: 400, a: 50));

            Console.ReadKey();


        }

        static void display(int x)
        {
            x++;
            Console.WriteLine(" In Display x={0} ", x);
        }


        static void displayRef(ref int x)
        {
            
            x++;
            Console.WriteLine(" In DisplayRef x={0} ", x);
        }

        static void displayOut(out int x)
        {

           x = 0;
            x++;
            Console.WriteLine(" In DisplayOut x={0} ", x);
        }

        static void displayParams(params int[] x)
        {
            int j = 0;
            if (x.Length == 0)
                Console.WriteLine("No Values in X[] ");
            else if (x.Length > 0)
                for (j = 0; j < x.Length; j++)
                    Console.WriteLine(" In Display Params-> x[{0}]={1} ", j, x[j]);
        }


        public static int Sum(int a, int b, int c = 10, int d = 20)
        {
            return a + b + c + d;





        }






    }
}
