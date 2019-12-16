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
    public class WeatherViewModel : BindableBase
    {
        private HttpClient client = new HttpClient();
        private ObservableCollection<Weather> _weathers;
        public ObservableCollection<Weather> WeatherForecast {
            get {
                return _weathers;
            }
            set {
                Set(ref _weathers, value);
            }
        }

        public WeatherViewModel()
        {
            WeatherForecast = new ObservableCollection<Weather>();
            GetWeatherInformation();
        }

        /// <summary>
        /// gets the forecast of the destination for the upcoming 5 days
        /// </summary>
        public async void GetWeatherInformation()
        {   
            Uri requestUri = new Uri("http://dataservice.accuweather.com/forecasts/v1/daily/5day/2325604?apikey=QQNG7cuoNmPQVt0NA2MKbgagkN6Zausm&details=false&metric=false");
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
        /// only pick certain parts of the json response and set them to a object
        /// </summary>
        /// <param name="httpResponseBody"></param>
        public void MorphRequest(string httpResponseBody)
        {
            JObject weather = JObject.Parse(httpResponseBody);
            IList<JToken> dates = weather["DailyForecasts"].Children().ToList();
            dates.ToList().ForEach(date =>
            {   
                JToken localDate = date["Date"];
                JToken localTempMin = date["Temperature"]["Minimum"]["Value"];
                JToken localTempMax = date["Temperature"]["Maximum"]["Value"];
                JToken localTempIcon = date["Day"]["Icon"];
                JToken localTempPhrase = date["Day"]["IconPhrase"];
                Weather localWeather = new Weather
                {
                    Date = (DateTime)localDate,
                    MinTemperature = (int)localTempMin,
                    MaxTemperature = (int)localTempMax,
                    DayIcon = (int)localTempIcon,
                    DayPhrase = (string)localTempPhrase
                };
                WeatherForecast.Add(localWeather);
            });
        }


    }
}
