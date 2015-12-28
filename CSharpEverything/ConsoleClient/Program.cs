using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = new Application();
            app.Run();
           
            Console.WriteLine("Test");
            Console.WriteLine("Test");
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            ClearCurrentConsoleLine();
            Console.ReadLine();

        }
        public static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }
    }

    public class Application
    {
        public void Run()
        {
            var ui = new UserInterface();
            //doing something like this is intuative with software because this is how a computer works
            //in order to keep a program going you have to create an infinite loop so that it doesn't exit.
            while (ui.TakeInput())
            {

            }
        }
    }



}
