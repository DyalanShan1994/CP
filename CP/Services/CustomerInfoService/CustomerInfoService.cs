using CP.DbContexts;
using CP.Models;
using CP.Services.ConsultantInfoService;
using CP.Services.DiscretionaryRulesService;
using CP.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CP.Services
{
    public class CustomerInfoService : ICustomerInfoService
    {
        private readonly CpContext _context;
        private readonly IConsultantInfoService _consultantInfoService;
        private readonly IDiscretionaryRulesService _discretionaryRulesService;

        public CustomerInfoService(CpContext context, IConsultantInfoService consultantInfoService, IDiscretionaryRulesService discretionaryRulesService)
        {
            _context = context;
            _consultantInfoService = consultantInfoService;
            _discretionaryRulesService = discretionaryRulesService;
        }

        public async Task<List<CustomerViewModel>> GetCustomerList()
        {
            var customerList = await _context.CustomerInfo
                                .Include(x => x.DiscretionaryRules)
                                .Select(x => new CustomerViewModel(x)).ToListAsync();

            return customerList;
        }

        public async Task<CustomerViewModel> CreateOrUpdateCustomer(CustomerViewModel viewModel)
        {
           if(viewModel == null)
            {
                throw new Exception("Invalid Request Details");
            }

            var customerInfo = await _context.CustomerInfo
                                .FirstOrDefaultAsync(x => x.CustomerInfoId == viewModel.CustomerId) 
                                ?? new CustomerInfo();
            var isAdd = customerInfo?.CustomerInfoId == 0;

            if(customerInfo?.ConsultantInfoId == 0)
            {
                var firstConsultant = await _consultantInfoService.GetFirstConsultantInfo();
                customerInfo.ConsultantInfoId = (int)firstConsultant.ConsultantInfoId;
                viewModel.ConsultantInfoId = customerInfo.ConsultantInfoId;
            }

            if(isAdd)
                _context.CustomerInfo.Add(customerInfo);

            var result = await _context.SaveChangesAsync();
            if(result >= 0)
            {
                viewModel.CustomerId = customerInfo.CustomerInfoId;
                await _discretionaryRulesService.CreateOrUpdateRules(viewModel);
            }

            return new CustomerViewModel(customerInfo);
        }
    }
}
