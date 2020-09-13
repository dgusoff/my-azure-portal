using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace my_portal.models
{
    
    public class Subscription
    {
        [JsonProperty("subscriptionId")]
        public string Id { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }
    }
}
