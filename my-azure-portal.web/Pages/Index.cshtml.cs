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
    [AuthorizeForScopes(Scopes = new[] { "https://management.core.windows.net/user_impersonation", "user.read", "directory.read.all" })]
    public class IndexModel : PageModel
    {
        readonly ISubscriptionData data;
        private readonly ILogger<IndexModel> _logger;
        readonly ITokenAcquisition tokenAcquisition;
        string accessToken;
        public string Message { get; set; }
        public string SubData { get; set; }

        public IndexModel(ISubscriptionData data, ITokenAcquisition tokenAcquisition, ILogger<IndexModel> logger)
        {
            _logger = logger;
            this.tokenAcquisition = tokenAcquisition;
            this.data = data;
        }

        public async Task OnGet()
        {
            try
            {
                this.accessToken = await tokenAcquisition.GetAccessTokenForUserAsync(new[] { $"https://management.core.windows.net/user_impersonation" });
                //Message = this.accessToken;

                string subJson = await this.data.GetSubscriptions(this.accessToken);
                Message = subJson;
            }
            catch(Exception ex)
            {
                Message = ex.Message;
            }
        }
    }
}
