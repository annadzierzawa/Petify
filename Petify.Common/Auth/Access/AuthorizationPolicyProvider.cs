using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using Petify.Common.Auth.Access.Lookups;

namespace Petify.Common.Auth.Access
{
    public class AuthorizationPolicyProvider : DefaultAuthorizationPolicyProvider
    {
        private readonly AuthorizationOptions _options;

        public AuthorizationPolicyProvider(IOptions<AuthorizationOptions> options) : base(options)
        {
            _options = options.Value;
        }

        public override async Task<AuthorizationPolicy> GetPolicyAsync(string policyName)
        {
            var policy = await base.GetPolicyAsync(policyName);

            if (policy == null)
            {
                Enum.TryParse(policyName.Split(":")[0], out Actions actions);
                var policyRequiredLevel = new AccessLevel(policyName.Split(":")[1]);

                policy = new AuthorizationPolicyBuilder()
                    .AddRequirements(new RequireAccessLevelRequirement(actions, policyRequiredLevel))
                    .Build();

                _options.AddPolicy(policyName, policy);
            }

            return policy;
        }
    }
}
