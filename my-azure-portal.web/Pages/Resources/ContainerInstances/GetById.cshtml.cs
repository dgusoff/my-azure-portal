using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity.Web;
using my_portal.models;

namespace my_azure_portal.web.Pages.Resources.ContainerInstances
{
    public class GetByIdModel : PageModel
    {
        private string accessToken;

        public IResourceGroupData Data { get; }
        public ITokenAcquisition TokenAcquisition { get; }
        public GetByIdModel(IResourceGroupData data, ITokenAcquisition tokenAcquisition)
        {
            Data = data;
            TokenAcquisition = tokenAcquisition;
        }

        

        public async Task OnGet(string resourceId)
        {
            this.accessToken = await TokenAcquisition.GetAccessTokenForUserAsync(new[] { $"https://management.core.windows.net/user_impersonation" });

            var result = await Data.GetContainerGroupById(resourceId, this.accessToken);
        }
    }
}