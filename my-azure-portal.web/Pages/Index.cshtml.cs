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
        public IEnumerable<Subscription> Subscriptions { get; set; }
        public string Error { get; set; }

        public IndexModel(ISubscriptionData data, ITokenAcquisition tokenAcquisition, ILogger<IndexModel> logger)
        {
            _logger = logger;
            this.tokenAcquisition = tokenAcquisition;
            this.data = data;
            Error = "";
        }

        public async Task OnGet()
        {
            try
            {
                this.accessToken = await tokenAcquisition.GetAccessTokenForUserAsync(new[] { $"https://management.core.windows.net/user_impersonation" });
                //Message = this.accessToken;

                Subscriptions = await this.data.GetSubscriptions(this.accessToken);
                
            }
            catch(Exception ex)
            {
                Response.Cookies.Delete(".AspNetCore.Cookies");
                Response.Redirect("/");
                Subscriptions = new List<Subscription>();
                Error = ex.Message;
            }
        }
    }
}
