using DAL.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FileRepository
    {
        private const string fileTeamPath = "teams.txt";
        private const string fileFavoriteTeamPath = "favoriteTeam.txt";
        private const string fileLanguagePath = "language.txt";
        private const string playersPicturesPath = @"players\img\";


        static FileRepository() { }

        public static bool CheckLanguage()
        {
            if (!File.Exists(fileLanguagePath)) return false;

            if (ReadLanguagePreference() == "Hrvatski" || ReadLanguagePreference() == "English") return true;

            return false;
        }

        public static string ReadFavoriteTeam()
        {
            if (!File.Exists(fileFavoriteTeamPath)) return null;

            string s;
            using (StreamReader sr = new StreamReader(fileFavoriteTeamPath))
            {
                s = sr.ReadLine();
            }

            return s;
        }

        public static void WriteFavoriteTeam(string favorite)
        {
            using (StreamWriter tw = new StreamWriter(fileFavoriteTeamPath))
            {
                tw.Write(favorite);
            }
        }


        public static string ReadLanguagePreference()
        {
            if (!File.Exists(fileLanguagePath)) return null;

            return File.ReadAllText(fileLanguagePath);
        }

        public static void WriteLanguagePreference(string lang)
        {
            using (StreamWriter tw = new StreamWriter(fileLanguagePath))
            {
                tw.Write(lang);
            }
        }


        public static List<Team> ReadFromTextFile(string path)
        {
            List<Team> loadingTeam = new List<Team>();
            using (StreamReader tr = new StreamReader(path))
            {
                string line;
                while ((line = tr.ReadLine()) != null)
                {
                    loadingTeam.Add(Team.ParseFromFileLine(line));
                }
            }
            return loadingTeam;
        }

        public static void WriteToTextFile(List<Team> teams)
        {
            using (StreamWriter tw = new StreamWriter(fileTeamPath))
            {
                foreach (var t in teams)
                {
                    tw.WriteLine(t.FormatForWriting());
                }
            }
        }

        internal static string[] LoadPlayersImages()
        {
            List<String> loadPaths = new List<string>();
            var picFiles = Directory.EnumerateFiles(playersPicturesPath);
            foreach (string curr in picFiles)
            {
                loadPaths.Add(curr);
            }
            return loadPaths.ToArray();
        }
    }
}
