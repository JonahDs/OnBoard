using Newtonsoft.Json.Linq;
using OnBoardUWP.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardUWP.ViewModels
{
    public class MusicViewModel : BindableBase
    {
        private HttpClient client = new HttpClient();
        private ObservableCollection<Music> _musicList;
        public ObservableCollection<Music> MusicList {
            get {
                return _musicList;
            }
            set {
                Set(ref _musicList, value);
            }
        }

        public MusicViewModel()
        {
            _musicList = new ObservableCollection<Music>();
            GetMusic();
            var x = MusicList;
        }
        private async void GetMusic()
        {
            Uri requestUri = new Uri("https://api.deezer.com/playlist/955331455/tracks");
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
            IEnumerable<JToken> trackjsonlist = json["data"].Children();
            foreach (JToken trackjson in trackjsonlist)
            {
                MusicList.Add(new Music()
                {
                    Title = (string)trackjson["title"],
                    Link = (string)trackjson["link"],
                    Artist = (string)trackjson["artist"]["name"]
                });
            }
        }
    }
}
