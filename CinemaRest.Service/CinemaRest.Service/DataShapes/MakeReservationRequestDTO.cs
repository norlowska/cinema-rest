using CinemaRest.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace CinemaRest.Service.DataShapes
{
    public class MakeReservationRequestDTO
    {
        public Guid ScreeningId { get; set; }
        public List<Seat> Seats { get; set; }
    }
}