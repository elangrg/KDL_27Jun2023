using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDL_Con_CSharp_Intro27Jun2023
{
    public partial class Candidate
    {

        
        public string Address { get; set; }
        public int Age { get; set; }

        public void DisplayInfo()
        {
            Console.WriteLine(this.CandidateName + this.Address );
        
        }


    }
}
