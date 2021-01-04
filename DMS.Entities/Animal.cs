using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Entities
{
    public class Animal
    {

        #region Attributes

        int id;
        DateTime birthDate, registrationDate;
        PhysicalAttributes currPhysicalAttribs;
        Gender gender;
        
        //string registrationDateString;

        public Animal()
        {

        }

        public Animal(int v)
        {
            ID = v;
        }

        public int ID
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

        public DateTime BirthDate
        {
            get
            {
                return birthDate;
            }

            set
            {
                birthDate = value;
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

        //public string RegistrationDateString
        //{
        //    get
        //    {
        //        return registrationDate.ToShortDateString();
        //    }

        //    set
        //    {
        //        //registrationDate = new DateTime(value);
        //    }
        //}

        public PhysicalAttributes CurrPhysicalAttribs
        {
            get
            {
                return currPhysicalAttribs;
            }

            set
            {
                currPhysicalAttribs = value;
            }
        }

        public Gender Gender
        {
            get
            {
                return gender;
            }

            set
            {
                gender = value;
            }
        }


        #endregion


    }
}
