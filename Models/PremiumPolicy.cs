using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TAL_TEST.Models
{
    public class OccupationList
    {
        public string Occupation { get; set; }
        public string Rating { get; set; }
    }

    public class OccupationRatingList
    {
        public string Rating { get; set; }
        public decimal Factor { get; set; }
    }
    public class PremiumPolicy
    {
        public PremiumPolicy()
        {
            OccupationList = new List<OccupationList>();
            OccupationRatingList = new List<OccupationRatingList>();
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime DOB { get; set; }
        public string Occupation { get; set; }
        public int DeathSumInsured { get; set; }
        public decimal DeathPremium { get; set; }
        public List<OccupationList> OccupationList { get; set; }
        public List<OccupationRatingList> OccupationRatingList { get; set; }
     }
}
