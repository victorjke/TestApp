using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace TestApp.Api.Helpers
{
    public static class ApiHelper
    {
        public const int TimeoutInSeconds = 30;

        static Lazy<HttpClient> _httpClientLazy;


        static ApiHelper()
        {
            _httpClientLazy = new Lazy<HttpClient>(() => new HttpClient()
            { 
                Timeout = TimeSpan.FromSeconds(TimeoutInSeconds)
            });
        }


        public static async Task<string> GetDataAsStringAsync(string url, Encoding encoding)
        {
            try
            {
                var response = await _httpClientLazy.Value.GetAsync(url).ConfigureAwait(false);

                if (response?.Content != null)
                {
                    var byteArray = await response.Content.ReadAsByteArrayAsync().ConfigureAwait(false);
                    return encoding.GetString(byteArray, 0, byteArray.Length);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

            return null;
        }
    }
}