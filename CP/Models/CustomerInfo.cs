using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CP.Models
{
    public class CustomerInfo
    {
        [Key]
        public int CustomerInfoId { get; set; }
        [Required]
        public int ConsultantInfoId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public DateTime DOB { get; set; }
        public string MobileNo { get; set; }
        public string EmailAddress { get; set; }
        public ICollection<DiscretionaryRules> DiscretionaryRules { get; set; }
    }
}
