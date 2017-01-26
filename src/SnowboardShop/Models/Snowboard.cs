using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnowboardShop.Models
{
    public class Snowboard
    {

        public int ID { get; set; }
        public string name { get; set; }
        public string marque { get; set; }
        public int height { get; set; }
        public string camber { get; set; }
        public string flex { get; set; }
        public string shape { get; set; }
        public decimal price { get; set; }
        public string urlPhoto { get; set; }


    }
}
