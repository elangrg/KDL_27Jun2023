using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDL_Con_CSharp_Intro27Jun2023
{
    internal class GenericEg
    {
        static void Main()
        {

            Console.WriteLine(Min<int>(100,200));


            Console.WriteLine(Min(100.24, 12.43));

            Console.WriteLine(Min("xyz", "abc"));

            Console.WriteLine(Min<int>(103, 100));

            GenericSyntaxDemo<int, SomeClass, string>(100, new SomeClass());


            demo<string> obj = new demo<string>("");

            obj.DemoDisplay("");



            Console.ReadKey();

        }

        //      static int Min(int a, int b)
        //      {
        //          if (a<b)
        //          {
        //              return a;
        //          }
        //          else
        //              return b;

        //      }
        //static double Min(double a, double b)
        //      {
        //          if (a<b)
        //          {
        //              return a;
        //          }
        //          else
        //              return b;

        //      }


        //static IComparable Min(IComparable a, IComparable b)
        //{
        //    if (a.CompareTo(b) <1)
        //    {
        //        return a;
        //    }
        //    else
        //        return b;

        //}
        static T Min<T>(T a, T b) where T:IComparable<T>
        {
          
            if (a.CompareTo(b) < 1)
            {
                return a;
            }
            else
                return b;

        }
 static TR GenericSyntaxDemo<T1,T2,TR>(T1 a, T2 b) where T1:struct
                                                   where T2:class,new()
        {

            T2 obj = new T2();

            return default(TR) ;




        }
    }

    class SomeClass
    {
        public string someProp { get; set; }

        //public SomeClass(string someProp)
        //{
        //    this.someProp = someProp;
        //}
    }


    class demo<T>
    {

        public demo(T a)
        {

        }

        public void DemoDisplay(T b)
        { 
        
        
        }


    }

}
