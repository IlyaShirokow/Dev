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
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int AutoId { get; set; }
        public int StaffId { get; set; }
        public int AddressId { get; set; }
        public int OrganizationsId { get; set; }
        public string PhoneNumber { get; set; }
        public string? Email { get; set; }
        public int InvoiceId { get; set; }
    }
}