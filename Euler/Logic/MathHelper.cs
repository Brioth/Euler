using System.Collections.Generic;

namespace Euler.Logic
{
    public static class MathHelper
    {
        public static List<int> CreateFibonacci(int count)
        {
            List<int> fibonacciSequence = new List<int>();

            int number1 = 0;
            int number2 = 1;

            while (fibonacciSequence.Count < count)
            {
                var nextNumber = number1 + number2;
                fibonacciSequence.Add(nextNumber);

                number1 = number2;
                number2 = nextNumber;
            }

            return fibonacciSequence;
        }

        public static List<int> CreateFibonacciWithMaxValue(int maxValue)
        {
            List<int> fibonacciSequence = new List<int>();

            int number1 = 0;
            int number2 = 1;
            var nextNumber = 1;

            while (nextNumber <= maxValue)
            {                
                fibonacciSequence.Add(nextNumber);

                number1 = number2;
                number2 = nextNumber;

                nextNumber = number1 + number2;
            }

            return fibonacciSequence;
        }
    }
}
