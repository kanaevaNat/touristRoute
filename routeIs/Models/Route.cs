using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace routeIs.Models
{
    public class Route
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? DateOfCreate { get; set; }
        public string Comment { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
    }
}
