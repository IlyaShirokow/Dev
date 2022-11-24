using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Address
{
    public class Address
    {
        public int IDAddress { get; set; }
        public string Adddress { get; set; }
        public int NumberOfOrdersAtTheAdderess { get; set; }
    }
}