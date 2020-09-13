using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace my_portal.models
{
    public interface ISubscriptionData
    {
        public Task<IEnumerable<Subscription>> GetSubscriptions(string accessToken);
    }
}
