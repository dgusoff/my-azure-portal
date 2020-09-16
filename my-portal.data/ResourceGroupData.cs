using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using my_portal.models;
using Newtonsoft.Json.Linq;

namespace my_portal.data
{
    public class ResourceGroupData : IResourceGroupData
    {
        private readonly HttpClient httpClient;
        string accessToken;

        // h ttps://management.azure.com/subscriptions/{subscriptionId}/resourcegroups?api-version=2020-06-01
        string managementApi = "https://management.azure.com/subscriptions/{0}/resourcegroups?api-version={1}";
        string getResourcesRestApi = "https://management.azure.com/subscriptions/{0}/resourceGroups/{1}/resources?api-version={2}";
        string apiVersion = "2020-01-01";

        public string Json { get; set; }

        public ResourceGroupData(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public Task<string> GetAllResourceGroups(string accessToken)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ResourceGroup>> GetAllResourceGroupsBySubscription(string subscriptionId, string accessToken)
        {
            ApplyAuthHeader(accessToken);

            List<ResourceGroup> resourceGroups = new List<ResourceGroup>();

            string url = string.Format(managementApi, subscriptionId, apiVersion);
            var httpResult = await httpClient.GetAsync(url);
            string json = await httpResult.Content.ReadAsStringAsync();

            JObject jsonResult = JObject.Parse(json);
            IList<JToken> results = jsonResult["value"].Children().ToList();

            foreach (JToken result in results)
            {
                // JToken.ToObject is a helper method that uses JsonSerializer internally
                ResourceGroup sub = result.ToObject<ResourceGroup>();
                sub.SubscriptionId = subscriptionId;
                resourceGroups.Add(sub);
            }

            return resourceGroups;
        }

        public async Task<IEnumerable<Resource>> GetAllResourcesBySubscription(string subscriptionId, string resourceGroupName, string accessToken)
        {
            List<Resource> resources = new List<Resource>(); 
            ApplyAuthHeader(accessToken);

            string url = string.Format(getResourcesRestApi, subscriptionId, resourceGroupName, apiVersion);
            var httpResult = await httpClient.GetAsync(url);
            string json = await httpResult.Content.ReadAsStringAsync();

            JObject jsonResult = JObject.Parse(json);
            IList<JToken> results = jsonResult["value"].Children().ToList();

            foreach (JToken result in results)
            {
                // JToken.ToObject is a helper method that uses JsonSerializer internally
                Resource res = result.ToObject<Resource>();
                resources.Add(res);
            }

            return resources;
        }

        private void ApplyAuthHeader(string accessToken)
        {
            if (!httpClient.DefaultRequestHeaders.Contains("Authorization"))
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");
            }
        }      
    }
}
