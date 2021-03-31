using BookAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AccountContext _context;
        public AccountRepository(AccountContext context)
        {
            _context = context;
        }
        public async Task<Account> Create(Account acc)
        {
            _context.Account.Add(acc);
            await _context.SaveChangesAsync();
            return acc;
        }

        public async Task Delete(int id)
        {
            var accDelete = await _context.Account.FindAsync(id);
            _context.Account.Remove(accDelete);
            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<Account>> Get()
        {
            return await _context.Account.ToListAsync();
        }

        public async Task<Account> Get(int id)
        {
            return await _context.Account.FindAsync(id);
        }

        public  List<Account> Login(string username,string password)
        {
            return _context.Account.Where(x => x.Username == username && x.Password == password).ToList();

        }

        public List<Account> Login2(int id, string username, string password)
        {
            return _context.Account.Where(x => x.Username == username && x.Password == password&&x.Id==id).ToList();
        }

        public async Task Update(Account acc)
        {
            _context.Entry(acc).State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }
        
        //public async Task<Account> Login(string username, string password)
        //{
            
        //    return await _context.Account.FindAsync(new object[] { username, password });
        //}
    }
}
