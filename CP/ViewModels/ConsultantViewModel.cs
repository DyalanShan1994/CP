using CP.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CP.ViewModels
{
    public class ConsultantViewModel
    {
        [JsonProperty("consultantInfoId")]
        public int? ConsultantInfoId { get; set; }
        [JsonProperty("firstName")]
        public string FirstName { get; set; }
        [JsonProperty("lastName")]
        public string LastName { get; set; }
        [JsonProperty("emailAddress")]
        public string EmailAddress { get; set; }
        [JsonProperty("mobileNo")]
        public string MobileNo { get; set; }

        public ConsultantViewModel(ConsultantInfo model)
        {
            ConsultantInfoId = model.ConsultantInfoId;
            FirstName = model.FirstName;
            LastName = model.LastName;
            EmailAddress = model.EmailAddress;
            MobileNo = model.MobileNo;
        }
    }
}
