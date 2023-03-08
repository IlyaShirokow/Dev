using KoursProject.Models.Domain;

namespace KoursProject.Models
{
    public class AddOrderViewModel
    { 
        public Guid ProductsID { get; set; }
        public Products? Products { get; set; }
        public Guid AutosID { get; set; }
        public Autos? Autos { get; set; }
        public Guid DriversId { get; set; }
        public Drivers? Drivers { get; set; }
        public Guid OrganizationsId { get; set; }
        public Organizations? Organizations { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime Data { get; set; }
        public string Email { get; set; }
        public Guid InvoicesId { get; set; }
        public Invoices? Invoices { get; set; }
    }
}
