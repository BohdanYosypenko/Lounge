using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoungeApi.Interfaces
{
    public interface IBasket
    {
        public string Name { get; set; }
        public List<IArticle> Articles { get; set; } 

    }
}
