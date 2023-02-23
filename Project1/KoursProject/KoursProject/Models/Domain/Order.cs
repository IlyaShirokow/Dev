namespace KoursProject.Models.Domain
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid ProductID { get; set; }
        public Products? Products { get; set; }
        public Guid AutoID { get; set; }
        public Autos? Autos { get; set; }
        public Guid DriverId { get; set; }
        public Drivers? Drivers { get; set; }
        public Guid OrganizationsId { get; set; }
        public Organizations? Organizations { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime Data { get; set; }
        public string Email { get; set; }
        public Invoices? Invoices { get; set; }

    }
}
