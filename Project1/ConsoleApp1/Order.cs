using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order
{
    public class Order
    {
        public int ID { get; set; }
        public int IDProducts { get; set; }
        public int IDAuto { get; set; }
        public int IDStaff { get; set; }
        public int IDAddress { get; set; }
        public int IDOrganizations { get; set; }
        public string PhoneNumber { get; set; }
        public string? Email { get; set; }
        public int IDInvoice { get; set; }
    }
}