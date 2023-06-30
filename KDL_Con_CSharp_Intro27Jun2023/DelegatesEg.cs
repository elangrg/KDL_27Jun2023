using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDL_Con_CSharp_Intro27Jun2023
{

    delegate int dlgDemo(int a, int b);



    internal class DelegatesEg
    {

        static void Main()
        {

            // Syntax 1.0 
            dlgDemo fptr = new dlgDemo(Add);


            // Syntax 2.0 DTI 
             fptr += Multi;



            Console.WriteLine(fptr(100, 200));

            

        
        
        }

        static int Add(int i, int j)
        {
            return i + j;
        }

   static int Multi(int k, int l)
        {
            return k * l;
        }

    }
}
