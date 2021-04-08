using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookAPI.API_s;
using Microsoft.AspNetCore.Mvc;
namespace BookAPI.Controllers
{
    [APIKey]
    public class SecretScheduleController:ControllerBase
    {
        QuerySchedule s = new QuerySchedule();
        [HttpGet(template: "secretSchedule")]
        public string getSchedule()
        {
            return s.GetAllSchedule();
        }
        //[HttpGet("{username}/{password}")]
        //public string getScheduleByUserID(string username, string password)
        //{
        //    return s.GetScheduleByUserID(username, password);
        //}
        //[HttpGet("{id}")]
        //public string getScheduleByID(int id, int userID)
        //{
        //    return s.GetScheduleByID(id, userID);
        //}
        //[HttpPost]
        //public void addSchedule(int userid, string day, string time, string job)
        //{
        //    s.AddSchedule(userid, day, time, job);
        //}
        //[HttpPut]
        //public void UpdateSchedule(int id, int userID, string day, string time, string job)
        //{
        //    s.UpdateSchedule(id, userID, day, time, job);
        //}
        //[HttpDelete("{id}")]
        //public void DeleteSchedule(int id)
        //{
        //    s.DeleteSchedule(id);
        //}
    }
}
