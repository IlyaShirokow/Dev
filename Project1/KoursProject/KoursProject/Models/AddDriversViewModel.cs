using KoursProject.Models.Domain;

namespace KoursProject.Models
{
    public class AddDriversViewModel
    {
        public string Surname { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public DateTime DateOfBirth { get; set; }
       // public LinkedList<Order> orders { get; set; } = new();
    }
}
