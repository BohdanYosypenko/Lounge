using LoungeMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoungeMVC.Interfaces
{
    public interface IGetAllTobacco
    {
        public IEnumerable<Tobacco> AllTobacco { get;  }

        public Tobacco GetTobacco(int Id);
                    
        
    }
}
