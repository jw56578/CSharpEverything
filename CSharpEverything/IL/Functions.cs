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
        public static int CallMethodFromAnotherMethod()
        {
            //just like in any other code, you want to seperate things out into different methods for better organization

            var myMethod = new DynamicMethod("MultiplyMethodBeingCalled", typeof(int), new[] { typeof(int) }, typeof(Program).Module);
            var il = myMethod.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldc_I4, 42);
            il.Emit(OpCodes.Mul);
            il.Emit(OpCodes.Ret);

            var callingMethod = new DynamicMethod("CallingMethod", typeof(int), new[] { typeof(int), typeof(int) }, typeof(Program).Module);
            il = callingMethod.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldarg_1);
            il.Emit(OpCodes.Mul);
            //again, last value on stack automatically gets sent into method call
            il.Emit(OpCodes.Call, myMethod);
            il.Emit(OpCodes.Ret);


            var method = (Func<int, int, int>)callingMethod.CreateDelegate(typeof(Func<int, int, int>));
            return method(100, 100);

        }
        public static void CallMethods()
        {
            var myMethod = new DynamicMethod("MyMethod", typeof(void), null, typeof(Program).Module);
            var il = myMethod.GetILGenerator();
            il.Emit(OpCodes.Ldc_I4, 42);
            //when you put a value on the stack and then call a method, those value automatically become the parameteres of the method
            il.Emit(OpCodes.Call, typeof(Functions).GetMethod("Print"));
            il.Emit(OpCodes.Ret);

            var method = (Action)myMethod.CreateDelegate(typeof(Action));
            method();

        }
        public static void Print(int i)
        {
            Console.WriteLine("The Value passed tot PRint is {0}", i);
        }

        delegate int DivideDelegate(int a, int b);

        public static int ILDivider(int one, int two)
        {
            var divMethod = new DynamicMethod("DivideMethod", //name of method
                 typeof(int), //return type
                 new[] { typeof(int), typeof(int) },//parameters
                 typeof(Program).Module); //the module it lives in, remember these things called modules exist, even though you cannot make them in Visual Studio so nobody knows about them
            var il = divMethod.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);//take the first argument to the method and loads it to the top of the evaluation stack
            il.Emit(OpCodes.Ldarg_1);//load second argument to the top of eval stack
            il.Emit(OpCodes.Div);// this will remove the last 2 values on the stack and divide them and then put the result on top of the stack
            il.Emit(OpCodes.Ret);


            //first way to call dynamic method
            var result = divMethod.Invoke(
                //we are not invoking the method in the context of an instance of an object so it can be null, therefore you could not use "this" in the method
                null,
                //an array of the arguments you are sending into the method
                new object[] { one, two });

            //second way to call dynamic method
            var method = (DivideDelegate)divMethod.CreateDelegate(typeof(DivideDelegate));

            result = method(one, two);

            return (int)result;

        }
        public static int ILCalculate(int one, int two, int three)
        {
            //this is the IL version of the method Program.Calculate
            var calcMethod = new DynamicMethod("CalcMethod", //name of method
                typeof(int), //return type
                new[] { typeof(int), typeof(int), typeof(int) },//parameters
                typeof(Program).Module); //the module it lives in, remember these things called modules exist, even though you cannot make them in Visual Studio so nobody knows about them

            var il = calcMethod.GetILGenerator();
            //if you are going to store a local variable at any point in execution like Ldloc_x, then you have to call this to setup a place for the local variable
            il.DeclareLocal(typeof(int));
            il.Emit(OpCodes.Ldarg_0); // loads the first argument of the method into the evaluation stack, THE STACK
            il.Emit(OpCodes.Ldarg_1); // load second argument onto stack
            il.Emit(OpCodes.Mul); //take the 2 latest values that are on the stack (removing them) multiply them and put the result back on the stack
            //now the result of parameter 1 * paramter 2 is sitting on the stack
            //put the value on the stack into a local variable
            il.Emit(OpCodes.Stloc_0); //this takes the last value on the stack and removes it and puts it into local storage, not sure how you know to use 0 index at this point?
            //now take the value stored in local variable and put it back on the stack, yes this is weird but it is just what you do
            il.Emit(OpCodes.Ldloc_0); //this loads the local variable from location zero and pushes it onto the stack, it does not remove it from local variable
            il.Emit(OpCodes.Ldarg_2);
            il.Emit(OpCodes.Sub);
            il.Emit(OpCodes.Ret);

            var method = (Func<int, int, int, int>)calcMethod.CreateDelegate(typeof(Func<int, int, int, int>));
            return method(one, two, three);
        }
    }
}
