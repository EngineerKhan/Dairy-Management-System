using System;

namespace DMS.Entities
{
    public class PhysicalAttributes
    {
        Size currentSize;
        double weight;
        Colour color;
        DisabilityStatus disableStatus;

        public Size CurrentSize
        {
            get
            {
                return currentSize;
            }

            set
            {
                currentSize = value;
            }
        }

        public double Weight
        {
            get
            {
                return weight;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Weight cannot be negative.");
                }
                else
                {
                    weight = value;
                }
            }
        }

        public Colour Color
        {
            get
            {
                return color;
            }

            set
            {
                color = value;
            }
        }

        public DisabilityStatus DisableStatus
        {
            get
            {
                return disableStatus;
            }

            set
            {
                disableStatus = value;
            }
        }
    }
}