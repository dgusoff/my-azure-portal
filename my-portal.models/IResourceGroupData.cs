using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace my_portal.models
{
    public interface IResourceGroupData
    {
        public Task<IEnumerable<ResourceGroup>> GetAllResourceGroupsBySubscription(string subscriptionId, string accessToken);        

        public Task<string> GetAllResourceGroups(string accessToken);
    }
}
