using BookAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Repositories
{
    public interface IAccountRepository
    {
        Task<IEnumerable<Account>> Get();
        Task<Account> Get(int id);
        Task<Account> Create(Account acc);
        Task Update(Account acc);
        Task Delete(int id);
        List<Account> Login( string username,string password);
        List<Account> Login2(int id, string username, string password);

    }
}
