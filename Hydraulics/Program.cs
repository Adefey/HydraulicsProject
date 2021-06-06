using System;

namespace Hydraulics
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int n = 5;
            if (args.Length != 0)
            {
                n = int.Parse(args[0]);
            }

            WaterSupply waterSupply = new WaterSupply();

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Итерация №{i}");
                waterSupply.EvaluateVariables();
                Console.WriteLine($"Расчетные параметры:\r\n{waterSupply.VariablesToString()}");
                waterSupply.EvaluateLambdas();
                Console.WriteLine($"Коэффициенты трения:\r\n{waterSupply.LambdasToString()}");
                Console.WriteLine($"Давление в баке:\r\n{waterSupply.GetP()}\r\n");
            }
        }
    }
}
