using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoungeMVC.Models
{
    public class Tobacco
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public int Price { get; set;}
        public string Name { get; set; }
        public string Taste { get; set; }
        public int Weight { get; set; }
        public string Description { get; set; }

        public int? OrderId { get; set; }
        public Order Order { get; set; }
    }
}
