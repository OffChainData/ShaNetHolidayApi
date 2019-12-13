using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShaNetHoliday.Engine.Standard;
using ShaNetHoliday.Models;
using ShaNetHolidayApi.Models;

namespace ShaNetHolidayApi.Services
{
    public class HolidayService
    {
        public List<HolidayModel> GetHolidays(int startYear, int endYear)
        {
            List<HolidayModel> result = new List<HolidayModel>();
            for (int i = startYear; i <= endYear; i++)
            {
                result.AddRange(GetHolidaysByYear(i));
            }

            return result;
        }

        public List<HolidayModel> GetHolidaysByYear(int year)
        {
            var countriesAvailable = HolidaySystem.Instance.CountriesAvailable;
            List<HolidayModel> result = new List<HolidayModel>();
            foreach (Country country in countriesAvailable)
            {
                if (country.States.Any())
                {
                    foreach (var state in country.States)
                    {
                        var holidays = HolidaySystem.Instance.All(year, country.Alpha2Code, state.Code, RuleType.All);
                        if (holidays.Any())
                        {
                            var holidayList = GetCustomHolidayModel(holidays, country.Alpha2Code.ToString(), country.Languages.FirstOrDefault(), state.Code.ToString());
                            result.AddRange(holidayList);
                        }
                    }
                }
                else
                {
                    var holidays = HolidaySystem.Instance.All(year, country.Alpha2Code, RuleType.All);
                    if (holidays.Any())
                    {
                        var holidayList = GetCustomHolidayModel(holidays, country.Alpha2Code.ToString(), country.Languages.FirstOrDefault());
                        result.AddRange(holidayList);
                    }
                }
            }

            return result;
        }

        public IEnumerable<HolidayModel> GetCustomHolidayModel(IEnumerable<SpecificDay> holidayList, string countryCode, Language language, string subDivisionCode = "")
        {
            return holidayList.Select(x => new HolidayModel()
            {
                HolidayName = string.IsNullOrWhiteSpace(x.Names.FirstOrDefault().Value.Official) ? x.Names.FirstOrDefault().Value.Common : x.Names.FirstOrDefault().Value.Official,
                CountryCode = countryCode,
                Date = x.Date,
                SubDivisionCode = subDivisionCode,
                Type = x.Type.ToString()
            });
        }
    }
}
