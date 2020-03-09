using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoungeMVC.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string User { get; set; } // Імя покупця
        public string Address { get; set; } // Адрес Покупця
        public string ContactPhone { get; set; } // Контактний номер покупця
        public int TobaccoId { get; set; }
        public Tobacco Tobacco { get; set; }
    }
}
