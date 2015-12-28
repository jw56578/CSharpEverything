using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleClient
{
    public class UserInterface
    {
        public InputService inputService = new InputService();
        public bool TakeInput()
        {
            string command = Console.ReadLine();

            if (command == "exit")
                return false;

            inputService.Take(command);
            return true;
        }
    }
    public class InputService
    {
        Dictionary<string, ICommand> commands = new Dictionary<string, ICommand>();
        public InputService()
        {
            commands.Add("people", new ListPeopleCommand());


        }
        public void Take(string input)
        {
            ICommand cmd;
            if (commands.TryGetValue(input, out cmd))
            {
                cmd.Execute();
            }

        }

    }
    public interface ICommand
    {
        void Execute();
    }
    public class ListPeopleCommand : ICommand
    {
        public void Execute()
        {
            //var ds = new ArrayDataService<Person>();
            //var people = ds.Get();
            //foreach (var p in people)
            //{
            //    Console.WriteLine(p.FirstName);
            //}
        }
    }

}
