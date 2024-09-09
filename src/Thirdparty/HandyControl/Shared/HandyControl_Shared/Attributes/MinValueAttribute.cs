using System;

namespace HandyControl.Attributes
{
    public class MinValueAttribute : Attribute
    {
        public double MinValue { get; set; }

        public MinValueAttribute(double minValue)
        {
            MinValue = minValue;
        }
    }
}