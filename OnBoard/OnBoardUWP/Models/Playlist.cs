using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardUWP.Models
{
    public class Playlist
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string TrackList { get; set; }
        public ObservableCollection<Music> Music { get; set; }

        public Playlist()
        {
            Music = new ObservableCollection<Music>();
        }
    }
}
