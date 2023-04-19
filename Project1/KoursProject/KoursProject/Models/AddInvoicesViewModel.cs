using KoursProject.Models.Domain;

namespace KoursProject.Models
{
    public class AddInvoicesViewModel
    {
        public string InvoiceType { get; set; }

        public string Descrption { get; set; }
        public LinkedList<Order> order { get; set; } = new();
    }
}
