using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class PlayerStatistic : Player
    {
        public PlayerStatistic(string name, string image, string position)
        {
            Name = name;
            Image = image;
            Position = position;
            Yellow_cards = 0;
            Appearances = 0;
            Goals = 0;
        }

        public int Yellow_cards { get; set; }
        public int Appearances { get; set; }
        public int Goals { get; set; }
    }
}
