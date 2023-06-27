using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDL_Con_CSharp_Intro27Jun2023
{
    internal class DatatypeEg
    {


        static void Main()
        {


            int typea1 = -2147483648; //32

            


            int typea2 = 2147483647;
            uint utypea1 = 4294967295;
            sbyte typsb1 = -128;
            sbyte typsb2 = 127;
            byte typb = 255;
            short typs1 = -32768;
            short typs2 = -32767;
            ushort typus1 = 65535;
            long typl1 = -9223372036854775808;
            long typl2 = 9223372036854775807;
            ulong typul = 18446744073709551615;
            char typec = 'x';
            float typf = 1.5f;
            double typdbl = 5.0; double typdbl1 = 5.0D;
            decimal typdec = 1.9M; //16		
            Console.WriteLine("Char contains {0}   {1}", typec, "index is One");
            object typobj;
            string typstr = "Hello World";
            typobj = typstr;
            Console.WriteLine("obj Points to {0}", typobj.ToString());
            Console.WriteLine("7.ToString() returns {0} ", 7.ToString());
            int j = 100;
            Console.WriteLine("Value of j={0}", j);
            bool bln = true;
            Console.WriteLine("Value of bln={0}", bln);

            DateTime dt = DateTime.Parse("12/12/12");
            Console.WriteLine("date is {0}", dt.ToString());



            // Conversion

            short s = 100;
            int i1 = s; // Implicit Conversion
            s = (short)i1; // Explicit Conversion

            string st = "1000";

            int i2 = int.Parse(st);

            st = st + i2;

            // boxing and unboxing
            int i = 100;
            object o = i; // Boxing
            int j1 = (int)o; // Unboxing


            Console.ReadKey();



        }



    }
}
