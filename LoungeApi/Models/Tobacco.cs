using LoungeApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoungeApi.Models
{
    public class Tobacco:IArticle
    {
        public int Id { get; set; }
        public string Image { get; set; }       
        public string Name { get; set; }
        public string Taste { get; set; }
        public int Weight { get; set; }
        public string Description { get; set; }

        public int? OrderId { get; set; }
        public Order Order { get; set; }
        
    }
}
