using Newtonsoft.Json.Linq;
using OnBoardUWP.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardUWP.ViewModels
{
    public class MovieViewModel : BindableBase
    {
        private HttpClient client = new HttpClient();
        private ObservableCollection<Movie> _movies;
        public ObservableCollection<Movie> Movies
        {
            get
            {
                return _movies;
            }
            set
            {
                Set(ref _movies, value);
            }
        }

        public MovieViewModel()
        {
            Movies = new ObservableCollection<Movie>();
            GetMovies();
        }

        private async void GetMovies()
        {
            Uri requestUri = new Uri("http://www.omdbapi.com/?apikey=78b40767&s=star+wars");
            string httpResponseBody = "";
            HttpResponseMessage httpResponse = new HttpResponseMessage();

            try
            {
                httpResponse = await client.GetAsync(requestUri);
                httpResponse.EnsureSuccessStatusCode();
                httpResponseBody = await httpResponse.Content.ReadAsStringAsync();
                MorphRequest(httpResponseBody);
            }
            catch (Exception ex)
            {
                httpResponseBody = "Error: " + ex.HResult.ToString("X") + " Message: " + ex.Message;
            }


        }

        private void MorphRequest(string httpResponseBody)
        {
            JObject movie = JObject.Parse(httpResponseBody);
            IList<JToken> dates = movie["Search"].Children().ToList();

            dates.ToList().ForEach(element =>
            {
                Movie m = element.ToObject<Movie>();
                Movies.Add(element.ToObject<Movie>());
            });
        }
    }
}
