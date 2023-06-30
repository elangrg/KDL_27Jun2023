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


            // 2.0 Anonymous block / Method
            fptr += delegate (int x, int y)
                                { return x + y; };

            // 3.0 Lambda Expression
            
            // Explicited typed argument with block body
            fptr += (int x, int y) => { return x + y; };

            // Implicitly typed Argument with block body
            fptr += ( x,  y) => { return x + y; };


            // Implicitly typed Argument with Expression body
            fptr += (x, y) =>  x + y; 




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
