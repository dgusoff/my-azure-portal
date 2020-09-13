using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace my_portal.models
{
    public interface ISubscriptionData
    {
        public Task<string> GetSubscriptions(string accessToken);
    }
}
