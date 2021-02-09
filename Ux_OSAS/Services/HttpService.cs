using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Ux_OSAS.Entities;

namespace Ux_OSAS.Services
{
    public class HttpService : IHttpService
    {
        public HttpClient client = new HttpClient();
        public HttpService()
        {
            client.BaseAddress = new Uri("https://api.covid19api.com/country/");
        }

        public async Task<List<CovidCountries>> GetCovidData(string country)
        {
            return await client.GetFromJsonAsync<List<CovidCountries>>($"{client.BaseAddress}{country}/status/confirmed");
        }
    }
}
