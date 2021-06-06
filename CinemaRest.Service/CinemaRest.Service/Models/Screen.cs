using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace CinemaRest.Service.Models
{
    public class Screen : LinkResourceBase
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public int Size { get; set; }
        public List<Seat> Seats { get; set; } = new List<Seat>();
        public LinkedList<Screening> Screenings { get; set; } = new LinkedList<Screening>();

        public Screen() { }
    }
}