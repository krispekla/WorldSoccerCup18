using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{

    [Serializable]
    public class Team
    {
        private const char _del = '|';

        public int Id { get; set; }
        public string Country { get; set; }
        public string Alternate_name { get; set; }
        public string Fifa_code { get; set; }
        public int Group_id { get; set; }
        public string Group_letter { get; set; }
        public int Wins { get; set; }
        public int Draws { get; set; }
        public int Losses { get; set; }
        public int Games_played { get; set; }
        public int Points { get; set; }
        public int Goals_for { get; set; }
        public int Goals_against { get; set; }
        public int Goal_differential { get; set; }

        internal string FormatForWriting() => $"{Id}{_del}{Country}{_del}{Alternate_name}{_del}{Fifa_code}" +
                $"{_del}{Group_id}{_del}{Group_letter}{_del}{Wins}{_del}{Draws}" +
                $"{_del}{Losses}{_del}{Games_played}{_del}{Points}{_del}{Goals_for}" +
                $"{_del}{Goals_against}{_del}{Goal_differential}{_del}";


        internal static Team ParseFromFileLine(string line)
        {
            string[] splittedLines = line.Split(_del);

            return new Team
            {
                Id = int.Parse(splittedLines[0]),
                Country = splittedLines[1],
                Alternate_name = splittedLines[2],
                Fifa_code = splittedLines[3],
                Group_id = int.Parse(splittedLines[4]),
                Group_letter = splittedLines[5],
                Wins = int.Parse(splittedLines[6]),
                Draws = int.Parse(splittedLines[7]),
                Losses = int.Parse(splittedLines[8]),
                Games_played = int.Parse(splittedLines[9]),
                Points = int.Parse(splittedLines[10]),
                Goals_for = int.Parse(splittedLines[11]),
                Goals_against = int.Parse(splittedLines[12]),
                Goal_differential = int.Parse(splittedLines[13])
            };
        }
    }
}
