using Kours.Domain.Models;

namespace Kours.Domain
{
    public class Organizations
    {
        public int Id { get; set; }
        public string NameOrganizations { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
      //  public LinkedList<Order> order { get; set; } = new();
    }
}
