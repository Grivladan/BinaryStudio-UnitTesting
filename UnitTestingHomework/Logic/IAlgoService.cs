using System.Collections.Generic;

namespace Logic
{
    public interface IAlgoService
    {
        int MethodsCalledCount { get; }

        int DoubleSum(IEnumerable<int> arg);

        int MinValue(IEnumerable<int> arg);


        double GetAverage(IEnumerable<int> data);
        double Sqr(int data);
        double Function(int a, double b, int c, double d);
    }
}