using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCSharpToolProject
{
    public static partial class ToolFunctions
    {

        public static int FindClosestIndex(List<double> numbers, double target)
        {
            if (numbers == null || numbers.Count == 0)
                throw new ArgumentException("列表不能為空");

            int closestIndex = 0;
            double smallestDifference = double.MaxValue;

            for (int i = 0; i < numbers.Count; i++)
            {
                double difference = Math.Abs(numbers[i] - target);
                if (difference < smallestDifference)
                {
                    smallestDifference = difference;
                    closestIndex = i;
                }
            }

            return closestIndex;
        }
    }
}
