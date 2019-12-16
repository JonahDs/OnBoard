using Newtonsoft.Json.Linq;
using OnBoardUWP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;

namespace OnBoardUWP.ViewModels
{
    public class MusicPlayerViewModel : BindableBase
    {
        private HttpClient client = new HttpClient();
        private Playlist _playlist;
        public Playlist Playlist
        {
            get { return this._playlist; }
            set
            {
                Set(ref _playlist, value);
                GetMusic();
            }
        }

        public MusicPlayerViewModel()
        {

        }

        public async void GetMusic()
        {
            if (_playlist.Music == null || _playlist.Music.Count() == 0)
            {
                Uri requestUri = new Uri(_playlist.TrackList);
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
        }

        private void MorphRequest(string httpResponseBody)
        {
            JObject music = JObject.Parse(httpResponseBody);
            IList<JToken> musiclistjson = music["data"].Children().ToList();
            var list = new List<Music>();
            foreach (var musicjson in musiclistjson)
            {
                //double seconds = (double)musicjson["duration"];
                //TimeSpan duration = TimeSpan.FromSeconds(seconds);
                Playlist.Music.Add(new Music()
                {
                    Title = (string)musicjson["title"],
                    Artist = (string)musicjson["artist"]["name"],
                    Link = (string)musicjson["preview"],
                    Duration = TimeSpan.FromSeconds((double)musicjson["duration"]).ToString(@"mm\:ss")
                });
            }


        }
    }
}
