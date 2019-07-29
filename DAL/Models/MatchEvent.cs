using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class MatchEvent
    {
        public int Id { get; set; }
        public string Type_of_event { get; set; }
        public string Player { get; set; }
        public string Time { get; set; }
    }
}
