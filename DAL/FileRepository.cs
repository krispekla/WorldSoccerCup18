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
        private static string resFolder = "";
        private static string fileTeamPath = "";
        private static string fileFavoriteTeamPath = "";
        private static string fileSettingsPath = "";
        private static string playersPicturesPath = "";
        private static string favoritePlayersPath = "";


        static FileRepository()
        {
            resFolder = (Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Environment.CurrentDirectory.ToString()))) + "\\resources\\");
            if (!Directory.Exists(resFolder))
                Directory.CreateDirectory(resFolder);
            fileTeamPath = resFolder + "teams.txt";
            fileFavoriteTeamPath = resFolder + "favoriteTeam.txt";
            fileSettingsPath = resFolder + "settings.txt";
            playersPicturesPath = resFolder + "players\\img\\";
            favoritePlayersPath = resFolder + "players\\fav\\";
        }

        public static bool CheckLanguage()
        {
            if (!File.Exists(fileSettingsPath)) return false;

            if (ReadLanguagePreference() == "Hrvatski" || ReadLanguagePreference() == "English") return true;

            return false;
        }

        public static string GetFavoriteTeam()
        {
            if (!File.Exists(fileFavoriteTeamPath)) return "Canada CAN";

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
            if (!File.Exists(fileSettingsPath)) return null;

            string settings = File.ReadAllText(fileSettingsPath);

            int newLineIndex = settings.IndexOf("\r\n");
            if (newLineIndex != -1)
            {
                settings = settings.Substring(9, newLineIndex - 9);
            }
            else return "";

            return settings;
        }

        public static void WriteLanguagePreference(string lang)
        {
            string settings;
            if (!File.Exists(fileSettingsPath))
            {
                using (File.Create(fileSettingsPath)) { };
                Settings s = new Settings();

                s.Language = lang;
                s.Height = 900;
                s.Width = 1200;
                settings = s.FormatForWriting();
            }
            else
            {
                settings = File.ReadAllText(fileSettingsPath);
                int newLineIndex = settings.IndexOf("\r\n");
                if (newLineIndex != -1)
                {

                    string temp = settings.Substring(0, 9);
                    settings = temp + lang + settings.Substring(newLineIndex, (settings.Length - newLineIndex));
                }

            }

            using (StreamWriter tw = new StreamWriter(fileSettingsPath))
            {
                tw.Write(settings);
            }
        }

        public static Settings ReadWPFSettings()
        {
            if (!File.Exists(fileSettingsPath)) return null;
            string temp = File.ReadAllText(fileSettingsPath);

            if (string.IsNullOrEmpty(temp)) return null;

            Settings loadedSettings = Settings.ParseFromFileLine(temp);
            return loadedSettings;
        }

        public static void WriteWPFSettings(Settings stgs)
        {
            using (StreamWriter tw = new StreamWriter(fileSettingsPath, false))
            {
                tw.Write(stgs.FormatForWriting());
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

            return files;
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
