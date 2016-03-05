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
        public static int Loop(int x)
        {
            //var result = 0;
            //for (int i = 0; i < 10; i++)
            //{
            //    result += i * x;
            //}
            //return result;

            //the code of above in IL
            var loop = new DynamicMethod("Loop", typeof(int), new[] { typeof(int) }, typeof(Program).Module);

            var il = loop.GetILGenerator();
            //this is just what you do when you are going to have "GOTO" statements and need a label to tell it where to "GOTO"
            var loopStart = il.DefineLabel();
            var methodEnd = il.DefineLabel();

            //we have a local variable called result, in IL you don't name variables, they are just indexes in the local variable stack
            il.DeclareLocal(typeof(int));
            //you have to put the value on the stack first, you can't just put it directly in the local variable, this is the direct constant of 0 
            il.Emit(OpCodes.Ldc_I4_0);
            //now store the 0 in the local variable of index 0
            il.Emit(OpCodes.Stloc_0);

            //now make the variable for the "i" of the loop
            //you can thing of this as adding another storage location to an array, there was 1 spot, now there are 2 spots
            il.DeclareLocal(typeof(int));
            //again you can't just put things in local variables you have to put them on the stack first
            il.Emit(OpCodes.Ldc_I4_0);
            //put 0 in the index of 1 as being the second variable
            il.Emit(OpCodes.Stloc_1);

            //we are starting the for loop so we need to mark where it starts in order to go back to it, this is just how you do this
            il.MarkLabel(loopStart);

            //now we are checking whether i is greater or equal to 10 in order to return out
            il.Emit(OpCodes.Ldloc_1);
            //there is no constant for 9 or above so this is how you load every other number
            il.Emit(OpCodes.Ldc_I4, 10);
            il.Emit(OpCodes.Bge, methodEnd);

            //now do the first operation in the loop. i * x
            //load the variable i from the local stack to the evaluation stack
            il.Emit(OpCodes.Ldloc_1);
            //load the method parameter x on the stack
            il.Emit(OpCodes.Ldarg_0);
            //multiply the two values and remove them from stack and add the result to the stack
            il.Emit(OpCodes.Mul);

            //now add the value to the variable result and store back into result
            //load the result variable onto the stack
            il.Emit(OpCodes.Ldloc_0);
            //now the value from result and the value from the multiplication are next to each other, do an Add
            il.Emit(OpCodes.Add);
            //now store the value back into the result variable
            il.Emit(OpCodes.Stloc_0);

            //now the loop is done and we need to increment the variable i
            //put i on the stack
            il.Emit(OpCodes.Ldloc_1);
            //put the number 1 on the stack
            il.Emit(OpCodes.Ldc_I4_1);
            //add them together which removes them from stack and put new result on stack
            il.Emit(OpCodes.Add);
            //store result back into i
            il.Emit(OpCodes.Stloc_1);

            //go back to beginnings of the loop
            il.Emit(OpCodes.Br, loopStart);

            il.MarkLabel(methodEnd);
            il.Emit(OpCodes.Ldloc_0);
            il.Emit(OpCodes.Ret);

            var method = (Func<int, int>)loop.CreateDelegate(typeof(Func<int, int>));
            return method(x);

        }
    }
}
