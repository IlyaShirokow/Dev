namespace Kours.Domain.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int ProductsID { get; set; }
        public Products? Products { get; set; }
        public int AutosID { get; set; }
        public Autos? Autos { get; set; }
        public int DriversId { get; set; }
        public Drivers? Drivers { get; set; }
        public int OrganizationsId { get; set; }
        public Organizations? Organizations { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime Data { get; set; }
        public string Email { get; set; }
        public int InvoicesId { get; set; }
        public Invoices? Invoices { get; set; }
    }
}
