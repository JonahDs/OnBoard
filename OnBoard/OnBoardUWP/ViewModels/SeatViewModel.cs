using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;

namespace OnBoardUWP.ViewModels
{
    public class SeatViewModel: BindableBase
    {
        private HttpClient client = new HttpClient();



        public async void SwitchUsersWithId(List<int> seats)
        {
            var seatOne = seats[0];
            var seatTwo = seats[1];
            try
            {
                Uri uri = new Uri($"http://localhost:50236/api/seat/switchSeats/{seatOne}/{seatTwo}");
                HttpStringContent content = new HttpStringContent("", Windows.Storage.Streams.UnicodeEncoding.Utf8, "application/json");
                HttpResponseMessage message = await client.PutAsync(uri, content);
                message.EnsureSuccessStatusCode();
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
