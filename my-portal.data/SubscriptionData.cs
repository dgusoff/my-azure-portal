using my_portal.models;
using System;
using System.Collections.Generic;
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
        public async Task<string> GetSubscriptions(string accessToken)
        {
            ApplyAuthHeader(accessToken);
            string url = string.Format(managementApi, "subscriptions", apiVersion);
            var httpResult = await httpClient.GetAsync(url);
            string json = await httpResult.Content.ReadAsStringAsync();
            return json;
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
