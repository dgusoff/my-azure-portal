using my_portal.models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace my_portal.data
{
    public class SubscriptionData : ISubscriptionData
    {
        private readonly HttpClient httpClient;
        string managementApi = "https://management.azure.com/{0}?api-version={1}";
        string apiVersion = "2020-01-01";

        public SubscriptionData(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<IEnumerable<Subscription>> GetSubscriptions(string accessToken)
        {
            ApplyAuthHeader(accessToken);

            List<Subscription> subs = new List<Subscription>();
            string url = string.Format(managementApi, "subscriptions", apiVersion);
            var httpResult = await httpClient.GetAsync(url);
            string json = await httpResult.Content.ReadAsStringAsync();

            JObject jsonResult = JObject.Parse(json);
            IList<JToken> results = jsonResult["value"].Children().ToList();

            foreach (JToken result in results)
            {
                // JToken.ToObject is a helper method that uses JsonSerializer internally
                Subscription sub = result.ToObject<Subscription>();
                subs.Add(sub);
            }
            return subs;
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
