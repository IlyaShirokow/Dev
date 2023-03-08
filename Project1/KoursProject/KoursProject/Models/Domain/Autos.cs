namespace KoursProject.Models.Domain
{
    public class Autos
    {
        public Guid Id { get; set; }
        public string Car { get; set; }
        public string Carnumber { get; set; }
        public string Condition { get; set; }
        public LinkedList<Order> orders { get; set; } = new();
    }
}
