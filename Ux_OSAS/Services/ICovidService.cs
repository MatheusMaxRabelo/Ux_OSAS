using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ux_OSAS.ViewModel;

namespace Ux_OSAS.Services
{
    public interface ICovidService
    {
        Task<List<Covid>> GetCovidData(string country);
    }
}
