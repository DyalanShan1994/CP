using CP.Services;
using CP.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CP.Controllers
{
    [AllowAnonymous]
    [Produces("application/json")]
    [Route("api/CustomerInfo")]
    public class CustomerInfoController : Controller
    {
        private readonly ICustomerInfoService _customerInfoService;

        public CustomerInfoController(ICustomerInfoService customerInfoService)
        {
            _customerInfoService = customerInfoService;
        }

        [HttpGet("GetCustomerList")]
        public async Task<IActionResult> GetCustomerList()
        {
            var result = await _customerInfoService.GetCustomerList();
            return new OkObjectResult(result);
        }

        [HttpPut("CreateOrUpdateCustomer")]
        public async Task<IActionResult> CreateOrUpdateCustomer([FromBody] CustomerViewModel requestModel)
        {
            var result = await _customerInfoService.CreateOrUpdateCustomer(requestModel);
            return new OkObjectResult(result);
        }
    }
}
