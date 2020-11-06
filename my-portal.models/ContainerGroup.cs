using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace my_portal.models
{
    public class ContainerGroup
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("sku")]
        public string Sku { get; set; }

        [JsonProperty("provisioningState")]
        public string ProvisioningState { get; set; }

        [JsonProperty("osType")]
        public string OsType { get; set; }
    }
}
