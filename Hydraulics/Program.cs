using System;

namespace Hydraulics
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            WaterSupply ws = new WaterSupply();

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Итерация №{i}");
                ws.EvaluateVariables();
                Console.WriteLine($"Расчетные параметры:\r\n{ws.VariablesToString()}");
                ws.EvaluateLambdas();
                Console.WriteLine($"Коэффициенты трения:\r\n{ws.LambdasToString()}");
                Console.WriteLine($"Давление в баке:\r\n{ws.GetP()}\r\n");
            }
        }
    }
}
