using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace CinemaRest.Service.Models
{
    public class Screening : LinkResourceBase
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Movie Movie { get; set; }
        public string Date { get; set; } 
        public string Time { get; set; }
        public DateTime FullDate { get; set; }  
        public Screen Screen { get; set; }
        public List<Seat> ReservedSeats { get; set; }
        

        private List<Seat> _freeSeats;
        public List<Seat> FreeSeats
        {
            get
            {
                return Screen.Seats != null ? Screen.Seats.Where(item => ReservedSeats.All(i => i.Id != item.Id)).ToList() : null ;
            }
            set
            {
                _freeSeats = value;
            }
        }
        public bool Deleted { get; set; } = false;

        public Screening() { }

        public Screening(Guid id, DateTime date, Movie movie, Screen screen)
        {
            this.Id = id;
            FullDate = date;
            this.Date = getDate();
            Time = getTime();
            this.Movie = ExtensionMethods.DeepClone<Movie>(movie);
            this.Screen = screen;
        }

        public void SetReservedSeats(CinemaContext dc)
        {
            this.ReservedSeats = dc.Reservations.Where(item => item.Screening.Id == this.Id).SelectMany(item => item.Seats).ToList();
        }

        public string getDate()
        {
            return FullDate.ToString("yyyy-MM-dd");
        }

        public string getTime()
        {
            return FullDate.ToString("HH:mm");
        }

        public static Screening GetById(CinemaContext dc, Guid id)
        {
            return dc.Screenings.Where(item => item.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// Sprawdzenie czy wybrane miejsca na seans istnieją i są zarezerwowane
        /// </summary>
        /// <param name="reservedSeats"></param>
        /// <param name="chosenSeats"></param>
        /// <returns>Prawda, jeśli którekolwiek z miejsc jest już zarezerwowane</returns>
        public bool checkSeats(List<Seat> chosenSeats)
        {
            return chosenSeats.Any(item => !Screen.Seats.Exists(i => i.Row == item.Row && i.SeatNumber == item.SeatNumber) || this.ReservedSeats.Any(i => i.Row == item.Row && i.SeatNumber == item.SeatNumber));
        }

        /// <summary>
        /// Sprawdzenie czy wybrane miejsca na seans istnieją i są zarezerwowane (przez kogoś innego niż rezerwujący użytkownik)
        /// </summary>
        /// <param name="chosenSeats"></param>
        /// <param name="chosenSeats"></param>
        /// <returns>Prawda, jeśli którekolwiek z miejsc jest już zarezerwowane</returns>
        public bool checkSeatsForEdit(CinemaContext dc, List<Seat> chosenSeats, Guid userId)
        {
            return chosenSeats.Any(item => !Screen.Seats.Exists(i => i.Row == item.Row && i.SeatNumber == item.SeatNumber) || dc.Reservations.Any(i => i.User.Id != userId && i.Seats.Any(ii => ii.Row == item.Row && ii.SeatNumber == item.SeatNumber)));
        }
    }
}