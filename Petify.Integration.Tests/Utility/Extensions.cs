using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Petify.Common.CQRS;
using Newtonsoft.Json;

namespace Petify.Integration.Tests.Utility
{
    public static class Extensions
    {
        public static Task<HttpResponseMessage> PostAsync(this HttpClient httpClient, string url, ICommand command)
        {
            return httpClient.PostAsync(url, new StringContent(JsonConvert.SerializeObject(command), Encoding.UTF8, "application/json"));
        }
    }
}
