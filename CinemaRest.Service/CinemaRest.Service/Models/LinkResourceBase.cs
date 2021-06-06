using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaRest.Service.Models
{
    /// <summary>
    /// Klasa zawierająca linki HATEOAS
    /// </summary>
    public abstract class LinkResourceBase
    {        
        public LinkResourceBase()
        {
        }
        public List<Link> Links { get; set; } = new List<Link>();
    }
}
