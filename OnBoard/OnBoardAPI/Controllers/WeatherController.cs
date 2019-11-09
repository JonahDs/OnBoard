using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OnBoardAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        public async Task<ActionResult> GetForeCastAsync()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync(new Uri("http://dataservice.accuweather.com/forecasts/v1/daily/1day/2325604?apikey=QQNG7cuoNmPQVt0NA2MKbgagkN6Zausm&language=en-us&details=true"));
            return new OkObjectResult(response);
        }
    }
}