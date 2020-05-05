using LoungeMVC.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoungeMVC.Client
{
    public class SendKiss : ISender
    {
        public string Send()
        {
            return "Love you:) Kiss";
        }
    }
}
