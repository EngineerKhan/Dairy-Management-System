using System;
using System.Text.RegularExpressions;

namespace DMS.Entities
{
    public class Person
    {

        private readonly Regex nameEx = new Regex(@"^[A-Za-z ]+$");                     //For validating Names to be in correct format (not containing numbers)
        private readonly Regex CNICEx = new Regex(@"^\d{5}\-\d{7}\-\d{1}");             //For validating CNIC to be in correct format (not containing numbers)

        string id, name, fatherName;
        DateTime birthDate, registrationDate;
        string currAddress, permanentAddress, cnic_No, contactNo;

        public string ID
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public virtual DateTime BirthDate
        {
            get
            {
                return birthDate;
            }

            set
            {
                if (value > DateTime.Now)
                {
                    throw new ArgumentException("Birth Date cannot be in Future Date.");
                }
                else
                {
                    birthDate = value;
                }
            }
        }
        public string CurrentAddress
        {
            get
            {
                return currAddress;
            }

            set
            {
                currAddress = value;
            }
        }

        public string PermanentAddress
        {
            get
            {
                return permanentAddress;
            }

            set
            {
                permanentAddress = value;
            }
        }

        public DateTime RegistrationDate
        {
            get
            {
                return registrationDate;
            }

            set
            {
                registrationDate = value;
            }
        }

        public virtual string CNIC_No
        {
            get
            {
                return cnic_No;
            }

            set
            {
                if (value == null)
                    throw new ArgumentException("CNIC cannot be null");

                if (!CNICEx.Match(value).Success)
                    throw new ArgumentException("CNIC is not in Proper Format");

                cnic_No = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                if (value == null)
                    throw new ApplicationException("Name cannot be null");

                if (!nameEx.Match(value).Success)
                    throw new ArgumentException("Name may only " +
                              "contain characters or spaces");

                name = value;
            }
        }

        public string FatherName
        {
            get
            {
                return fatherName;
            }

            set
            {
                if (value == null)
                    throw new ArgumentException("Name cannot be null");

                if (!nameEx.Match(value).Success)
                    throw new ArgumentException("Name may only " +
                              "contain characters or spaces");

                fatherName = value;
            }
        }

        public string ContactNo
        {
            get
            {
                return contactNo;
            }

            set
            {
                contactNo = value;
            }
        }

        public override string ToString()
        {
            return name;
        }

    }
}
