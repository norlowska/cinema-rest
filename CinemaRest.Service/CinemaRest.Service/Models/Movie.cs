using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace CinemaRest.Service.Models
{
    public class Movie : LinkResourceBase
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title;
        public string Description;
        public byte[] ImageData;
        public List<Character> Characters { get; set; } = new List<Character>();
        public List<CrewMember> Crew { get; set; } = new List<CrewMember>();
        public bool Deleted { get; set; } = false;
        public List<Screening> Screenings { get; set; } = new List<Screening>();

        public Movie() { }

        public void AddCharacter(Character character)
        {
            this.Characters.Add(character);
        }

        public void AddCrewMember(CrewMember member)
        {
            Crew.Add(member);
        }
       
        public static List<Movie> GetRepertoire(DateTime date)
        {
            CinemaContext dc = CinemaContext.GetContext();
            List<Movie> movies = dc.Movies.Where(item => item.Screenings.Any(i => i.Date == date.ToString("yyyy-MM-dd"))).Select(x => x.DeepClone()).ToList();
            foreach(var m in movies)
            {
                m.Screenings = m.Screenings.Where(item => item.Date == date.ToString("yyyy-MM-dd")).Select(x=>x.DeepClone()).ToList();
                foreach (var s in m.Screenings)
                    s.Movie = null;
            }
            return movies;
        }

        public static Movie GetById(Guid id)
        {
            return CinemaContext.GetContext().Movies.Where(item => item.Id == id).FirstOrDefault();
        }
    }
}