using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shopper_Entity
{
    public class District
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int CityId { get; set; }
        public virtual City City { get; set; }

    }
}
