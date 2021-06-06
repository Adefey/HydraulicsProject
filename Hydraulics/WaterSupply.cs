using System;

namespace Hydraulics
{
    internal class WaterSupply
    {
        //зададим извесные данные из условия
        private readonly double d1 = 0.02;
        private readonly double d2 = 0.015;
        private readonly double delta = 0.0001;
        private readonly double g = 9.8155;
        private readonly double rho = 1000;
        private readonly double elbowLoss = 1.2;
        private readonly double valveLoss = 4;
        private readonly double L = 6;
        private readonly double l = 5;
        private readonly double H = 3.2;
        private readonly double h = 1;
        private readonly double QA = 0.0005;
        //В нашей задаче 7 неизвестных: y1, y2, QB, QAB, QC, QABC, p
        private double Y1, Y2, QB, QAB, QC, QABC, p;
        //Коэффициенты трения
        private double lambdaA1, lambdaA2, lambdaB, lambdaAB, lambdaC, lambdaABC;
        //Эквивалентная длина l
        private double lEquivalent;
        //Опишем конструктор, который присваивает начальные значения коэффициентам сопротивления
        public WaterSupply()
        {
            lambdaA1 = 0.032;
            lambdaA2 = 0.033;
            //для нулевой итерации возьмем все коэффициенты сопротивления равными lambdaA1
            lambdaB = lambdaA1;
            lambdaAB = lambdaA1;
            lambdaC = lambdaA1;
            lambdaABC = lambdaA1;
            //вычислим эквивалентную длину l
            lEquivalent = l + (elbowLoss + valveLoss) * d2 / lambdaA2;
        }
        //Напишем метод для решения системы. Все формулы заранее выведены
        public void EvaluateVariables()
        {
            Y1 = 0.0827 * (lambdaA1 * H / Math.Pow(d1, 5) + lambdaA2 * lEquivalent / Math.Pow(d2, 5)) * Math.Pow(QA, 2) + H - h;
            QB = Math.Sqrt((Y1 + h) / (0.0827 * lambdaB * H / Math.Pow(d2, 5)));
            QAB = QB + QA;
            Y2 = -H + Y1 - 0.0827 * lambdaAB * H / Math.Pow(d1, 5) * Math.Pow(QAB, 2);
            QC = Math.Sqrt((Y2 + h) / (0.0827 * lambdaC * lEquivalent / Math.Pow(d2, 5)));
            QABC = QAB + QC;
            p = (Y2 + H + 0.0827 * lambdaABC * (H + L) / Math.Pow(d1, 5) * Math.Pow(QABC, 2)) * (rho * g);
        }
        //Напишем метод пересчета коэффициентов сопротивления
        public void EvaluateLambdas()
        {
            lambdaB = HydraulicUtils.EvaluateLambda(d2, QB, delta);
            lambdaAB = HydraulicUtils.EvaluateLambda(d1, QAB, delta);
            lambdaC = HydraulicUtils.EvaluateLambda(d1, QC, delta);
            lambdaABC = HydraulicUtils.EvaluateLambda(d1, QABC, delta);
        }
        //Вернуть ответ
        public double GetP()
        {
            return p;
        }

        public string VariablesToString()
        {
            return $"Y1 = {Y1}\r\nQB = {QB}\r\nQAB = {QAB}\r\nY2 = {Y2}\r\nQC = {QC}\r\nQABC = {QABC}\r\np = {p}";
        }

        public string LambdasToString()
        {
            return $"LambdaA1 = {lambdaA1}\r\nLambdaA2 = {lambdaA2}\r\nLambdaB = {lambdaB}\r\nLambdaAB = {lambdaAB}\r\nLambdaC = {lambdaC}\r\nLambdaABC = {lambdaABC}";
        }
    }
}
