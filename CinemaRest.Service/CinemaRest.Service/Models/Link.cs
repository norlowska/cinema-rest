using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaRest.Service.Models
{
    /// <summary>
    /// Klasa reprezentująca odnośnik do zasobu
    /// </summary>
    public class Link
    {
        /// <summary>
        /// URI do zasobu
        /// </summary>
        public string Href { get; set; }
        /// <summary>
        /// Nazwa zasobu
        /// </summary>
        public string Rel { get; set; }
        /// <summary>
        /// Metoda HTTP
        /// </summary>
        public string Method { get; set; }

        public Link() { }

        public Link(string href, string rel, string method)
        {
            Href = href;
            Rel = rel;
            Method = method;
        }
    }
}
