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
        private const string favoritePlayersPath = @"players\fav\";


        static FileRepository() { }

        public static bool CheckLanguage()
        {
            if (!File.Exists(fileLanguagePath)) return false;

            if (ReadLanguagePreference() == "Hrvatski" || ReadLanguagePreference() == "English") return true;

            return false;
        }

        public static string GetFavoriteTeam()
        {
            if (!File.Exists(fileFavoriteTeamPath)) return null;

            string s;
            using (StreamReader sr = new StreamReader(fileFavoriteTeamPath))
            {
                s = sr.ReadLine();
            }

            return s;
        }

        public static void SaveFavoriteTeam(string favorite)
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
            if (!Directory.Exists(playersPicturesPath))
                Directory.CreateDirectory(playersPicturesPath);

            List<String> loadPaths = new List<string>();

            string[] files = Directory.GetFiles(playersPicturesPath);
            if (files.Length == 0) return null;

            var picFiles = Directory.EnumerateFiles(playersPicturesPath);
            foreach (string curr in picFiles)
            {
                loadPaths.Add(curr);
            }
            return loadPaths.ToArray();
        }

        public static void SaveFavoritePlayers(List<Player> currentPlayers, Team favoriteTeam)
        {

            if (!Directory.Exists(favoritePlayersPath))
                Directory.CreateDirectory(favoritePlayersPath);

            string filename = favoritePlayersPath + favoriteTeam.Fifa_code + ".txt";

            if (File.Exists(filename))
                File.Delete(filename);

            using (StreamWriter tw = new StreamWriter(filename))
            {
                foreach (Player t in currentPlayers)
                {
                    if (t.Favorite)
                        tw.WriteLine(t.FormatForWriting());
                }
            }
        }

        internal static async Task<List<Player>> LoadFavoritePlayers(string fifa_code)
        {
            if (!Directory.Exists(favoritePlayersPath))
                Directory.CreateDirectory(favoritePlayersPath);

            List<Player> fav = new List<Player>();


            if (!File.Exists($"{favoritePlayersPath}{fifa_code}.txt")) return fav;
            string[] currentFavTeamPath = Directory.GetFiles(favoritePlayersPath, fifa_code + ".txt");

            if (currentFavTeamPath.Length == 0 || currentFavTeamPath.Length > 1) return fav;
            if (currentFavTeamPath.Length > 1)
            {
                File.Delete(currentFavTeamPath + ".txt");
            }


            using (StreamReader sr = new StreamReader(currentFavTeamPath[0]))
            {

                string line;
                while (true)
                {
                    line = await sr.ReadLineAsync();
                    if (line == null) break;

                    fav.Add(Player.ParseFromFileLine(line));
                }

            }
            return fav;
        }

        public static void ChangePlayerPicture(string inputPath, string destFileName)
        {
            File.Copy(inputPath, destFileName);
        }
    }
}
