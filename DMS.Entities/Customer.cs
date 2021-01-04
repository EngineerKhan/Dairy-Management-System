using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Entities
{
    public class Customer : Person
    {
        string dairyID;
        double quantity;
        PriceCategory priceCat;
        AnimalType milkType; //Cow, Buffalo will do as that's intended by Milk Type - 7 Jan
        Time delieveryTime;
        string cnic_No;

        public string DairyID
        {
            get
            {
                return dairyID;
            }

            set
            {
                dairyID = value;
            }
        }

        public double Quantity
        {
            get
            {
                return quantity;
            }

            set
            {
                quantity = value;
            }
        }

        public PriceCategory PriceCat
        {
            get
            {
                return priceCat;
            }

            set
            {
                priceCat = value;
            }
        }

        public AnimalType MilkType
        {
            get
            {
                return milkType;
            }

            set
            {
                milkType = value;
            }
        }

        public Time DelieveryTime
        {
            get
            {
                return delieveryTime;
            }

            set
            {
                delieveryTime = value;
            }
        }

        public new string CNIC_No
        {
            get
            {
                return cnic_No;
            }

            set
            {
                cnic_No = value;
            }
        }

    }
}
