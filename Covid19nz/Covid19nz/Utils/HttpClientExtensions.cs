using System.Net.Http;
using System.Threading.Tasks;

namespace Covid19nz.Utils
{
    public static class HttpClientExtensions
    {
        public static async Task<string> DownloadStringAsync(this HttpClient client, string url )
        {
            //Todo: switch to c# 8 to simplify usings
            using (HttpResponseMessage response = await client.GetAsync(url).ConfigureAwait(false))
            {
                using (HttpContent content = response.Content)
                {
                    return await content.ReadAsStringAsync().ConfigureAwait(false);                   
                }
            } 
            
        }
    }
}
