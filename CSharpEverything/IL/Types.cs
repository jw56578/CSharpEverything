using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace IL
{
    public static partial class Functions
    {
        public static void CallInstanceMethod()
        {
            //Regex r = new Regex();
            //r.Match();

            var callingMethod = new DynamicMethod("CallInstanceMethod", typeof(Match), new[] { typeof(string), typeof(string) }, typeof(Program).Module);
            var il = callingMethod.GetILGenerator();
            //load the string argument onto the stack to be sent into the regex constructor
            il.Emit(OpCodes.Ldarg_0);
            //this will call the constructor and then put the new object instance on the stack
            il.Emit(OpCodes.Newobj, typeof(Regex).GetConstructor(new Type[] { typeof(string) }));
            //load the string to match, there are now 2 things on the stack the instance of "this" and a string to match
            il.Emit(OpCodes.Ldarg_1);
            //when you call an instance method you need to have the instance of the type on the stack followed by any arguments
            //calling the instance method will clear the stack of the instance of "this" and the arguments and put the return value on the stack
            il.Emit(OpCodes.Call, typeof(Regex).GetMethod("Match", new Type[] { typeof(string) }));
            // now an instance of a Match object is on the stack and that is what we are expected to return so we can call Ret 
            //if anything but an instance of a Match object was on the stack and you called Ret an exception would occur
            //in general if anything but the expected return type is on the stack when you call return an exception will occur
            il.Emit(OpCodes.Ret);
            var method = (Func<string, string, Match>)callingMethod.CreateDelegate(typeof(Func<string,string, Match>));
            var match = method("hello","world");

        }
        public static void CreateInstanceOfType()
        {
            var callingMethod = new DynamicMethod("CreateInstanceOfType", typeof(TestTypeToReturn),
                Type.EmptyTypes, typeof(Program).Module);
            var il = callingMethod.GetILGenerator();
            il.Emit(OpCodes.Newobj, typeof(TestTypeToReturn).GetConstructor(Type.EmptyTypes));
            il.Emit(OpCodes.Ret);
            var method = (Func<TestTypeToReturn>)callingMethod.CreateDelegate(typeof(Func<TestTypeToReturn>));
            var match = method();
            var fieldValue = match.MyField;

        }

        public class TestTypeToReturn
        {
            public string MyField { get; set; }
            public TestTypeToReturn(string fieldValue)
            {

            }
            public TestTypeToReturn()
            {
                MyField = "empty constructor";
            }
        }
    }
}
