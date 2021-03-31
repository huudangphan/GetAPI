using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Models
{
    public class AccountContext:DbContext
    {
        public AccountContext(DbContextOptions<AccountContext> options)
           : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Account> Account { get; set; }
    }
}
