using Data;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View.Models
{
    public class VehicleDetailModel:BaseModel
    {
        public Person Person { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
