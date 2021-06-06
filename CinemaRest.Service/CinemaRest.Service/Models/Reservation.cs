using CinemaRest.Service.DataShapes;
using Microsoft.Extensions.Configuration;
using SelectPdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;

namespace CinemaRest.Service.Models
{
    public class Reservation : LinkResourceBase
    {
        private IConfigurationRoot ConfigRoot;
        public Guid Id { get; set; } = Guid.NewGuid();
        public User User { get; set; }
        public Screening Screening { get; set; }
        public List<Seat> Seats { get; set; } = new List<Seat>();
        public bool Deleted { get; set; } = false;

        public Reservation() { }
        public Reservation(IConfiguration configRoot)
        {
            ConfigRoot = (IConfigurationRoot)configRoot; 
        }

        public void AddSeat(Seat seat)
        {
            Seats.Add(seat);
        }

        public static Reservation BookScreening(CinemaContext dc, Screening screening, List<Seat> chosenSeats, string email) //w argumecnie/broszurze trzeba przekazać na jaki seans oraz jake siedzenia rezerwujesz oraz uzytkownika
        {
            if (screening.checkSeats(chosenSeats)) return null;
            else
            {
                Reservation newReservation = new Reservation();
                User user = User.GetByEmail(dc, email);
                newReservation.User = user;
                newReservation.Screening = screening;
                chosenSeats.ForEach(item => item.Id = dc.Seats.Where(i => i.Screen.Id == screening.Screen.Id && i.Row == item.Row && i.SeatNumber == item.SeatNumber).FirstOrDefault().Id);
                newReservation.Seats = chosenSeats;
                user.Reservations.Add(newReservation);
                dc.Reservations.Add(newReservation);
                return newReservation;                
            }
        }

        public List<Seat> ConvertSeatsTabToList(CinemaContext dc, Guid sID, int[][] seatsTab)
        {
            List<Seat> seatsList = new List<Seat>();
            Screening screening = Screening.GetById(dc, sID);
            for (int i =0; i<seatsTab.Length; i++)
            {
                seatsList.Add(dc.Seats.FirstOrDefault(Seat => 
                {
                    return Seat.Screen == screening.Screen && Seat.Row == seatsTab[i][0] && Seat.SeatNumber == seatsTab[i][1];
                }
                ));
            }
            return seatsList;
        }

        public Byte[] preparePDF()
        {
            try
            {
                string filePath = Path.Combine(ConfigRoot.GetSection("AppDataPath").Value, $"Reservation{this.Id}");
                string seats = string.Empty;
                foreach (Seat s in Seats)
                {
                    seats += "Seat: " + s.SeatNumber + ", Row: " + s.Row + "<br />";
                }
                var myHtml =
"<style>h1 {font-size:12px;}</style>" +
"<h1>Reservation confirmation</h1>" +
$"<p>Reservation no. {Id}</p>" +
$"<p>Title: <b>{Screening.Movie.Title}</b></p>" +
"<p>Date " + this.Id + "</p>" +
$"<p>Screen no. {Screening.Screen.Name}</p>" +
"<p>Seats <br />" + seats + "</p>" +
$"<p>{User.FirstName} {User.LastName}</p>" +
$"<p>{User.Email}</p>";

                HtmlToPdf converter = new HtmlToPdf();
                PdfDocument doc = converter.ConvertHtmlString(myHtml);
                doc.Save(filePath + ".pdf");
                doc.Close();

                byte[] bytes = System.IO.File.ReadAllBytes(filePath + ".pdf");
                return bytes;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public bool cancelReservation(CinemaContext dc)
        {
            try { 
                this.User.Reservations.Remove(this);
                dc.Reservations.Remove(this);
                return true;
            } catch(Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        /// <summary>
        /// Pobranie rezerwacji na podstawie identyfikatora
        /// </summary>
        /// <param name="id">Identyfikator</param>
        /// <returns></returns>
        public static Reservation GetById(CinemaContext dc, Guid id)
        {
            return dc.Reservations.Where(item => item.Id == id).FirstOrDefault();
        }

        public static Reservation editReservation(CinemaContext dc, EditReservationRequestDTO editedReservation) 
        {
            Reservation originalReservation = dc.Reservations.Where(item => item.Id == editedReservation.Id).FirstOrDefault();
            if (originalReservation != null)
            {
                if (originalReservation.Screening.checkSeatsForEdit(dc, editedReservation.Seats, originalReservation.User.Id)) return null; //check if editedReservation's seats aren't already taken
                else
                {
                    editedReservation.Seats.ForEach(item => item.Id = dc.Seats.Where(i => i.Screen.Id == originalReservation.Screening.Screen.Id && i.Row == item.Row && i.SeatNumber == item.SeatNumber).FirstOrDefault().Id);
                    originalReservation.Seats = editedReservation.Seats;
                    return originalReservation;
                }
            }
            return null;
        }
    }
}