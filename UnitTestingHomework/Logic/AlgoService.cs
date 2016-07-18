using System;
using System.Collections.Generic;
using System.Linq;

namespace Logic
{
    public class AlgoService : IAlgoService
    {
        public int MethodsCalledCount { get; private set; }

        public int DoubleSum(IEnumerable<int> arg)
        {
            MethodsCalledCount++;
            return arg.Sum(i => i * 2);
        }

        public int MinValue(IEnumerable<int> arg)
        {
            MethodsCalledCount++;
            return arg.Min(i => i);
        }

        public double Function(int a, double b, int c, double d)
        {
            MethodsCalledCount++;
            var result = Math.Pow(d, 3) + a * c - Math.PI * Math.Sqrt(b);
            return result;
        }

        public double GetAverage(IEnumerable<int> data)
        {
            MethodsCalledCount++;
            return data.Average();
        }

        public double Sqr(int data)
        {
            MethodsCalledCount++;
            return Math.Pow(data, 2);
        }
    }
}