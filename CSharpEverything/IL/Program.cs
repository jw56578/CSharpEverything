using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using static IL.Functions;

namespace IL
{
    class Program
    {
        static int Calculate(int first, int second, int third)
        {
            var result = first * second;
            return result - third;
        }
        static int Divider(int first, int second)
        {
            return first / second;
        }
        static void Main(string[] args)
        {
            CreateInstanceOfType();
            CallInstanceMethod();
            Console.WriteLine(ILDivider(10, 2).ToString());
            Console.WriteLine(ILCalculate(1, 2, 3).ToString());
            Console.WriteLine(Loop(2).ToString());
            CallMethods();
            Console.WriteLine(CallMethodFromAnotherMethod().ToString());
            Console.WriteLine(Factorial(5));
            Console.ReadLine();
        }
     

    }
}
