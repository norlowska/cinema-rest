using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace CinemaRest.Service.Models
{
    public class Character : LinkResourceBase
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string CharacterName { get; set; }
        public Actor Actor { get; set; }
        public Guid MovieId { get; set; }
        public bool Deleted { get; set; } = false;

        public Character() { }
    }
}