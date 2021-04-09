using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookAPI.API_s;
using Microsoft.AspNetCore.Mvc;


namespace BookAPI.Controllers
{
    [APIKey]
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleSecretController
    {
        QuerySchedule s = new QuerySchedule();
        Query acc = new Query();
        [HttpGet(template:"schedule")]
        public string getSchedule()
        {
            return s.GetAllSchedule();
        }
        [HttpGet("{username}/{password}")]
        public string getScheduleByUserID( string username, string password)
        {
            return s.GetScheduleByUserID(username, password);
        }
        [HttpGet("{id}")]
        public string getScheduleByID(int id, int userID)
        {
            return s.GetScheduleByID(id, userID);
        }
        [HttpPost]
        public void addSchedule(int userid, string day, string time, string job)
        {
            s.AddSchedule(userid, day, time, job);
        }
        [HttpPut]
        public void UpdateSchedule(int id, int userID, string day, string time, string job)
        {
            s.UpdateSchedule(id, userID, day, time, job);
        }
        [HttpDelete("{id}")]
        public void DeleteSchedule( int id)
        {
            s.DeleteSchedule(id);
        }
        // account
        //[HttpGet("{username}/{password}")]
        //public string login(string username, string password)
        //{
        //    return acc.Login(username, password);
        //}
        //[HttpPost]
        //public void AddAccount(string username, string password)
        //{
        //    acc.AddAccount(username, password);
        //}
        //[HttpPut]
        //public void updateAccount(string username, string password)
        //{
        //    acc.UpdateAccount(username, password);
        //}
    }
}
