using System;
using Orchard;
using Orchard.Widgets.Services;

namespace Urbanit.CultureLayerRule.RuleEngine
{
    public class CulturedRuleProvider : IRuleProvider {

        private readonly IOrchardServices _services;
        public CulturedRuleProvider(IOrchardServices services)
        {
            _services = services;
        }

        public void Process(RuleContext ruleContext) {
            if (!String.Equals(ruleContext.FunctionName, "culture", StringComparison.OrdinalIgnoreCase)) {
                return;
            }

            var ruleCulture = Convert.ToString(ruleContext.Arguments[0]);

            IWorkContextAccessor ContextManager = _services.WorkContext.Resolve<IWorkContextAccessor>(); 
            var siteCulture = ContextManager.GetContext().CurrentCulture;


            ruleContext.Result = String.Equals(ruleCulture, siteCulture, StringComparison.OrdinalIgnoreCase);
        }
    }
}