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

        private Movie _currentlyViewedMovie;
        public Movie CurrentlyViewedMovie
        {
            get
            {
                return _currentlyViewedMovie;
            }
            set
            {
                Set(ref _currentlyViewedMovie, value);
            }
        }

        public MovieViewModel()
        {
            Movies = new ObservableCollection<Movie>();
            GetMovies();
        }

        /// <summary>
        /// retrieve all movies
        /// </summary>
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

        /// <summary>
        /// Only pick certain parts of the response json
        /// </summary>
        /// <param name="httpResponseBody"></param>
        private void MorphRequest(string httpResponseBody)
        {
            JObject movie = JObject.Parse(httpResponseBody);
            IList<JToken> movies = movie["Search"].Children().ToList();

            movies.ToList().ForEach(element =>
            {
                Movie m = element.ToObject<Movie>();
                Movies.Add(element.ToObject<Movie>());
            });
        }

        /// <summary>
        /// Sets the currently viewed movie
        /// </summary>
        /// <param name="movieId"></param>
        public async void FetchMovieDetails(string movieId)
        {
            Uri requestUri = new Uri($"http://www.omdbapi.com/?apikey=78b40767&i={movieId}");
            string httpResponseBody = "";
            HttpResponseMessage httpResponse = new HttpResponseMessage();

            try
            {
                httpResponse = await client.GetAsync(requestUri);
                httpResponse.EnsureSuccessStatusCode();
                httpResponseBody = await httpResponse.Content.ReadAsStringAsync();
                CurrentlyViewedMovie = GetMovieDescription(httpResponseBody, movieId);
            }
            catch (Exception ex)
            {
                httpResponseBody = "Error: " + ex.HResult.ToString("X") + " Message: " + ex.Message;
            }

        }


        /// <summary>
        /// Fills the remaining movie details. First approach was to send a dictionary (with the plot, ...) to the view alongside with the movie object
        /// This seems to be impossible as navigating to a new page can only hold 1 paramater
        /// </summary>
        /// <param name="httpResponseBody"></param>
        /// <param name="movieId"></param>
        /// <returns></returns>
        private Movie GetMovieDescription(string httpResponseBody, string movieId)
        {
            Dictionary<string, string> localDictionary = new Dictionary<string, string>();
            JObject movie = JObject.Parse(httpResponseBody);
            Movie searchedMovie = Movies.FirstOrDefault(t => t.ImdbID.Equals(movieId));
            searchedMovie.Language = (string)movie["Language"];
            searchedMovie.Plot = (string)movie["Plot"];
            searchedMovie.ImdbRating = (double)movie["imdbRating"];
            return searchedMovie;
        }
    }
}
