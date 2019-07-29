using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Settings
    {
        private const char _del = '=';

        public string Language { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public bool Fullscreen { get; set; }

        public Settings()
        {
            Width = 600;
            Height = 800;
        }

        internal string FormatForWriting() => $"Language{_del}{Language}{Environment.NewLine}" +
            $"Width{_del}{Width}{Environment.NewLine}" +
            $"Height{_del}{Height}{Environment.NewLine}" +
            $"Fullscreen{_del}{(Fullscreen ? "true" : "false")}";


        internal static Settings ParseFromFileLine(string line)
        {
            string[] splittedLines = line.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            Settings loaded = new Settings();
            string[] temp = splittedLines[0].Split(_del);
            loaded.Language = temp[1];
            temp = splittedLines[1].Split(_del);
            loaded.Width = int.Parse(temp[1]);
            temp = splittedLines[2].Split(_del);
            loaded.Height = int.Parse(temp[1]);
            temp = splittedLines[3].Split(_del);
            loaded.Fullscreen = (temp[1] == "true") ? true : false;

            return loaded;
        }
    }
}
