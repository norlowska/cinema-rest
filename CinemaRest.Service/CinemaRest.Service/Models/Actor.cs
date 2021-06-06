using System;
using System.Linq;
using System.Runtime.Serialization;

namespace CinemaRest.Service.Models
{
    public class Actor : LinkResourceBase
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public bool Deleted { get; set; } = false;
        public string FullName { get { return FirstName + " " + LastName; } }

        public Actor() { }
       
        public static Actor GetById(Guid id)
        {
            return CinemaContext.GetContext().Actors.Where(item => item.Id == id).FirstOrDefault();
        }
    }
}