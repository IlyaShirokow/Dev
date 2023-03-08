using KoursProject.Models.Domain;

namespace KoursProject.Models
{
    public class UpdateProductsViewModel
    {
        public Guid Id { get; set; }

        public string Product { get; set; }

        public string Fragility { get; set; }

        public string Dimension { get; set; }
        //public LinkedList<Order> order { get; set; } = new();
    }
}
