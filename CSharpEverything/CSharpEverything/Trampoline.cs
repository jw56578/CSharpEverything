using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpEverything
{
    [TestClass]
    public class TrampolineTests
    {
        [TestMethod]
        public void Stackoverflow()
        {
            Func<int, int> funA, funB = null;
            funA = n => n == 0 ? 0 : funB(--n);
            funB = n => n == 0 ? 0 : funA(--n);
            funA(100000);

        }
        [TestMethod]
        public void Trampoline()
        {
            Func<int, TrampolineValue<int>> funA, funB = null;
            funA = (n) => n == 0
              ? new TrampolineValue<int>(0)
              : new TrampolineValue<int>(() => funB(--n));
            funB = (n) => n == 0
              ? new TrampolineValue<int>(0)
              : new TrampolineValue<int>(() => funA(--n));
            var result = CSharpEverything.Trampoline.Invoke(funA(100000));  

        }
        [TestMethod]
        public void LazyTrampoline()
        {
            Func<int, Lazy<int>> funA, funB = null;
            funA = (n) => n == 0
              ? new Lazy<int>(0)
              : new Lazy<int>(() => funB(--n));
            funB = (n) => n == 0
              ? new Lazy<int>(0)
              : new Lazy<int>(() => funA(--n));

            var result = funA(100000).Value;  
        }
    }
    public class Lazy<T>
    {
        private readonly Func<Lazy<T>> _continuation;
        private readonly T _value;

        public Lazy(T value) { _value = value; }
        public Lazy(Func<Lazy<T>> continuation) { _continuation = continuation; }

        public T Value
        {
            get
            {
                var lazy = this;
                while (lazy._continuation != null)
                {
                    lazy = lazy._continuation();
                }
                return lazy._value;
            }
        }
    }
    public class TrampolineValue<T>
    {
        public readonly T Value;
        public readonly Func<TrampolineValue<T>> Continuation;

        public TrampolineValue(T v) { Value = v; }
        public TrampolineValue(Func<TrampolineValue<T>> fn) { Continuation = fn; }
    }
    public static class Trampoline
    {
        public static T Invoke<T>(TrampolineValue<T> value)
        {
            while (value.Continuation != null)
            {
                value = value.Continuation();
            }
            return value.Value;
        }
    }

}
