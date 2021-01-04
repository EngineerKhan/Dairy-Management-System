using System;

namespace DMS.Entities
{
    public class MilkingEntry
    {
        Cattle milkingCattle;
        DateTime milkingTime, entryTime;
        string milkingShift;
        double quantity;
        string comments;
        public DateTime EntryTime
        {
            get
            {
                return entryTime;
            }

            set
            {
                entryTime = value;
            }
        }

        public Cattle MilkingCattle
        {
            get
            {
                return milkingCattle;
            }

            set
            {
                milkingCattle = value;
            }
        }

        public DateTime MilkingDate
        {
            get
            {
                return milkingTime;
            }

            set
            {
                if(value>DateTime.Now)
                {
                    throw new ArgumentException("Milking (Time) Entry cannot be in Future Date/Time.");
                }
                else
                {
                    milkingTime = value;
                }
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
                if(value<0)
                {
                    throw new ArgumentException("Milk Quantity cannot be negative.");
                }
                else
                {
                    quantity = value;
                }
            }
        }

        public string MilkingShift
        {
            get
            {
                return milkingShift;
            }

            set
            {
                milkingShift = value;
            }
        }

        public string Comments
        {
            get
            {
                return comments;
            }

            set
            {
                comments = value;
            }
        }
    }
}
