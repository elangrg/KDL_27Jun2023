using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDL_Con_CSharp_Intro27Jun2023
{
    internal class LINQEg
    {

        static void Main()
        { 
        
            List<Candidate> candidates = new List<Candidate>() { new Candidate { CandidateId =1000, CandidateName ="Mahesh", Address="Blr", Age=20 },
            new Candidate { CandidateId =1001, CandidateName ="Dinesh", Address="Chn", Age=19 },
            new Candidate { CandidateId =1002, CandidateName ="Suresh", Address="Chn", Age=34 },
            new Candidate { CandidateId =1003, CandidateName ="Ramesh", Address="Pun", Age=22 },
            new Candidate { CandidateId =1004, CandidateName ="Rajesh", Address="Blr", Age=31 },

            }; 

          IEnumerable<Candidate> qry=  candidates.Where(c => c.CandidateName.Contains("Ra"));

            foreach (Candidate  c in qry)
            {

                Console.WriteLine(c.CandidateName);
            }



            Console.ReadKey();

           



        }


    }
}
