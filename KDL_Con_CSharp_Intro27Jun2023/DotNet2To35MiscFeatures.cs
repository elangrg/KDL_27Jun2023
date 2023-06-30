using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDL_Con_CSharp_Intro27Jun2023
{
    internal class DotNet2To35MiscFeatures
    {
        


        static void Main()
        {
            // NullableType.Example();
            // StaticClass.Display();

            //Candidate objC = new Candidate();

            // objC.DisplayInfo();

            //LocalTypeInference();


            ObjectInit_AnonynmousType();



        }


        static void LocalTypeInference()
        {

            var demo = 100;
            //demo = ""; //error


            //var j; 
            //var k = null; 

        
        
        }



        static void ObjectInit_AnonynmousType()
        { 
        
            Candidate objCandidate=new Candidate() { CandidateId=1000, CandidateName="Ganesh", Address="Blr", Age =25 };

            var objCandidate1 = new Candidate() { CandidateId = 1001, CandidateName = "Mahesh", Address = "Kls", Age = 100 };

            // Anonymous 
            var objCandidate2 = new { CandidateId = 1001, CandidateName = "Mahesh", Address = "Kls", Age = 100 };

            Console.WriteLine(objCandidate.GetType());
            Console.WriteLine(objCandidate1.GetType());
            Console.WriteLine(objCandidate2.GetType());

        }
    }


    // 2.0 Nullable Type
    class NullableType
    {
        public static void Example()
        {

            int i = 100;

            int? j = 100;
            j = null;

            if (j.HasValue)
            {
                Console.WriteLine( j.Value);
            }

            Nullable<int> k = null;

            if (k.HasValue)
            {
                Console.WriteLine(k.Value);
            }

        }
    }

    // 2.0 static class
    static class StaticClass
    {
        public static  void Display()
        {
            Console.WriteLine("in static Class Display....");
        
        }
    }


    public partial class Candidate
    {

        public int CandidateId { get; set; }
        public string CandidateName { get; set; }
        

    }
}
