using DAL.Models;
using Newtonsoft.Json;
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
        Task t = new Task(GetTeams);
        public Repository()
        {
            t.Start();
            //List<Team> teams = new List<Team>();
        }

        static async void GetTeams()
        {
            const string urlBase = "https://world-cup-json-2018.herokuapp.com/";
            const string urlTeams = urlBase + "teams/results";

            // ... Use HttpClient.
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.GetAsync(urlTeams))
            using (HttpContent content = response.Content)
            {
                // ... Read the string.
                string result = await content.ReadAsStringAsync();

                // ... Display the result.
                if (result != null)
                {
                    List<Team> teams = JsonConvert.DeserializeObject<List<Team>>(result);
                    WriteToTextFile(teams);

                    List<Team> lista = ReadFromTextFile("proba.txt");

                }
            }
        }

        private static List<Team> ReadFromTextFile(string path)
        {
            List<Team> loadingTeam = new List<Team>();
            using (TextReader tr = new StreamReader(path))
            {
                string line;
                while ((line = tr.ReadLine()) != null)
                {
                    loadingTeam.Add(Team.ParseFromFileLine(line));
                }
            }
            return loadingTeam;
        }

        private static void WriteToTextFile(List<Team> teams)
        {
            using (TextWriter tw = new StreamWriter("proba.txt"))
            {
                foreach (var t in teams)
                {
                    tw.WriteLine(t.FormatForWriting());
                }
            }
        }


    }
}
