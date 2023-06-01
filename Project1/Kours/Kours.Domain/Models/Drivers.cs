using Kours.Domain.Models;

namespace Kours.Domain
{
    public class Drivers
    {
        public int Id { get; set; }
        public string Surname { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public DateTime DateOfBirth { get; set; }
      //  public LinkedList<Order> orders { get; set; } = new();
    }
}
