using Domains.CustomeAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains
{
    public class Order : BaseEntity
    {
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(100)]
        public string CustomerName { get; set; }
        [Required]
        public int ItemId { get; set; }
        [Required]
        [MaxLength(100)]
        [MinLength(1)]
        public string ItemName { get; set; }
        [Required]
        [Range(10, 500)]
        public decimal Price { get; set; }
        [Required]
        [Range(1, 1000)]
        public int Quantity { get; set; }
    }
}
