using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity.Web;
using my_portal.models;

namespace my_azure_portal.web.Pages.Resources
{
    public class ListByResourceGroupModel : PageModel
    {
        private string accessToken;
        public IEnumerable<Resource> Resources { get; set; }
        public string Json { get; set; }

        public ListByResourceGroupModel(IResourceGroupData data, ITokenAcquisition tokenAcquisition)
        {
            Data = data;
            TokenAcquisition = tokenAcquisition;
        }

        public IResourceGroupData Data { get; }
        public ITokenAcquisition TokenAcquisition { get; }

        public async Task OnGet(string subscriptionId, string resourceGroupName)
        {
            this.accessToken = await TokenAcquisition.GetAccessTokenForUserAsync(new[] { $"https://management.core.windows.net/user_impersonation" });

            Resources = await Data.GetAllResourcesBySubscription(subscriptionId, resourceGroupName, accessToken);
        }
    }
}