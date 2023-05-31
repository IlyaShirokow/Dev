using Kours.Domain.Models;

namespace Kours.Domain
{
    public class Products
    {
        public int Id { get; set; }

        public string Product { get; set; }

        public string Fragility { get; set; }

        public string Dimension { get; set; }
        public LinkedList<Order> order { get; set; } = new();
    }
}
