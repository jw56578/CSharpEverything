using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace CSharpEverything
{
    [TestClass]
    public class IQueryableTutorial
    {
        [TestMethod]
        public void WhatDoesIQueryableDo()
        {
            List<int> numbers = new List<int> { 1, 2, 4, 5, 6, 7, 8 };
            //this will not work because a List is not IQueryable
            //if you look at the Where extension method, it only takes an IQueryable
            //var result = from x in queryablenumbers
            //             where x > 0
            //             select x * x;

            var queryablenumbers = numbers.AsQueryable();
            var result = from x in queryablenumbers
                         where x > 0
                         select x * x;

            result = queryablenumbers.Where(n => n > 0);

           


        }
    }
}
