using System.Linq;
using System.Xml.Linq;

namespace Oblig_Opgave1_2_TS
{
    public class TrophiesRepository
    {
        public TrophiesRepository()
        {
            _trophies.Add(new Trophy() { Id = _nextId++, Competition = "Handball", Year = 1999 });
            _trophies.Add(new Trophy() { Id = _nextId++, Competition = "Football", Year = 1995 });
            _trophies.Add(new Trophy() { Id = _nextId++, Competition = "Longrun", Year = 1988 });
            _trophies.Add(new Trophy() { Id = _nextId++, Competition = "Futsal", Year = 1997 });
            _trophies.Add(new Trophy() { Id = _nextId++, Competition = "basketball", Year = 2012 });
        }

        private List<Trophy>? _trophies = new List<Trophy>() { }; // save data
        private int _nextId = 1; // auto id, Repository responsebility 

        public Trophy Add(Trophy trophy)
        {
            trophy.Validate();

            if (_trophies.Contains(trophy))
            {
                return null;
            }

            trophy.Id = _nextId++;
            _trophies.Add(trophy);
            return trophy;

        }

        public List<Trophy> GetFullList()
        {
            if (_trophies == null)
            {
                return null;
            }

            return new List<Trophy>(_trophies);
        }

        public IEnumerable<Trophy> Getbydata(int? Year = null, string? Competition = null, string? orderBy = null)
        {

            IEnumerable<Trophy> result = new List<Trophy>(_trophies);

            if (orderBy != null)
            {
                orderBy = orderBy.ToLower();
                switch (orderBy)
                {
                    case "Competition":
                    case "Competition_asc":
                        result = result.OrderBy(t => t.Competition);
                        break;
                    case "Competition_desc":
                        result = result.OrderByDescending(m => m.Competition);
                        break;
                    case "year":
                    case "year_asc":
                        result = result.OrderBy(m => m.Year);
                        break;
                    case "year_desc":
                        result = result.OrderByDescending(m => m.Year);
                        break;
                    default:
                        break; // do nothing
                        throw new ArgumentException("Unknown sort order: " + orderBy);
                }
            }
            return result;
        }

        public Trophy? GetById(int id)
        {
            return _trophies.FirstOrDefault(actor => actor.Id == id);
        }

        public Trophy? Removebyid(int id)
        {
            if (_trophies == null)
            {
                return null;
            }

            Trophy? trophy = GetById(id);

            if (!_trophies.Contains(trophy))
            {

                return null;

            }

            _trophies.Remove(trophy);

            return trophy;
        }

        public Trophy? Update(int id, Trophy data)
        {
            data.Validate();
            Trophy? trophy = GetById(id);

            if (trophy == null)
            {
                return null;

            }
            trophy.Competition = data.Competition;
            trophy.Year = data.Year;

            return trophy;
        }
    }
}
