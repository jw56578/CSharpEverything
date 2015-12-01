using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace CSharpEverything
{
    /// <summary>
    /// https://msdn.microsoft.com/en-us/library/system.threading.monitor(v=vs.110).aspx
    /// http://blog.coverity.com/2014/02/12/how-does-locking-work/#.VkqSd7erSUk
    /// </summary>
    [TestClass]
    public class Locking
    {
        [TestMethod]
        public void Unlocked()
        {
            Thread obj = new Thread(DivideUnlocked);
            obj.Start();
            Thread.Sleep(1000);
            DivideUnlocked();
        }
        [TestMethod]
        public void MonitorLocked()
        {
            Thread obj = new Thread(DivideUnlocked);
            obj.Start();
            Thread.Sleep(1000);
            DivideMonitorLock();
        }
        [TestMethod]
        public void LockLocked()
        {
            Thread obj = new Thread(DivideUnlocked);
            obj.Start();
            Thread.Sleep(1000);
            DivideLockLock();
        }
        /// <summary>
        /// semaphoreslim is the same as monitor except it allows you to specify that a certain number of threads can access the code
        /// </summary>
        [TestMethod]
        public void TestSemaphoreSlim()
        {
            SemaphoreSlim ss = new SemaphoreSlim(1, 1);
            
        }
        static int num1 = 0;
        static int num2 = 0;
        static Random random = new Random();
        static readonly object _object = new object();
        /// <summary>
        /// this should break because one thread is setting num2 back to zero while another thread is still operating on it
        /// currently doesn't break though, not sure why
        /// </summary>
        static void DivideUnlocked()
        {
            for (int i = 0; i <= 999999; i++)
            {
                try
                {
                    //Choosing random numbers between 1 to 5
                    num1 = random.Next(1, 5);
                    num2 = random.Next(1, 5);
                    //Dividing
                    double ans = num1 / num2;
                    //Reset Variables
                    num2 = 0;
                    num1 = 0;
                   
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
        /// <summary>
        /// Monitor is a computer science concept for blocking threads access to things
        /// https://en.wikipedia.org/wiki/Monitor_(synchronization)
        /// all it does is make a thread not able to access any object, which then in turn makes it not be able to go further in the code
        /// </summary>
        static void DivideMonitorLock()
        {
            Monitor.Enter(_object);
            try
            {
                for (int i = 0; i <= 999999; i++)
                {
                    try
                    {
                        //Choosing random numbers between 1 to 5
                        num1 = random.Next(1, 5);
                        num2 = random.Next(1, 5);
                        //Dividing
                        double ans = num1 / num2;
                        //Reset Variables
                        num2 = 0;
                        num1 = 0;

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }
            }
            finally {
                Monitor.Exit(_object);
            }
        }
        /// <summary>
        /// the lock syntax is just sugar over the Monitor Enter/exit in a try finally block
        /// </summary>
        static void DivideLockLock()
        {
            lock(_object)
            {
                for (int i = 0; i <= 999999; i++)
                {
                    try
                    {
                        //Choosing random numbers between 1 to 5
                        num1 = random.Next(1, 5);
                        num2 = random.Next(1, 5);
                        //Dividing
                        double ans = num1 / num2;
                        //Reset Variables
                        num2 = 0;
                        num1 = 0;

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }
            }

        }
    }
}
