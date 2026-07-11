using Domains.CustomeAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains
{
    public class Customer : BaseEntity
    {
        [Required]
        [MinLength(5)]
        [MaxLength(100)]
        public string CustomerName { get; set; }
        [Required]
        [Email]
        public string CustomerEmail { get; set; }
        [Required]
        [Phone(12)]
        public string Phone { get; set; }
    }
}
