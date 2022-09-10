using CP.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CP.ViewModels
{
    public class CustomerViewModel
    {
        [JsonProperty("customerId")]
        public int? CustomerId { get; set; }
        [JsonProperty("consultantInfoId")]
        public int? ConsultantInfoId { get; set; }
        [JsonProperty("customerBuy")]
        public bool? CustomerBuy { get; set; }
        [JsonProperty("customerSell")]
        public bool? CustomerSell { get; set; }
        [JsonProperty("consultantBuy")]
        public bool? ConsultantBuy { get; set; }
        [JsonProperty("consultantSell")]
        public bool? ConsultantSell { get; set; }

        public CustomerViewModel()
        {

        }
        public CustomerViewModel(CustomerInfo model)
        {
            CustomerId = model.CustomerInfoId;
            ConsultantInfoId = model.ConsultantInfoId;
            CustomerBuy = model.DiscretionaryRules?.FirstOrDefault(x => x.CustomerInfoId == CustomerId && x.ConsultantInfoId == ConsultantInfoId)?.CustomerBuy;
            CustomerSell = model.DiscretionaryRules?.FirstOrDefault(x => x.CustomerInfoId == CustomerId && x.ConsultantInfoId == ConsultantInfoId)?.CustomerSell;
            ConsultantBuy = model.DiscretionaryRules?.FirstOrDefault(x => x.CustomerInfoId == CustomerId && x.ConsultantInfoId == ConsultantInfoId)?.ConsultantBuy;
            ConsultantSell = model.DiscretionaryRules?.FirstOrDefault(x => x.CustomerInfoId == CustomerId && x.ConsultantInfoId == ConsultantInfoId)?.ConsultantSell;
        }
    }
}
