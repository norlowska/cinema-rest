using CinemaRest.Service.Enums;
using System;

namespace CinemaRest.Service.Models
{
    public class CrewMember : LinkResourceBase
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string Job { get; set; }
        public bool Deleted { get; set; } = false; 
        public Guid MovieId { get; set; }

        public CrewMember() { }
    }
}
