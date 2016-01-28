using DDD.CoreDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;

namespace DDD.Test
{
    public class SnackMachineTest
    {
        [Fact]
        public void ReturnMoney()
        {
            var sm = new BetterSnackMachine();
            sm.InsertMoney(new Money(9, 3, 3,1,1,1));
          

        }
    }
}
