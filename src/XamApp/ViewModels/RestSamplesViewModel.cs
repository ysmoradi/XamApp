using Bit.ViewModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using XamApp.Dto;

namespace XamApp.ViewModels
{
    public class RestSamplesViewModel
    {
        public virtual HttpClient HttpClient { get; set; }

        public virtual BitDelegateCommand CallUsersListApiUsingHttpClientCommand { get; set; }

        public RestSamplesViewModel()
        {
            CallUsersListApiUsingHttpClientCommand = new BitDelegateCommand(CallUsersListApiUsingHttpClient);
        }

        async Task CallUsersListApiUsingHttpClient()
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "https://reqres.in/api/users");
            // Use request.Headers to set jwt token , ...
            // Use request.Content to send body
            HttpResponseMessage response = await HttpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            using (StreamReader streamReader = new StreamReader(await response.Content.ReadAsStreamAsync()))
            using (JsonReader jsonReader = new JsonTextReader(streamReader))
            {
                List<UserDto> users = (await JToken.LoadAsync(jsonReader))["data"].ToObject<List<UserDto>>();
            }
        }
    }
}
