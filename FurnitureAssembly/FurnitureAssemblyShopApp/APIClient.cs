using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace FurnitureAssemblyShopApp
{
    public static class APIClient
    {
        private static readonly HttpClient _client = new();
        
        public static bool isAuth { get; private set; } = false;
        
        public static string ConfigPassword { get; private set; } = string.Empty;

        public static bool Login(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new Exception("Enter the password");
            }
            
            return isAuth = password.Equals(ConfigPassword);
        }

        public static void Connect(IConfiguration configuration)
        {
            ConfigPassword = configuration["Password"];
            
            _client.BaseAddress = new Uri(configuration["IPAddress"]);
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static T? GetRequest<T>(string requestUrl)
        {
            var response = _client.GetAsync(requestUrl);
            
            var result = response.Result.Content.ReadAsStringAsync().Result;
            
            if (response.Result.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<T>(result);
            }
            else
            {
                throw new Exception(result);
            }
        }

        public static void PostRequest<T>(string requestUrl, T model)
        {
            var json = JsonConvert.SerializeObject(model);
            
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            
            var response = _client.PostAsync(requestUrl, data);
            
            var result = response.Result.Content.ReadAsStringAsync().Result;
            
            if (!response.Result.IsSuccessStatusCode)
            {
                throw new Exception(result);
            }
        }
    }
}
