using Bit.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
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

            List<UserDto> users = (await response.EnsureSuccessStatusCode().Content.ReadFromJsonAsync<JsonElement>()).GetProperty("data").ToObject<List<UserDto>>();
        }
    }

    public static partial class JsonExtensions
    {
        public static T ToObject<T>(this JsonElement element)
        {
            var json = element.GetRawText();
            return JsonSerializer.Deserialize<T>(json);
        }
        public static T ToObject<T>(this JsonDocument document)
        {
            var json = document.RootElement.GetRawText();
            return JsonSerializer.Deserialize<T>(json);
        }
    }
}
