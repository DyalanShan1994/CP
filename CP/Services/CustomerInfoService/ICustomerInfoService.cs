using CP.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CP.Services
{
    public interface ICustomerInfoService
    {
        public Task<List<CustomerViewModel>> GetCustomerList();
        public Task<CustomerViewModel> CreateOrUpdateCustomer(CustomerViewModel requestModel);
    }
}
