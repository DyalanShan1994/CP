using CP.DbContexts;
using CP.Models;
using CP.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CP.Services.DiscretionaryRulesService
{
    public class DiscretionaryRulesService : IDiscretionaryRulesService
    {
        private readonly CpContext _context;

        public DiscretionaryRulesService(CpContext context)
        {
            _context = context;
        }

        public async Task CreateOrUpdateRules(CustomerViewModel model)
        {
            var discretionaryRule = await _context.DiscretionaryRules
                                    .FirstOrDefaultAsync(x => x.ConsultantInfoId == model.ConsultantInfoId && x.CustomerInfoId == model.CustomerId)
                                    ?? new DiscretionaryRules();
            var isNewRecord = discretionaryRule.DiscretionaryRuleId == 0;

            if (isNewRecord)
            {
                discretionaryRule.CustomerInfoId = (int)model.CustomerId;
                discretionaryRule.ConsultantInfoId = (int)model.ConsultantInfoId;               
            }

            discretionaryRule.CustomerBuy = model.CustomerBuy ?? false;
            discretionaryRule.CustomerSell = model.CustomerSell ?? false;
            discretionaryRule.ConsultantBuy = model.ConsultantBuy ?? false;
            discretionaryRule.ConsultantSell = model.ConsultantSell ?? false;

            if (isNewRecord)
                _context.DiscretionaryRules.Add(discretionaryRule);

            await _context.SaveChangesAsync();
        }
    }
}
