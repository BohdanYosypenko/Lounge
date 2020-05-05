using LoungeMVC.Interfaces;
using LoungeMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoungeMVC.Client
{
    public class AllTobaccos : IGetAllTobacco
    {
        private WebApiClient<Tobacco> tobaccoApi = WebApiClient<Tobacco>.GetInstance();

        public AllTobaccos(WebApiClient<Tobacco> tobacco)
        {
            tobaccoApi = tobacco;
        }
        public IEnumerable<Tobacco> AllTobacco
        { 
            get 
            {
                return tobaccoApi.Get("tobacco"); 
            } 
        }

        public Tobacco GetTobacco(int Id)
        {
            return tobaccoApi.Get("tobacco", Id); 
        }
        
            
    }
}
