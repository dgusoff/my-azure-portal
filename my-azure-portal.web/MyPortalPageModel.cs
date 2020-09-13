using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_azure_portal.web
{
    public class MyPortalPageModel : PageModel
    {
        readonly ITokenAcquisition tokenAcquisition;
        string accessToken;

        public MyPortalPageModel(ITokenAcquisition tokenAcquisition)
        {
            this.tokenAcquisition = tokenAcquisition;        
        }

        protected async void GetAccessToken()
        {
            this.accessToken = await tokenAcquisition.GetAccessTokenForUserAsync(new[] { $"https://management.core.windows.net/user_impersonation" });
        }
    }
}
