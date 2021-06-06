using CinemaRest.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace CinemaRest.Service.DataShapes
{
    public class EditReservationRequestDTO
    {
        public Guid Id;
        public List<Seat> Seats;
    }
}