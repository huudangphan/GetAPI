using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookAPI.Models;


namespace BookAPI.Repositories
{
    public interface ICongViecRepository
    {
        Task<IEnumerable<CongViec>> Get();
        List<CongViec> Get(int user_id);
        Task<CongViec> Create(CongViec cv);
        Task Update(CongViec cv);
        Task Delete(int id);

        List<CongViec> Get(int user_id,int id);
        
    }
}
