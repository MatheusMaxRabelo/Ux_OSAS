using AutoMapper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ux_OSAS.Entities;
using Ux_OSAS.ViewModel;

namespace Ux_OSAS.Automapper
{
    public class ModelToResourceProfile : Profile
    {
        const string Culture = "pt-BR";
        public DateTimeFormatInfo DateInfo { get; set; } = new CultureInfo(Culture).DateTimeFormat;
        public ModelToResourceProfile()
        {
            CreateMap<CovidCountries, Covid>()
                .ForMember(dest => dest.Month, opt => opt.MapFrom(src => new CultureInfo(Culture).TextInfo.ToTitleCase(DateInfo.GetMonthName(src.Date.Month))))
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src =>src.Date.Year));

        }
    }
}
