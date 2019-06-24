using DAL.Models;
using DAL.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Repository
    {
        private const string urlBase = "https://world-cup-json-2018.herokuapp.com/";
        private const string urlTeams = urlBase + "teams/results";
        private const string urlPlayers = urlBase + "matches/country?fifa_code=";
        private static List<Team> teams = new List<Team>();

        static Repository() { }

        public static bool LanguageIsSet()
        {
            return FileRepository.CheckLanguage();
        }

        public static void WriteLanguagePreference(string lang)
        {
            FileRepository.WriteLanguagePreference(lang);
        }


        public static async Task<List<Team>> GetTeams()
        {
            List<Team> tms = new List<Team>();

            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.GetAsync(urlTeams))
            using (HttpContent content = response.Content)
            {
                string result = await content.ReadAsStringAsync();

                if (String.IsNullOrWhiteSpace(result)) return null;

                tms = JsonConvert.DeserializeObject<List<Team>>(result);
                FileRepository.WriteToTextFile(teams);

            }
            return tms;
        }

        //public static string GetFavoriteTeam()
        //{
        //    return FileRepository.ReadFavoriteTeam();
        //}

        //public static void SaveFavoriteTeam(string favorite)
        //{
        //    FileRepository.WriteFavoriteTeam(favorite);
        //}

        public static async Task<List<Player>> GetPlayersByCodeAsync(string code)
        {
            List<Player> loadedPlayers = new List<Player>();

            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.GetAsync(urlPlayers + code))
            using (HttpContent content = response.Content)
            {

                string result = await content.ReadAsStringAsync();

                if (String.IsNullOrWhiteSpace(result)) return null;

                if (!Helper.ValidateJSON(result)) return null;

                JArray jobj = JArray.Parse(result);
                string selectingTeamToParse = jobj[0]["home_team"]["code"].ToString() == code ? "home_team_statistics" : "away_team_statistics";

                var startingEleven = jobj[0][selectingTeamToParse]["starting_eleven"];
                var substitues = jobj[0][selectingTeamToParse]["substitutes"];

                loadedPlayers = JsonConvert.DeserializeObject<List<Player>>(startingEleven.ToString());
                loadedPlayers.AddRange(JsonConvert.DeserializeObject<List<Player>>(substitues.ToString()));

            }

            List<Player> loadedWithFavorites = await LoadFavoritePlayersAsync(code, loadedPlayers);

            return SetPlayersImages(loadedWithFavorites);
        }

        private static List<Player> SetPlayersImages(List<Player> loadedPlayers)
        {

            string[] playerImages = FileRepository.LoadPlayersImages();

            if (playerImages == null) return loadedPlayers;

            foreach (string item in playerImages)
            {
                string current = item.Substring(12, (item.IndexOf('.') - 12));
                int finded = loadedPlayers.FindIndex(dx => dx.Name.Replace(" ", "") == current);
                if (finded != -1)
                {
                    loadedPlayers[finded].Image = item;
                }
            }

            return loadedPlayers;
        }

        public static void ChangePlayerPicture(string inputPath, string destFileName)
        {
            File.Copy(inputPath, destFileName);
        }

        private static async Task<List<Player>> FetchPlayers(string code)
        {
            List<Player> convertPlayers = new List<Player>();

            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.GetAsync(urlPlayers))
            using (HttpContent content = response.Content)
            {

                string result = await content.ReadAsStringAsync();

                if (result != null)
                {
                    convertPlayers = JsonConvert.DeserializeObject<List<Player>>(result);
                }
            }
            return convertPlayers;
        }

        public static void SaveFavoritePlayers(List<Player> currentPlayers, Team favoriteTeam)
        {
            FileRepository.SaveFavoritePlayers(currentPlayers, favoriteTeam);
        }

        public static async Task<List<Player>> LoadFavoritePlayersAsync(string fifa_code, List<Player> loadedPlayers)
        {
            List<Player> favorites;

            favorites = await FileRepository.LoadFavoritePlayers(fifa_code);

            if (favorites.Count == 0) return loadedPlayers;

            loadedPlayers.ForEach(x =>
            {
                if (favorites.Find(y => y.Name == x.Name) != null)
                {
                    x.Favorite = true;
                }
            });
            return loadedPlayers;
        }
    }
}
