using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShaNetHolidayApi.Models
{
    public class HolidayModel
    {
        public string HolidayName { get; set; }
        public DateTime Date { get; set; }
        public string CountryCode { get; set; }
        public string SubDivisionCode { get; set; }
        public string Type { get; set; }
    }
}
