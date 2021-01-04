using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMS.Entities
{
    public class Cattle : Animal
    {
        string tagNo;
        int price;
        AnimalType type;
        AnimalBreed breed;
        AnimalSource source;
        AnimalStatus status;
        string otherDetails;

        public override string ToString()
        {
            return tagNo;
        }

        public string TagNo
        {
            get
            {
                return tagNo;
            }

            set
            {
                tagNo = value;
            }
        }

        public int Price
        {
            get
            {
                return price;
            }

            set
            {
                if(value<0)
                {
                    throw new ArgumentException("Price cannot be negative");
                }
                else
                {
                    price = value;
                }
            }
        }

        public AnimalType Type
        {
            get
            {
                return type;
            }

            set
            {
                type = value;
            }
        }

        public AnimalSource Source
        {
            get
            {
                return source;
            }

            set
            {
                source = value;
            }
        }

        public AnimalStatus Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
            }
        }

        public AnimalBreed Breed
        {
            get
            {
                return breed;
            }

            set
            {
                breed = value;
            }
        }

        public string OtherDetails
        {
            get
            {
                return otherDetails;
            }

            set
            {
                otherDetails = value;
            }
        }
    }
}