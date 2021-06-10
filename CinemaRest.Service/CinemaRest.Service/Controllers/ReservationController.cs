using CinemaRest.Service.DataShapes;
using CinemaRest.Service.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CinemaRest.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
    }
}
