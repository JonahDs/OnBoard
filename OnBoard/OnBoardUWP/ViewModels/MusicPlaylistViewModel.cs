using Newtonsoft.Json.Linq;
using OnBoardUWP.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;

namespace OnBoardUWP.ViewModels
{
    public class MusicPlaylistsViewModel : BindableBase
    {
        private HttpClient client = new HttpClient();
        private ObservableCollection<Playlist> _playlists;
        public ObservableCollection<Playlist> Playlists
        {
            get
            {
                return _playlists;
            }
            set
            {
                Set(ref _playlists, value);
            }
        }

        public MusicPlaylistsViewModel()
        {
            _playlists = new ObservableCollection<Playlist>();
            GetPlaylists();
        }
        private async void GetPlaylists()
        {
            Uri requestUri = new Uri("https://api.deezer.com/artist/142381/playlists");
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
            JObject json = JObject.Parse(httpResponseBody);
            IEnumerable<JToken> playlistjsonlist = json["data"].Children();
            foreach (JToken playlistjson in playlistjsonlist)
            {
                Playlists.Add(new Playlist()
                {
                    Name = (string)playlistjson["title"],
                    Image = (string)playlistjson["picture"],
                    TrackList = (string)playlistjson["tracklist"]
                });
            }
        }
    }
}
