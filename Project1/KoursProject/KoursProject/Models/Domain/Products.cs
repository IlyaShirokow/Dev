namespace KoursProject.Models.Domain
{
    public class Products
    {
        public Guid ID { get; set; }

        public string Product { get; set; }

        public string Fragility { get; set; }

        public string Dimension { get; set; }
        public LinkedList<Order> order { get; set; } = new();
    }
}
