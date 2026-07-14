using Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domains.CustomeAttributes;

namespace DAL
{
    public class Item : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        [MinLength(1)]
        public string Name { get; set; }
        [Required]
        [Range(10 , 500)]
        public decimal Price { get; set; }
        [Required]
        [Range(1, 1000)]
        public int Quantity { get; set; }
    }
}
