using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace RedisAssignment.HttpUtils
{
    public class ApiClientInitializer
    {
        public static HttpClient ApiClient { get; set; }

        public static HttpClient GetClient()
        {
            ApiClient = new HttpClient();
            ApiClient.BaseAddress = new Uri("https://datausa.io/api/data?University=142832&measures=Total%20Noninstructional%20Employees&drilldowns=IPEDS%20Occupation&parents=true");
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return ApiClient;
        }

        /* public static async Task<string> Get(HttpClient client)
         {
             var url = $"{client.BaseAddress}/";
             var content = "";

             using (var response = await client.GetAsync(url))
             {
                 if (response.IsSuccessStatusCode)
                 {
                     content = await response.Content.ReadAsStringAsync();
                 }
             }
             return content;
         }*/
        public static async Task<T> Get<T>(HttpClient client)
        {
            var url = $"{client.BaseAddress}/";

            using (var response = await client.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    var result = JsonConvert.DeserializeObject<T>(content);
                    return result;

                }

                throw new Exception("No data was found");
            }

        }
    }
}

