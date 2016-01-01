using Data;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View;
using View.Models;

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
            var service = new DataService<Person>();
            List<Person> people = new List<Person>();
            service.Fill(people);
            foreach (var person in people) {
                Console.WriteLine(person.FirstName);
            }
        }
    }
    public class VehicleDetailCommand : ICommand
    {
        public void Execute()
        {
            var ms = new ModelService<VehicleDetailModel>();
            var vd = ms.Get(new ModelServiceArgs() { Id=1});
        }
    }

}
