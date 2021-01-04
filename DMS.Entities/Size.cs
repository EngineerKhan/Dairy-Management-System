using System;

namespace DMS.Entities
{
    public class Size
    {
        double length, width, height;

        public double Height
        {
            get
            {
                return height;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Weight cannot be negative.");
                }
                else
                {
                    height = value;
                }
            }
        }

        public double Length
        {
            get
            {
                return length;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Weight cannot be negative.");
                }
                else
                {
                    length = value;
                }
            }
        }

        public double Width
        {
            get
            {
                return width;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Weight cannot be negative.");
                }
                else
                {
                    width = value;
                }
            }
        }
    }
}