using CinemaRest.Service.DataShapes;
using CinemaRest.Service.Enums;
using CinemaRest.Service.Models;
using Microsoft.AspNetCore.Http;
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
        private const string ENDPOINT = "/api/reservation";
        private const string REL_DELETE = "delete_reservation";
        private const string REL_UPDATE = "update_reservation";
        private const string REL_CREATE = "create_reservatation";
        private const string REL_GET_ALL = "get_reservations";
        private const string REL_SELF = "self";
        private string HOST = string.Empty;

        public ReservationController(ICinemaContext context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult MakeReservation([FromBody] MakeReservationRequestDTO editedReservation)
        {
            try
            {
                HOST = HttpContext.Request.Scheme + "://" + HttpContext.Request.Host;
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
                HOST = HttpContext.Request.Scheme + "://" + HttpContext.Request.Host;
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
            HOST = HttpContext.Request.Scheme + "://" + HttpContext.Request.Host;
            User user = ExtensionMethods.DeepClone<User>(Models.User.GetByEmail((CinemaContext)_context, email));
            if (user == null) return null;
            foreach (var r in user.Reservations)
            {
                r.User = null;
                r.Screening.Movie.Characters = null;
                r.Screening.Movie.Crew = null;
                r.Screening.Screen.Seats = null;
                r.Screening.FreeSeats = null;
                r.Links = GetLinks(r.Id, REL_GET_ALL);
            }
            return user.Reservations;
        }

        [HttpDelete("{id}")]
        public bool CancelReservation([FromRoute] Guid id)
        {
            HOST = HttpContext.Request.Scheme + "://" + HttpContext.Request.Host;
            Reservation reservation = Reservation.GetById((CinemaContext)_context, id);
            if (reservation != null)
            {
                reservation.Links = GetLinks(id, REL_DELETE);
                return reservation.cancelReservation((CinemaContext)_context);
            }
            return false;
        }

        private List<Link> GetLinks(Guid id, string self)
        {
            string url = HOST + ENDPOINT + "/";
            return new List<Link>()
                {
                    new Link()
                    {
                        Method=HttpMethodEnum.GET.ToString(),
                        Rel= self == REL_GET_ALL ? REL_SELF : REL_GET_ALL,
                        Href= url + id
                    },
                    new Link()
                    {
                        Method=HttpMethodEnum.POST.ToString(),
                        Rel= self == REL_CREATE ? REL_SELF : REL_CREATE,
                        Href= url
                    },
                    new Link()
                    {
                        Method=HttpMethodEnum.PUT.ToString(),
                        Rel= self == REL_UPDATE ? REL_SELF : REL_UPDATE,
                        Href= url + id
                    },
                    new Link()
                    {
                        Method=HttpMethodEnum.DELETE.ToString(),
                        Rel=self == REL_DELETE ? REL_SELF : REL_DELETE,
                        Href= url + id
                    },
                };
        }
    }
}
