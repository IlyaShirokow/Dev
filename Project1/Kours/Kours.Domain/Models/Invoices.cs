using Kours.Domain.Models;

namespace Kours.Domain
{
    public class Invoices
    {
        public int Id { get; set; }
        public string InvoiceType { get; set; }

        public string Descrption { get; set; }
       // public LinkedList<Order> order { get; set; } = new();
    }
}
