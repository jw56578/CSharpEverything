using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace CSharpEverything
{
    /// <summary>
    /// http://www.onlinebuff.com/article_understand-monitor-vs-mutex-vs-semaphore-vs-semaphoreslim-onlinebuff_60.html
    /// an example of using a mutex is when you don't want 2 instances of an application running at the same time
    /// normally you can just double click on an exe twice and the app would be running in 2 different processes
    /// none of this can actually be tested because you can' run multiple instances of Unit tests
    /// </summary>
    [TestClass]
    public class MutexTests
    {
        [TestMethod]
        public void TestMutex()
        {
            using (Mutex m1 = new Mutex(true, "MyAppLabel"))
            {
                //this will make any thread wait for 5 seconds if the app is already running to see if it stops running
                if (!m1.WaitOne(5000, false))
                { 
                    //this is what will happen when after 5 seconds another process is still running the app
                }
                

            }

        }
        /// <summary>
        /// the semephore allows you to specify that only a certain number of threads can access an area at one time
        /// </summary>
        [TestMethod]
        public void TestSemephore()
        {
            using (Semaphore m1 = new Semaphore(3,3, "MyAppLabel"))
            {
                //this will make any thread wait for 5 seconds if the app is already running to see if it stops running
                m1.WaitOne();
                //if the thread is done it can release the lock
                m1.Release();
                


            }

        }
    }
}
