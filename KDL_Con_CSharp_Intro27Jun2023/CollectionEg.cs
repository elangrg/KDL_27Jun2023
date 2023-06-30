using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDL_Con_CSharp_Intro27Jun2023
{
    internal class CollectionEg
    {

        static void Main()
        {
            // Index based Collection 
            List<string> lstNames = new List<string>() { "Mahesh", "Dinesh", "Suresh" };


            lstNames.Add("Ganesh");
            lstNames.AddRange(new string[] { "Ramesh", "Amaresh" });

            //Sequential Access
            foreach (string name in lstNames)
            {
                Console.WriteLine(name);    
            }

            // Random Access 

            Console.WriteLine(lstNames[5]);

            lstNames.RemoveAt(5);
            lstNames.Remove("Dinesh");


            // Key based  Dictionary

            Dictionary<string, string> dicNames = new Dictionary<string, string>();

            dicNames.Add("1000","Ganesh");
            dicNames.Add("1001", "Mahesh");
            dicNames.Add("1002", "Dinesh");
            //Sequential Access
            foreach (KeyValuePair<string,string> name in dicNames)
            {
                Console.WriteLine(name.Value + " " + name.Key);
            }

            // Random Access 

            Console.WriteLine(dicNames["1001"]);

           
            dicNames.Remove("1002");



            Console.ReadKey();



        }


    }
}
