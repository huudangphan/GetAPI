using BookAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookAPI.Repositories
{
    public class CongViecRepository : ICongViecRepository
    {
        private readonly CongViecContext _congViecContext;
        public CongViecRepository(CongViecContext congViecContext)
        {
            _congViecContext = congViecContext;
        }
       
        public async Task<CongViec> Create(CongViec cv)
        {
            _congViecContext.Add(cv);
            await _congViecContext.SaveChangesAsync();
            return cv;

        }

        public async Task Delete(int user_id)
        {
            var cvRemove = await _congViecContext.CongViec.FindAsync(user_id);
            _congViecContext.Remove(cvRemove);
            await _congViecContext.SaveChangesAsync();

        }       

        public async Task<IEnumerable<CongViec>> Get()
        {
            return await _congViecContext.CongViec.ToListAsync();
        }
        #region a
        //public List<CongViec> Get(string user_id)
        //{

        //    return _congViecContext.CongViec.Where(t=>t.user_id == user_id).ToList();

        //}
        //public List<CongViec> Get(string user_id,string day,string time)
        //{
        //    return _congViecContext.CongViec.Where(x => x.user_id == user_id && x.Day == day&&x.ThoiGian==time).ToList();
        //}

        //public List<CongViec> Get(string user_id, string day)
        //{
        //    return _congViecContext.CongViec.Where(x => x.user_id == user_id && x.Day == day).ToList();
        //}
        #endregion
               

        

        public List<CongViec> Get(int user_id)
        {
            return _congViecContext.CongViec.Where(x => x.user_id == user_id).ToList();
        }

        public List<CongViec> Get(int user_id, int id)
        {
            return _congViecContext.CongViec.Where(x => x.Id == id && x.user_id == user_id).ToList();
        }

        //public async Task<CongViec> GetCV(int id)
        //{
        //    return await _congViecContext.CongViec.FindAsync(id);
        //}

        public async Task Update(CongViec cv)
        {
            _congViecContext.Entry(cv).State = EntityState.Modified;
            await _congViecContext.SaveChangesAsync();

        }

       
    }
}
