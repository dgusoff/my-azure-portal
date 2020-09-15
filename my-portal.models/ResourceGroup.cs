using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace my_portal.models
{
    public class ResourceGroup
    {
        [JsonProperty("id")]
        public string SubscriptionId { get; set; }

        //public string  ResponseJson { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        // tags
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
