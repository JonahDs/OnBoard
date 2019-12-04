
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;

namespace OnBoardUWP.Models
{
    public static class GlobalMethods
    {
        public static async Task<T> ApiCall<T>(string uri, HttpClient client) where T : new()
        {
            Uri requestUri = new Uri(uri);
            T localObject = default(T);
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            string httpResponseBody = "";

            try
            {
                httpResponse = await client.GetAsync(requestUri);
                httpResponse.EnsureSuccessStatusCode();
                httpResponseBody = await httpResponse.Content.ReadAsStringAsync();
                localObject = JsonConvert.DeserializeObject<T>(httpResponseBody);
            }
            catch (Exception ex)
            {
                httpResponseBody = "Error: " + ex.HResult.ToString("X") + " Message: " + ex.Message;
            }
            return localObject;
        }

    }

}
