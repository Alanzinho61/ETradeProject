using ETrade.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace ETrade.Model.Entities
{
    public class Category : CoreEntity
    {
        public string CategoryName { get; set; } = string.Empty;
        public string CategoryDescription { get; set; } = string.Empty;

        // Tablo baglantisi burada yapiliyor (iki tablo birbiriyle baglaniyor)
        public ICollection<Product> Products { get; set; }
    }
}
