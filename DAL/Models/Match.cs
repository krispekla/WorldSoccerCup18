using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Match
    {
        public DateTime Datetime { get; set; }
        public string Home_team_country { get; set; }
        public string Away_team_country { get; set; }
        public string Location { get; set; }
        public string Venue { get; set; }
        public string Winner { get; set; }
        public string Attendance { get; set; }

        public List<Player> HomeTeamStartingEleven { get; set; }
        public List<Player> AwayTeamStartingEleven { get; set; }
        public string HomeTeamTactic { get; set; }
        public string AwayTeamTactic { get; set; }
    }
}
