using CP.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CP.Services.DiscretionaryRulesService
{
    public interface IDiscretionaryRulesService
    {
        public Task CreateOrUpdateRules(CustomerViewModel model);
    }
}
