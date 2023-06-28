using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDL_Con_CSharp_Intro27Jun2023
{
    internal class OOPIntroEg
    {


        static void Main()
        {
            clsA objA= new  clsB();
            objA.Display();
            clsB objB= new clsB();
            objB.Display(); 
          

            clsC objC= new clsC();
            objC.Display();


            objA = objC; // Casting; implicit Casting
            objA.Display();


            objC = (clsC)objA; // Explicit Casting 
            objC.Display(); 
  Console.ReadKey();





        }




    }



    abstract class clsA
    {
        public abstract void Display();
        //{
        //    Console.WriteLine("In Display of clsA");
        //}

    }


    class clsB:clsA
    {
        public sealed override void Display()
        {
            Console.WriteLine("In Display of clsB");
        }

    }


    class clsC : clsB
    {
        //public override void Display()
        //{
        //    Console.WriteLine("In Display of clsC");
        //}

    }



}
