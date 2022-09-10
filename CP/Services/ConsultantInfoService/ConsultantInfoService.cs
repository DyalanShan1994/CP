using CP.DbContexts;
using CP.Models;
using CP.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CP.Services.ConsultantInfoService
{
    public class ConsultantInfoService : IConsultantInfoService
    {
        private readonly CpContext _context;

        public ConsultantInfoService(CpContext context)
        {
            _context = context;
        }

        public async Task<ConsultantViewModel> GetFirstConsultantInfo()
        {
            var firstConsultant = await _context.ConsultantInfo.Select(x => new ConsultantViewModel(x)).FirstOrDefaultAsync();
            if (firstConsultant == null || firstConsultant.ConsultantInfoId == null)
            {
                firstConsultant = await AddConsultantDummyInfo();
            }

            return firstConsultant;
        }

        private async Task<ConsultantViewModel> AddConsultantDummyInfo()
        {
            var dummyConsultant = new ConsultantInfo();
            dummyConsultant.FirstName = "Kylian";
            dummyConsultant.LastName = "George";
            dummyConsultant.EmailAddress = "kylian@george.com";
            dummyConsultant.MobileNo = "0122133311";

            _context.Add(dummyConsultant);
            var result = await _context.SaveChangesAsync();

            if(result <=  0)
            {
                throw new Exception("Unable to add Consultant Info.");
            }

            var firstConsultant = await _context.ConsultantInfo.Select(x => new ConsultantViewModel(x)).FirstOrDefaultAsync();

            return firstConsultant;
        }
    }
}
