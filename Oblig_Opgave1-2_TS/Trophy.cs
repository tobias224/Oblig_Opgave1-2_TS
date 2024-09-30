using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oblig_Opgave1_2_TS
{
    public class Trophy
    {

        public int Id { get; set; }
        public string Competition { get; set; }
        public int Year { get; set; }

        public Trophy() { }

        public void ValidateId()
        {
            if (Id < 0)
            {
                throw new ArgumentOutOfRangeException("ID must be a Positiv number.");
            }
        }

        public void ValidateCompetition()
        {
            if (string.IsNullOrEmpty(Competition) || Competition.Length < 3)
            {
                throw new ArgumentOutOfRangeException("Competition must be at least 3 characters long and cannot be null or empty.");
            }

        }


        public void ValidateYear()
        {
            if (Year < 1970 || Year > 2024)
            {
                throw new ArgumentOutOfRangeException("ID must be a Positiv number.");
            }
        }

        public void Validate()
        {
            ValidateYear();
            ValidateCompetition();
            ValidateId();
        }

        public override string ToString()
        {
            string trophystring = $"ID:{Id},Competition:{Competition},Year:{Year}\n";

            return trophystring;

        }
    }
}
