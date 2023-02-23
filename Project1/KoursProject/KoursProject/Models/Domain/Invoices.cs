namespace KoursProject.Models.Domain
{
    public class Invoices
    {
        public Guid ID { get; set; }
        public string InvoiceType { get; set; }

        public string Descrption { get; set; }
        public LinkedList<Order> order { get; set; } = new();
    }
}
