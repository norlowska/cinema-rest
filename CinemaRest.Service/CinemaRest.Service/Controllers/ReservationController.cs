using CinemaRest.Service.DataShapes;
using CinemaRest.Service.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CinemaRest.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [HeaderAuthorizationBasic]
    public class ReservationController : ControllerBase
    {
        private readonly ICinemaContext _context;
        public ReservationController(ICinemaContext context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult MakeReservation([FromBody] MakeReservationRequestDTO editedReservation)
        {
            try
            {
                Screening screening = Screening.GetById((CinemaContext)_context, editedReservation.ScreeningId);
                if (screening == null) return Problem("Nie znaleziono seansu");
                Reservation reservation = Reservation.MakeReservation((CinemaContext)_context, screening, editedReservation.Seats, "");
                if (reservation == null)
                    return Problem("Wybrane miejsca są zajęte");
                byte[] pdfBytes = reservation.preparePDF();
                if (pdfBytes == null)
                    return Problem("Wystąpił błąd podczas generowania potwierdzenia rezerwacji.");
                return new FileContentResult(pdfBytes, "application/pdf")
                {
                    FileDownloadName = reservation.Id.ToString() + ".pdf"
                };
            }
            catch (Exception ex)
            {
                    return Problem("Wystąpił błąd podczas rezerwowania miejsc. " + ex.Message);
            }
        }

        [HttpPut("{reservationId}")]
        public ActionResult EditReservation([FromRoute] Guid reservationId, [FromBody] List<Seat> seats)
        {
            try
            {
                Reservation reservation = Reservation.EditReservation((CinemaContext)_context, reservationId, seats);
                if (reservation == null)
                    return Problem("Nie znaleziono rezerwacji.");
                byte[] pdfBytes = reservation.preparePDF();
                
                if (pdfBytes == null) return Problem("Wystąpił błąd podczas generowania potwierdzenia rezerwacji.");
                return new FileContentResult(pdfBytes, "application/pdf")
                {
                    FileDownloadName = reservation.Id.ToString() + ".pdf"
                };
            }
            catch (Exception ex)
            {
                return Problem("Wystąpił błąd podczas aktualizacji rezerwacji. " + ex.Message);
            }
        }

        [HttpGet]
        public List<Reservation> GetReservationList([FromQuery] String email)
        {
            User user = ExtensionMethods.DeepClone<User>(Models.User.GetByEmail((CinemaContext)_context, email));
            if (user == null) return null;
            foreach (var r in user.Reservations)
            {
                r.User = null;
                r.Screening.Movie.Characters = null;
                r.Screening.Movie.Crew = null;
                r.Screening.Screen.Seats = null;
            }
            return user.Reservations;
        }

        [HttpDelete("{id}")]
        public bool CancelReservation([FromRoute] Guid id)
        {
            Reservation reservation = Reservation.GetById((CinemaContext)_context, id);
            if (reservation != null)
                return reservation.cancelReservation((CinemaContext)_context);
            return false;
        }
    }
}
