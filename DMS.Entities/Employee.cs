using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Entities
{
    public class Employee : Person
    {
        EmployeeRole role;
        DateTime joiningDate;
        int salary;
        string dutyDescription;

        public Employee()
        {

        }

        public Employee(string n)
        {
            Name = n;
        }

        public override DateTime BirthDate
        {
            get
            {
                return base.BirthDate;
            }

            set
            {
                if(value.Year>1997 || value.Year<1940)
                {
                    throw new ArgumentException("Age must be greater than 17 and less than 75.");
                }
                else
                {
                    base.BirthDate = value;
                }
                
            }
        }

        public EmployeeRole Role
        {
            get
            {
                return role;
            }

            set
            {
                role = value;
            }
        }

        public DateTime JoiningDate
        {
            get
            {
                return joiningDate;
            }

            set
            {
                if (value > DateTime.Now || value.Year < 2013)
                {
                    throw new ArgumentException("Joining Date cannot be in Future Date or before 2013.");
                }
                else
                {
                    joiningDate = value;
                }
            }
        }

        public string DutyDescription
        {
            get
            {
                return dutyDescription;
            }

            set
            {
                dutyDescription = value;
            }
        }

        public int Salary
        {
            get
            {
                return salary;
            }

            set
            {
                salary = value;
            }
        }
    }
}
