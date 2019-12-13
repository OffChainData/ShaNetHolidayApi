using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EdjCase.JsonRpc.Router;
using Microsoft.AspNetCore.Mvc;
using ShaNetHolidayApi.Models;
using ShaNetHolidayApi.Services;

namespace ShaNetHolidayApi.Controllers
{
    [RpcRoute]
    public class HolidayController : RpcController
    {
        public HolidayService holidayService;
        public HolidayController()
        {
            this.holidayService = new HolidayService();
        }
        
        public List<HolidayModel> PublicHolidays(int startYear, int endYear)
        {
            return holidayService.GetHolidays(startYear, endYear);
        }
        
    }
}
