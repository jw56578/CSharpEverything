using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace IL
{
    public static partial class Functions
    {
        public static int Factorial(int i)
        {
            //how to do recursion in IL
            // in c#
            //if (i == 1) return i;
            //return i * Factorial(i -1);

            var factorial = new DynamicMethod("Factorial", typeof(int), new[] { typeof(int) }, typeof(Program).Module);
            var il = factorial.GetILGenerator();
            var methodEnd = il.DefineLabel();
            //load the argument in
            il.Emit(OpCodes.Ldarg_0);
            //we are loading the argument twice because after we do the comparison which removes the values from the stack, we still need the argument to be on the stack in order to do stuff with it
            //we could just load it after the comparison, but i don't know what it matters either way, just showing another way to do it to expand my  mind
            il.Emit(OpCodes.Ldarg_0);
            //load in the number 1 in order to compare to
            il.Emit(OpCodes.Ldc_I4_1);
            //this compares the last 2 values on the stack and if they are equal it jumps to the label
            il.Emit(OpCodes.Beq, methodEnd);
            //load up the constant of 1 that you are subtracting from the argumnt
            il.Emit(OpCodes.Ldc_I4_1);
            //subtract 1 from the value right before it
            il.Emit(OpCodes.Sub);
            //the result of Sub is now at top of stack ready to be sent into whatever method is called next
            //so call the method itself to do the recursion
            il.Emit(OpCodes.Call, factorial);
            //now the result of this method is on top of the stack ready to be muliplied by i
            //load i from arguments
            il.Emit(OpCodes.Ldarg_0);
            //multiply 
            il.Emit(OpCodes.Mul);
            //this is the label of returning out of the method which things can jump to 
            il.MarkLabel(methodEnd);
            il.Emit(OpCodes.Ret);


            var method = (Func<int, int>)factorial.CreateDelegate(typeof(Func<int, int>));
            return method(5);


        }
    }
}
