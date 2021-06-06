using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Web;

namespace CinemaRest.Service.Models
{
    public class User : LinkResourceBase
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public List<Reservation> Reservations { get; set; } = new List<Reservation>();
        public bool Deleted { get; set; } = false;

        public User() { }
        public User(Guid id, string email, string password, string firstName, string lastName)
        {
            this.Id = id;
            this.Email = email;
            this.Password = password;
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        /// <summary>
        /// Pobranie użytkownika na podstawie adresu e-mail
        /// </summary>
        /// <param name="email">Adres e-mail</param>
        /// <returns>Model użytkownika</returns>
        public static User GetByEmail(CinemaContext dc, string email)
        {
            return dc.Users.Where(item => item.Email == email).FirstOrDefault();
        }

        /// <summary>
        /// Rejestracja użytkownika
        /// </summary>
        /// <param name="user">Użytkownik</param>
        /// <returns>Wartość logiczna, czy zarejestrowano użytkownika</returns>
        public static bool SignUp(CinemaContext dc, User user)
        {
            if (user != null)
            {
                user.Password = HashPassword(user.Password);
                dc.Users.Add(user);
            }
            return false;
        }

        /// <summary>
        /// Logowanie użytkownika
        /// </summary>
        /// <param name="email">Adres e-mail</param>
        /// <param name="password">Hasło</param>
        /// <returns>Wartość logiczna czy pomyślnie zalogowano</returns>
        public static bool SignIn(CinemaContext dc, string email, string password)
        {
            User user = GetByEmail(dc, email);
            if (user != null)
            {
                return user.VerifyPassword(password);
            }
            return false;
        }

        /// <summary>
        /// Szyfrowanie hasła
        /// </summary>
        /// <param name="password">Hasło użytkownika</param>
        /// <returns>Zaszyfrowane hasło</returns>
        private static string HashPassword(string password)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);
            return Convert.ToBase64String(hashBytes);
        }

        /// <summary>
        /// Weryfikowanie hasła użytkownika
        /// </summary>
        /// <param name="pass">Podane hasło</param>
        /// <returns>Wartość logiczna, czy podano prawidłowe hasło</returns>
        private bool VerifyPassword(string pass)
        {
            byte[] hashBytes = Convert.FromBase64String(this.Password);
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);
            var pbkdf2 = new Rfc2898DeriveBytes(pass, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);
            for (int i = 0; i < 20; i++)
                if (hashBytes[i + 16] != hash[i])
                    return false;
            return true;
        }

        public static User GetById(CinemaContext dc, Guid id)
        {
            return dc.Users.Where(item => item.Id == id).FirstOrDefault();
        }

        public List<Reservation> getReservation()
        {
            return Reservations;
        }
    }
}