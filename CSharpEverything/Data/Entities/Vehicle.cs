using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Vehicle : BaseEntity
    {
        public string Make { get; set; }
        public string Model { get; set; }

    }
}
