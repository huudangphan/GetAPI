using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookAPI.Repositories;
using BookAPI.Models;

using System.Data;
using BookAPI.API_s;

namespace BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CongViecController : ControllerBase
    {
        #region a
        //private readonly ICongViecRepository _congViecRepository;
        //public CongViecController(ICongViecRepository congViecRepository)
        //{
        //    _congViecRepository = congViecRepository;
        //}
        //[HttpGet]
        //public async Task<IEnumerable<CongViec>> GetCongViec()

        //{
        //    return await _congViecRepository.Get();
        //}
        //[HttpGet("{user_id}")]
        //public ActionResult<List<CongViec>> Get(int user_id)
        //{
        //    return _congViecRepository.Get(user_id);
        //}


        //[HttpGet("{user_id}/{id}")]
        //public ActionResult<List<CongViec>> GetCV(int user_id, int id)
        //{
        //    return _congViecRepository.Get(user_id,id);
        //}
        //[HttpPost]
        //public async Task<ActionResult<CongViec>> PostCongViec([FromBody] CongViec cv)
        //{
        //    var newCv = await _congViecRepository.Create(cv);
        //    return CreatedAtAction(nameof(GetCongViec), new { id = cv.Id, user_id = cv.user_id, day = cv.Day, thoigian = cv.ThoiGian }, newCv);
        //}
        //[HttpPut("{id}")]
        //public async Task<ActionResult> PutCongViec(int id, [FromBody] CongViec cv)
        //{
        //    if (id != cv.Id)
        //    {
        //        return BadRequest();
        //    }

        //    await _congViecRepository.Update(cv);

        //    return NoContent();
        //}

        //[HttpDelete("{id}")]
        //public async Task<ActionResult> Delete(int id)
        //{
        //    var cvToDelete = Get(id);
        //    if (cvToDelete == null)
        //        return NotFound();

        //    await _congViecRepository.Delete(id);
        //    return NoContent();
        //}
        #endregion
        QuerySchedule s = new QuerySchedule();
        [HttpGet]
        public string getSchedule()
        {
            return s.GetAllSchedule();
        }
        //[HttpGet("{id}/{userID}")]
        //public string getSchedulebyiD(int id,int userid)
        //{
        //    return s.GetScheduleByID(id, userid);
        //}
        [HttpGet("{userID}")]
        public string getScheduleByUserID(int userID)
        {
            return s.GetScheduleByUserID(userID);
        }
        [HttpPost("{userid}/{day}/{time}/{job}")]
        public void addSchedule(int userid,string day,string time,string job)
        {
            s.AddSchedule(userid, day, time, job);
        }
        [HttpPut]
        public void UpdateSchedule(int id,int userID,string day,string time,string job)
        {
            s.UpdateSchedule(id, userID, day, time, job);
        }
        [HttpDelete("{id}")]
        public void DeleteSchedule(int id)
        {
            s.DeleteSchedule(id);
        }
    }
}
