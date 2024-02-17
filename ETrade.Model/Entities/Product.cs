using ETrade.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Model.Entities
{
    public class Product : CoreEntity
    {
        public string ProductName { get; set; } = string.Empty;
        public decimal ProductPrice { get; set; }
        public int ProductStock { get; set; }
        public string ProductDescription { get; set; } = string.Empty;
        public string ImagePath { get; set; }
        public int CategoryId { get; set; } // ForeingKey
        public Category Category { get; set; } //Siralamasi onemli baglanti burada oluyir
        


    }
}
