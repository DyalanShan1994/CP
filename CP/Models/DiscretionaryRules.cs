using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CP.Models
{
    public class DiscretionaryRules
    {
        [Key]
        public int DiscretionaryRuleId { get; set; }
        [Required]
        public int ConsultantInfoId { get; set; }
        [ForeignKey("ConsultantInfoId")]
        public virtual ConsultantInfo ConsultantInfo { get; set; }
        [Required]    
        public int CustomerInfoId { get; set; }
        [ForeignKey("CustomerInfoId")]
        public virtual CustomerInfo CustomerInfo { get; set; }
        [Column(TypeName = "xml")]
        public string Rules { get; set; }
        public bool CustomerBuy { get; set; }
        public bool CustomerSell { get; set; }
        public bool ConsultantBuy { get; set; }
        public bool ConsultantSell { get; set; }


        [NotMapped]
        public XElement RulesXml
        {
            get { return XElement.Parse(Rules); }
            set { Rules = value.ToString(); }
        }
    }
}
