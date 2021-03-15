 using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shopper_Entity
{
   public class Category:BaseEntity
    {
        [DisplayName("Kategori"),
            Required(ErrorMessage = "{0} alanı gereklidir."),
            StringLength(50, ErrorMessage = "{0} alanı max. {1} karakter içermeli.")]
        public string Title { get; set; }

        [DisplayName("Açıklama"),
           StringLength(150, ErrorMessage = "{0} alanı max. {1} karakter içermeli.")]
        public string Description { get; set; }

        [DisplayName("Markalar")]
        public virtual ICollection<Brand> Brands { get; set; }

        public Category()
        {
            Brands = new List<Brand>();
        }
    }
}
