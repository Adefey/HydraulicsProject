using System;

namespace Hydraulics
{
    internal static class HydraulicUtils
    {
        //опишем метод вычисления коэффициента трения, этот коэффициент зависит от диаметра трубы и от расхода
        public static double EvaluateLambda(double d, double Q, double delta)
        {
            double v = Q / (Math.PI * Math.Pow(d, 2) / 4);
            double Re = (v * d) / (Math.Pow(10, -6));
            return 0.1 * Math.Pow((1.46 * delta) / d + 100 / Re, 0.25);
        }

        public static double EvaluateVelocity(double d, double Q)
        {
            return Q / (Math.PI * Math.Pow(d, 2) / 4);
        }

        public static double EvaluateRenolds(double d, double v)
        {
            return (v * d) / (Math.Pow(10, -6));
        }

    }
}
