using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shopper_Entity
{
    public enum Types { Erkek = 1, Kadın, Çocuk }

    public class Product:BaseEntity
    {        
        [DisplayName("Başlık")]
        public string Title { get; set; }

        [DisplayName("Fiyat")]
        public double Price { get; set; }

        [DisplayName("Stok Bilgisi")]
        public bool InStock { get; set; }   

        [DisplayName("Adet")]
        public int Quantity { get; set; }       

        public string Image { get; set; }

        public Types Type { get; set; }

        [DisplayName("Taslak")]
        public bool IsDraft { get; set; }

        public bool IsHome { get; set; }

        public int BrandId { get; set; }
        public virtual Brand Brand { get; set; }
    }
}
