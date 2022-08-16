using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinQ
{
    internal class Employee 
    {
       public Employee()
        {
            _Empchildren = new string[] { };
        }

        //Employees children's 
        private string[] _Empchildren;
        public string[] Empchildren
        {
            get { return _Empchildren; }
            set { _Empchildren = value; }
        }



        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private int _Number;

        public int Number
        {
            get { return _Number; }
            set { _Number = value; }
        }

        private string _City;

        public string City
        {
            get { return _City; }
            set { _City = value; }
        }

        private int _Salary;

        public int Salary
        {
            get { return _Salary; }
            set { _Salary = value; }
        }

     //public Position position { get; set; }


    }
}
