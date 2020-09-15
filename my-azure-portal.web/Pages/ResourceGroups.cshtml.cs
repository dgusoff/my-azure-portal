using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Web;
using my_portal.models;

namespace my_azure_portal.web.Pages
{
    public class SubscriptionsModel : PageModel
    {
        readonly ITokenAcquisition tokenAcquisition;
        private readonly ILogger<IndexModel> _logger;
        readonly IResourceGroupData data;
        public IEnumerable<ResourceGroup> ResourceGroups { get; set; }
        public string accessToken { get; set; }
        public string ResourceGroupJson { get; set; }

        public SubscriptionsModel(IResourceGroupData data, ITokenAcquisition tokenAcquisition, ILogger<IndexModel> logger)
        {
            _logger = logger;
            this.tokenAcquisition = tokenAcquisition;
            this.data = data;            
        }

        //public async Task OnGet()
        //{
        //    this.accessToken = await tokenAcquisition.GetAccessTokenForUserAsync(new[] { $"https://management.core.windows.net/user_impersonation" });

        //    this.ResourceGroups = await data.GetAllResourceGroupsBySubscription("d8370cf8-b42d-42f9-96d1-542d0498972f", accessToken);
        //}

        public async Task OnGet(string subscriptionId)
        {
            this.accessToken = await tokenAcquisition.GetAccessTokenForUserAsync(new[] { $"https://management.core.windows.net/user_impersonation" });

            this.ResourceGroups = await data.GetAllResourceGroupsBySubscription(subscriptionId, accessToken);
        }
    }
}