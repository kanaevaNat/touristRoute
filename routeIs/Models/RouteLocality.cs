using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace routeIs.Models
{
    public class RouteLocality
    {
        public int Id { get; set; }
        public int? IdRoute { get; set; }
        public Route Route { get; set; }
        public int? IdLocality { get; set; }
        public Locality Locality { get; set; }
    }
}
