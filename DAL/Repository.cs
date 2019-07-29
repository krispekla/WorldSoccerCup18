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
        private const string urlBase = "https://worldcup.sfg.io/";
        private const string urlTeams = urlBase + "teams/results";
        private const string urlPlayers = urlBase + "matches/country?fifa_code=";
        private static List<Team> _teams = new List<Team>();
        private static List<Match> _matches = new List<Match>();
        private static List<PlayerStatistic> _playersStatistic = new List<PlayerStatistic>();
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
                FileRepository.WriteToTextFile(_teams);

            }
            return tms;
        }

        public static async Task<List<Player>> GetPlayersByCodeAsync(string code)
        {
            _matches.Clear();
            List<Player> loadedPlayers = new List<Player>();
            JArray jobj = new JArray();

            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.GetAsync(urlPlayers + code))
            using (HttpContent content = response.Content)
            {

                string result = await content.ReadAsStringAsync();

                if (String.IsNullOrWhiteSpace(result)) return null;

                if (!Helper.ValidateJSON(result)) return null;

                jobj = JArray.Parse(result);
                string selectingTeamToParse = jobj[0]["home_team"]["code"].ToString() == code ? "home_team_statistics" : "away_team_statistics";

                var startingEleven = jobj[0][selectingTeamToParse]["starting_eleven"];
                var substitues = jobj[0][selectingTeamToParse]["substitutes"];

                loadedPlayers = JsonConvert.DeserializeObject<List<Player>>(startingEleven.ToString());
                loadedPlayers.AddRange(JsonConvert.DeserializeObject<List<Player>>(substitues.ToString()));

            }

            List<Player> loadedWithFavorites = await LoadFavoritePlayersAsync(code, loadedPlayers);
            List<Player> loadedWithImages = SetPlayersImages(loadedWithFavorites);
            ParsePlayersStatistic(jobj, loadedWithImages, code);
            return loadedWithImages;
        }

        private static void ParsePlayersStatistic(JArray result, List<Player> loadedWithImages, string code)
        {
            List<PlayerStatistic> plStat = loadedWithImages.Select(pl => new PlayerStatistic(pl.Name, pl.Image, pl.Position)).ToList();

            for (int i = 0; i < result.Count; i++)
            {
                string selectingTeamToParse = result[i]["home_team"]["code"].ToString() == code ? "home_team" : "away_team";
                string events = selectingTeamToParse + "_events";
                string statistic = selectingTeamToParse + "_statistics";
                List<MatchEvent> matchEvents = JsonConvert.DeserializeObject<List<MatchEvent>>(result[i][events].ToString());
                List<Player> startingEleven = JsonConvert.DeserializeObject<List<Player>>(result[i][statistic]["starting_eleven"].ToString());

                foreach (MatchEvent me in matchEvents)
                {
                    if (me.Type_of_event == "substitution-in")
                    {
                        int ind = plStat.FindIndex(n => n.Name == me.Player);
                        if (ind != -1)
                            plStat[ind].Appearances += 1;
                    }
                    else if (me.Type_of_event == "yellow-card")
                    {
                        int ind = plStat.FindIndex(n => n.Name == me.Player);
                        if (ind != -1)
                            plStat[ind].Yellow_cards += 1;
                    }
                    else if (me.Type_of_event.Substring(0, 4) == "goal")
                    {
                        int ind = plStat.FindIndex(n => n.Name == me.Player);
                        if (ind != -1)
                            plStat[ind].Goals += 1;
                    }

                }

                foreach (Player p in startingEleven)
                {
                    int ind = plStat.FindIndex(n => n.Name == p.Name);
                    if (ind != -1)
                        plStat[ind].Appearances += 1;
                }
                _matches.Clear();
                for (int j = 0; j < result.Count; j++)
                {
                    _matches.Add(JsonConvert.DeserializeObject<Match>((result[j]).ToString()));
                }

            }
            _playersStatistic = plStat;
        }

        public async static Task<List<Match>> GetMatchForSelectedTeam(string code)
        {
            List<Match> loaded = new List<Match>();
            JArray jobj;

            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.GetAsync(urlPlayers + code))
            using (HttpContent content = response.Content)
            {

                string result = await content.ReadAsStringAsync();

                if (String.IsNullOrWhiteSpace(result)) return null;

                if (!Helper.ValidateJSON(result)) return null;

                jobj = JArray.Parse(result);
                for (int i = 0; i < jobj.Count(); i++)
                {
                    Match tempBasic = new Match();
                    List<PlayerStatistic> tempPlayers = new List<PlayerStatistic>();
                    tempBasic = JsonConvert.DeserializeObject<Match>(jobj[i].ToString());
                    loaded.Add(tempBasic);
                    loaded[i].HomeTeamStartingEleven = JsonConvert.DeserializeObject<List<PlayerStatistic>>(jobj[i]["home_team_statistics"]["starting_eleven"].ToString());
                    loaded[i].AwayTeamStartingEleven = JsonConvert.DeserializeObject<List<PlayerStatistic>>(jobj[i]["away_team_statistics"]["starting_eleven"].ToString());
                    loaded[i].HomeTeamTactic = jobj[i]["home_team_statistics"]["tactics"].ToString();
                    loaded[i].AwayTeamTactic = jobj[i]["away_team_statistics"]["tactics"].ToString();
                }
                return loaded;
            }
        }

        public static List<Match> GetMatchesForSelectedTeam()
        {
            return _matches;
        }

        public static List<PlayerStatistic> GetPlayerStatisticsForSelectedTeam()
        {
            return _playersStatistic;
        }

        private static List<Player> SetPlayersImages(List<Player> loadedPlayers)
        {

            string[] playerImages = FileRepository.LoadPlayersImages();

            if (playerImages == null) return loadedPlayers;

            foreach (string item in playerImages)
            {
                int pos = item.LastIndexOf('\\');
                int pos2 = item.LastIndexOf('.') - 1;
                string current = item.Substring(pos + 1, pos2 - pos);
                int finded = loadedPlayers.FindIndex(dx => dx.Name.Replace(" ", "") == current);
                if (finded != -1)
                {
                    loadedPlayers[finded].Image = item;
                }
            }

            return loadedPlayers;
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
