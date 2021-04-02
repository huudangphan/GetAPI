using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.API_s
{
    public class Schedule
    {
        public int id { get; set; }
        public int userID { get; set; }
        public string day { get; set; }
        public string time { get; set; }
        public string job { get; set; }
    }
}
