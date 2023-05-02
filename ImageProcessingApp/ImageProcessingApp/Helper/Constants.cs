using System.Net.Http;
using System;
using System.Threading.Tasks;

namespace ImageProcessingApp
{
    public static class Constants
    {

        /// <summary>
        /// For Dev mode and IIS host mode Rest URL will served 
        /// </summary>
#if DEBUG
        public static string RestUrl = "https://localhost:7020/api/";
#else
    public static string RestUrl = "http://100.74.81.147:8011/api/";
#endif


        /// <summary>
        /// Only for Development purpose
        /// </summary>
        public static string Email = "er.satish674@gmail.com";
        public static string Password = "local@123";

        /// <summary>
        /// Generate Token 
        /// </summary>
        /// <param name="jsonBody"></param>
        /// <returns></returns>
        public static async Task<string> GetTokenAsync(string jsonBody)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, RestUrl + "Token");
            var content = new StringContent(jsonBody, null, "application/json");
            request.Content = content;
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

    }
}
