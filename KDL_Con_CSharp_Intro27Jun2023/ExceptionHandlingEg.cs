using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDL_Con_CSharp_Intro27Jun2023
{
    internal class ExceptionHandlingEg
    {

        static void Main()
        {
            Console.WriteLine("Enter number"); int a = 0;
            try
            {
                try
                {

                    a = int.Parse(Console.ReadLine());
                }
                //specific
                catch (FormatException ex)
                {
                    Console.WriteLine("Invalid Number , Enter only number");
                }
                catch (OverflowException ex)
                {
                    Console.WriteLine("too Large number");

                    throw;


                }
                finally 
                {

                    Console.WriteLine("Inner Finally called");
                
                }

            }
            // General
            catch (Exception ex)
            {
                Console.WriteLine("Error :  " + ex.ToString());

                
            }
            finally
            {

                Console.WriteLine("Outer Finally called");

            }





            Console.WriteLine(a);

            Console.ReadKey();
        }



    }
}
