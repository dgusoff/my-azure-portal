using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace my_portal.models
{
    public class Resource
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("location")] 
        public string Location { get; set; }
    }
}
