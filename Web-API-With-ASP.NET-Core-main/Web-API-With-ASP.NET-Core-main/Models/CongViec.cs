using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Models
{
    public class CongViec
    {
        public int Id { get; set; }
        public int user_id { get; set; }
        public string Day { get; set; }
        public string ThoiGian { get; set; }
        public string viec { get; set; }
    }
}
