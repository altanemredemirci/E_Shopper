using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shopper_Entity
{
    public class Brand:BaseEntity
    {
        [DisplayName("Marka")]
        public string Name { get; set; }

        [DisplayName("Ürünler")]
        public List<Product> Products { get; set; }

        [DisplayName("Kategoriler")]
        public virtual ICollection<Category> Categories { get; set; }

        public Brand()
        {
            Products = new List<Product>();
        }
    }
}
