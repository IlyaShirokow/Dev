﻿using KoursProject.Models.Domain;

namespace KoursProject.Models
{
    public class UpdateOrganizationsViewModel
    {
        public Guid Id { get; set; }
        public string NameOrganizations { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public LinkedList<Order> order { get; set; } = new();
    }
}
