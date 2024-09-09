using System;

namespace HandyControl.Attributes
{
    public class MaxValueAttribute : Attribute
    {
        public double MaxValue { get; set; }

        public MaxValueAttribute(double maxValue)
        {
            MaxValue = maxValue;
        }
    }
}