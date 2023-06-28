using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDL_Con_CSharp_Intro27Jun2023
{
    internal class OOPMiscEg
    {

        static void Main()
        {


            clsDemo objDemo = new clsDemo();

            objDemo.DisplayInfo();

            IOne objOne = objDemo;
            objOne.DisplayInfo();

            ITwo objTwo = objDemo;
            objTwo.DisplayInfo();





            IBMEmployee obj = new IBMEmployee();
            obj.EmpID = 1000;
            obj.EmpName = "Ganesh";
            obj.DOB = DateTime.Now.AddDays(-10000);

            Console.WriteLine(obj);

            Console.WriteLine("Emp Id Is :" + obj.EmpID);

            obj.DisplayInfo();

            IEmployee objImp = obj;
            objImp.DisplayInfo();




            Console.ReadKey();

        }


    }

    interface IEmployee
    {
        int EmpID { get; set; }
        string EmpName { get; set; }

        void DisplayInfo();
    }

    class IBMEmployee : IEmployee
    {
        private int _EmpID;

        public int EmpID
        {
            get { return _EmpID; }
            set { _EmpID = value; }
        }


        private string _EmpName;

        public string EmpName
        {
            get { return _EmpName; }
            set
            {
                // Validation
                if (value.Length > 2)
                {
                    _EmpName = value;
                }
                else
                    _EmpName = "NA";


            }
        }


        // Auto Prop 3.0
        public DateTime DOB { get; set; }


        //private int _DOB;

        //public int DOB
        //{
        //    get { return _DOB; }
        //    set { _DOB = value; }
        //}



        // Computed 
        public int Age
        {
            get { return DateTime.Now.Year - DOB.Year; }

        }


        public override string ToString()
        {
            return $"Employee ID : {this.EmpID}, Emp name : {this.EmpName} , Date of Birth : {this.DOB.ToString("dd MMM yyyy")} , Age : {this.Age} ";
        }



        public void DisplayInfo()
        {
            Console.WriteLine(this);
        }
        int IEmployee.EmpID {


            get { return _EmpID; }
            set { _EmpID = value; }

        }
        string IEmployee.EmpName
        {
            get { return _EmpName; }
            set
            {
                // Validation
                if (value.Length > 2)
                {
                    _EmpName = value;
                }
                else
                    _EmpName =" IMP "+ "NA";


            }
        }

        void IEmployee.DisplayInfo()
        {
            Console.WriteLine("Explicit Imp");
        }
    }

    class clsDemo : IOne, ITwo
    {
        public void DisplayInfo()
        {
            Console.WriteLine("Display Info Called");

        }


        void IOne.DisplayInfo()
        {
            Console.WriteLine("IOne Display Info Called");

        }

        void ITwo.DisplayInfo()
        {
            Console.WriteLine("ITwo Display Info Called");

        }
    }

    interface IOne
    {
        void DisplayInfo();
    }


    interface ITwo
    {
        void DisplayInfo();
    }


}
