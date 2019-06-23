using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Player
    {
        private const char _del = '|';

        public string Name { get; set; }
        public bool Captain { get; set; }
        public int Shirt_number { get; set; }
        public string Position { get; set; }
        public bool Favorite { get; set; }
        public string Image { get; set; }

        internal string FormatForWriting() => $"{Name}{_del}{Captain}{_del}{Shirt_number}{_del}{Position}" +
              $"{_del}{Favorite}";


        internal static Player ParseFromFileLine(string line)
        {
            string[] splittedLines = line.Split(_del);

            return new Player
            {
                Name = splittedLines[0],
                Captain = (splittedLines[1] == "true") ? true : false,
                Shirt_number = int.Parse(splittedLines[2]),
                Position = splittedLines[3],
                Favorite = (splittedLines[4] == "true") ? true : false
            };
        }
    }
}
