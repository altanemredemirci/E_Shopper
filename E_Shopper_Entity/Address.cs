using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shopper_Entity
{
    public class Address
    {
        public int Id { get; set; }
        [Required,StringLength(20)]
        public string AdresBasligi { get; set; }
        [StringLength(50)]
        public string Ad { get; set; }
        [StringLength(50)]      
        public string Soyad { get; set; }
        [Required, StringLength(100)]
        public string Email { get; set; }
        [Required, StringLength(20)]
        public string TelefonNumarasi { get; set; }
        [Required, StringLength(2000)]
        public string Adres { get; set; }
        [Required, StringLength(30)]
        public string Il { get; set; }
        [Required, StringLength(30)]
        public string Ilce { get; set; }
        [Required, StringLength(30)]
        public string Mahalle { get; set; }
        [Required, StringLength(10)]
        public string PostaKodu { get; set; }       
    }
}
