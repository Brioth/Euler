using Euler.Logic;
using Euler.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Euler
{
    public class Solver
    {
        public int Solve(Problem problem, int[] input)
        {
            int result;

            switch (problem.EulerId)
            {
                case 1: 
                    result = Solve_1(input[0]);
                    break;
                case 2:
                    result = Solve_2(input[0]);
                    break;
                default:
                    throw new NotImplementedException("Solver not implemented for this problem");
            }

            return result;
        }

        private int Solve_1(int belowNumber)
        {
            List<int> fullRange = Enumerable.Range(1, belowNumber-1).ToList();
            List<int> numbersToAdd = new List<int>();

            foreach (int number in fullRange)
            {
                if (number%3==0 || number%5==0)
                {
                    numbersToAdd.Add(number);
                }
            }

            return numbersToAdd.Sum();
        }

        private int Solve_2(int maxValue)
        {
            List<int> fibonacci = MathHelper.CreateFibonacciWithMaxValue(maxValue);
            return fibonacci.Where(x => x % 2 == 0).Sum();
        }
    }
}
