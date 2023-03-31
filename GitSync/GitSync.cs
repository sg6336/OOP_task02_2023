using System;
using System.Net.Http;
using Newtonsoft.Json;

namespace GitSyncing{
    public static class GitSync
    {
        static string lastUpdateDate = "";

        public static string GetLastUpdateDate()
        {
            // Retrieve the last update date of your GitHub repository
            lastUpdateDate = GetLastUpdateDateAsync("thefirans", "OOP_task02_2023", "Oleksandr_Leoshko").Result;
            DateTime originalDate = DateTime.ParseExact(lastUpdateDate, "MM/dd/yyyy HH:mm:ss", null);
            lastUpdateDate = originalDate.ToString("dd.MM.yyyy");

            // Return the last update date as a string
            return lastUpdateDate;
        }

        static async System.Threading.Tasks.Task<string> GetLastUpdateDateAsync(string username, string repositoryName, string branch)
        {
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "C# console application");

            var response = await client.GetAsync($"https://api.github.com/repos/thefirans/OOP_task02_2023/commits?sha=Oleksandr_Leoshko");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var commits = JsonConvert.DeserializeObject<dynamic>(json);

                return commits[0].commit.author.date;
            }
            else
            {
                throw new Exception($"Failed to retrieve repository update date: {response.ReasonPhrase}");
            }
        }
    }
}
