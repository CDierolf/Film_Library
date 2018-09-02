using MovieAPI.models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace MovieAPI.viewmodels
{
    class MovieDataAPIVM
    {
        public const string API_KEY = "49bee854";
        public const string BASE_URL = "http://www.omdbapi.com/?t={0}&apikey={1}"; // 0 = movie title, 1 = API_KEY

        /// <summary>
        /// Async task of MovieData
        /// Runs on a different thread so it doesn't bog down the app
        /// while awaiting a response and parsing the json data.
        /// Accepts a movie title as a parameter to search for.
        /// </summary>
        /// <param name="movieTitle"></param>
        /// <returns></returns>
        public async Task<MovieData> GetMovieDataAsync(string movieTitle)
        {
            MovieData result = new MovieData(); // Create a new MovieData object

            string url = string.Format(BASE_URL, movieTitle, API_KEY); // Modify the base url

            using (HttpClient client = new HttpClient()) // Create and use an HttpClient object
            {
                var response = await client.GetAsync(url);

                string json = await response.Content.ReadAsStringAsync();

                /* Deserialize the json data using Newtonsoft.Json's JsonConvert method.
                 * Creates a MovieData object out of the json 
                 */
                result = JsonConvert.DeserializeObject<MovieData>(json);
            }
            return result;
        }
    }


}
