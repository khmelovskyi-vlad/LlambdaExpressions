using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LlambdaExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            Delegates delegates = new Delegates();

            SumMultiply sum = new SumMultiply(delegates.Sum);
            SumMultiply multiply = new SumMultiply(delegates.Multiply);
            SumMultiply sumMultiply = sum + multiply;
            var varSumMultiply = sumMultiply(2, 3);
            Console.WriteLine("Realization varSumMultiply without foreach");
            Console.WriteLine(varSumMultiply);
            SumMultiply[] varSumMultiplyArray = { sum, multiply };
            Console.WriteLine("Realization varSumMultiply");
            foreach (var operation in varSumMultiplyArray)
            {
                Console.WriteLine(operation(2,3));
            }

            BigSumBigMultiply bigSum = new BigSumBigMultiply(delegates.BigSum);
            BigSumBigMultiply bigMultiply = new BigSumBigMultiply(delegates.BigMultiply);
            BigSumBigMultiply bigSumBigMultiply = bigSum + bigMultiply;
            var varBigSumBigMultiply = bigSumBigMultiply(3, "4", 5);
            Console.WriteLine("Realization varBigSumBigMultiplyArray");
            Console.WriteLine(varBigSumBigMultiply);
            BigSumBigMultiply[] varBigSumBigMultiplyArray = { bigSum, bigMultiply };
            Console.WriteLine("Realization varBigSumBigMultiplyArray");
            foreach (var operation in varBigSumBigMultiplyArray)
            {
                Console.WriteLine(operation(3, "4", 5));
            }

            SumAndMultiply sumAndMultiply = new SumAndMultiply(delegates.SumAndMoltiply);
            Console.WriteLine("Realization sumAndMultiply without var() form");
            Console.WriteLine(sumAndMultiply(3, 5));
            var (sumSumAndMultiplyum, multiplySumSumAndMultiplyum) = sumAndMultiply(100, 5);
            Console.WriteLine("Realization sumAndMultiply");
            Console.WriteLine($"sum = {sumSumAndMultiplyum}, multiply = {multiplySumSumAndMultiplyum}");

            SumOrMultiply sumOrMultiply1 = delegate(int num1, double num2, bool or) { return num1 + Convert.ToInt32(num2); };
            SumOrMultiply sumOrMultiply2 = (num1, num2, or) => { return num1 + Convert.ToInt32(num2); };
            SumOrMultiply sumOrMultiply3 = (num1, num2, or) => (num1 + Convert.ToInt32(num2));
            var varSumOrMultiply1 = sumOrMultiply1(1,2,true);
            var varSumOrMultiply2 = sumOrMultiply2(1, 2, true);
            var varSumOrMultiply3 = sumOrMultiply3(1, 2, true);
            Console.WriteLine("Realization lambda expressions 1-3");
            Console.WriteLine($"var1 = {varSumOrMultiply1}, var2 = {varSumOrMultiply2}, var 3 = {varSumOrMultiply3}");
            
            SumOrMultiply sumOrMultiply4 = delegate (int num1, double num2, bool or) { if (or) { return num1 + Convert.ToInt32(num2); } else return num1 * Convert.ToInt32(num2); };
            SumOrMultiply sumOrMultiply5 = (num1, num2, or) => { if (or) { return num1 + Convert.ToInt32(num2); } else return num1 * Convert.ToInt32(num2); };
            SumOrMultiply sumOrMultiply6 = (num1, num2, or) => (num1 + Convert.ToInt32(num2));
            var varSumOrMultiply4 = sumOrMultiply4(10, 2, false);
            var varSumOrMultiply5 = sumOrMultiply5(10, 2, false);
            var varSumOrMultiply6 = sumOrMultiply6(10, 2, false);
            Console.WriteLine("Realization lambda expressions 4-6");
            Console.WriteLine($"var4 = {varSumOrMultiply4}, var5 = {varSumOrMultiply5}, var 6 = {varSumOrMultiply6}");

            Func<int, double, bool, int> func1 = (num1, num2, or) => (num1 + Convert.ToInt32(num2));
            var varFunc1 = func1(3, 2, true);
            Console.WriteLine("Realization Func func1");
            Console.WriteLine(varFunc1);

            Func<int, int, int, (int, int)> func2 = null;
            Action action = null;
            Console.WriteLine("Realization Action action, Func func2 without instance");
            for (int i = 0; i < 5; i++)
            {
                action += () => Console.WriteLine(i);
                func2 += (num1, num2, num3) => (num1 + num2 + num3, i);
                Console.WriteLine(func2(1,2,3));
            }
            action();
            Console.WriteLine(func2(1, 2, 3));

            Action action2 = null;
            Console.WriteLine("Realization Action action2");
            for (int i = 10; i < 15; i++)
            {
                var f = i;
                action2 += () => Console.WriteLine(f);
            }
            action2();

            Console.ReadKey();

        }
    }
}
