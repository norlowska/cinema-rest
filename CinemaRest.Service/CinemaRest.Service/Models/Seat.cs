using System;

namespace CinemaRest.Service.Models
{
    public class Seat : LinkResourceBase
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Screen Screen { get; set; }
        public int Row { get; set; }
        public int SeatNumber { get; set; }

        public Seat() { }
    }
}