using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HowToBuildANewSystemFromScratch.Types.Commands
{
    /// <summary>
    /// The issues with the command pattern is that each command has to be self contained and have everything it needs to work
    /// It cannot return anything nor take anything
    /// Otherwise how could you standardize/generalize what a command interface would take in and return
    /// </summary>
    public abstract class Command
    {
    }
    public interface ICommand
    {
        void Execute();
    }
}
