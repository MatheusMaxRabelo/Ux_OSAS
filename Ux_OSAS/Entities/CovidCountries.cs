﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ux_OSAS.Entities
{
    public class CovidCountries
    {
        public string Country { get; set; }
        public string CountryCode { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string CityCode { get; set; }
        public string Lat { get; set; }
        public string Lon { get; set; }
        public int Cases { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; }

    }
}
