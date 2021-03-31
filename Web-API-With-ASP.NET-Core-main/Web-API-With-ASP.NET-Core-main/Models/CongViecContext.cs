using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Models
{
    public class CongViecContext:DbContext
    {
        public CongViecContext(DbContextOptions<CongViecContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<CongViec> CongViec { get; set; }
    }
}
