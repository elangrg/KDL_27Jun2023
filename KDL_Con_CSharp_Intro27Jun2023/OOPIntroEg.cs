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
            clsA objA= new clsA();

            objA.var_pub = 100;


        }




    }



    class clsA
    {
        private int var_prv = 0;
        public  int var_pub = 0;
        int var_Defa = 0;
        protected int var_ptd = 0;

    }


    class clsB:clsA
    {
        public void Display()
        {

            var_ptd = 200;

        
        }

    }

}
