using CP.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CP.Services.ConsultantInfoService
{
    public interface IConsultantInfoService
    {
        public Task<ConsultantViewModel> GetFirstConsultantInfo();
    }
}
