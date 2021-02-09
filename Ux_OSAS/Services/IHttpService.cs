using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ux_OSAS.Entities;

namespace Ux_OSAS.Services
{
    public interface IHttpService
    {
        Task<List<CovidCountries>> GetCovidData(string country);
    }
}
