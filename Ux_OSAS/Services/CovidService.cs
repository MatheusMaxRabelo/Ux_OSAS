using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ux_OSAS.Entities;
using Ux_OSAS.ViewModel;

namespace Ux_OSAS.Services
{
    public class CovidService : ICovidService
    {
        private readonly IMapper _mapper;
        private readonly IHttpService _httpService;

        public CovidService(IMapper mapper, IHttpService httpService)
        {
            _mapper = mapper;
            _httpService = httpService;
        }

        public async Task<List<Covid>> GetCovidData(string country)
        {
            var list = await _httpService.GetCovidData(country);
            var covids = _mapper.Map<List<CovidCountries>, List<Covid>>(AjustData(list));
            return covids;
        }
        private List<CovidCountries> AjustData(List<CovidCountries> Data)
        {
            List<CovidCountries> result = new List<CovidCountries>();

            var list = from country in Data
                       group country by country.Date.ToString("yyyy/MM") into egroup
                       orderby egroup.Key ascending
                       select new
                       {
                           key = egroup.Key,
                           Cases = egroup.OrderBy(x => x.Date)
                       };

            foreach (var item in list)
            {
                result.Add(item.Cases.Where(x => x.Cases == item.Cases.Max(x => x.Cases)).FirstOrDefault());
            }

            for (int i = 1; i < result.Count; i++)
            {
                result[i].Cases -= result[i - 1].Cases;
            }

            return result;
        }
    }
}
