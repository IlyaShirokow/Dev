using KoursProject.Models.Domain;

namespace KoursProject.Models
{
    public class UpdateOrderViewModel
    {
        public Guid Id { get; set; }
        public Guid ProductsID { get; set; }
        public Guid AutosID { get; set; }
        public Guid DriversId { get; set; }
        public Guid OrganizationsId { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime Data { get; set; }
        public string Email { get; set; }
        public Guid InvoicesId { get; set; }
    }
}
