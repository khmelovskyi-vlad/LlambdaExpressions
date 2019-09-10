using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LlambdaExpressions
{
    class Delegates
    {
        public int Sum(int num1, int num2)
        {
            return num1 + num2;
        }
        public int BigSum(int num1, string num2, double num3)
        {
            return num1 + Convert.ToInt32(num2) + Convert.ToInt32(num3);
        }
        public int Multiply(int num1, int num2)
        {
            return num1 * num2;
        }
        public int BigMultiply(int num1, string num2, double num3)
        {
            return num1 * Convert.ToInt32(num2) * Convert.ToInt32(num3);
        }
        public (int answer1, int answer2) SumAndMoltiply(int num1, double num2)
        {
             return (num1 + Convert.ToInt32(num2), num1 * Convert.ToInt32(num2));
        }
        public int SumOrMoltiply(int num1, double num2, bool sum)
        {
            if (sum)
            {
                return num1 + Convert.ToInt32(num2);
            }
            else
            {
                return num1 * Convert.ToInt32(num2);
            }
        }
    }
    public delegate int SumMultiply(int num, int num2);
    public delegate int BigSumBigMultiply(int num, string num2, double num3);
    public delegate (int answer1, int answer2) SumAndMultiply(int num, double num2);
    public delegate int SumOrMultiply(int num, double num2, bool sum);
}
