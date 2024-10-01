using CarScrapyardWarehouse.Shared.Models;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using CarScrapyardWarehouse.Client.Interfaces;
using System;

namespace CarScrapyardWarehouse.Client.Services
{
    public class AllegroService : IAllegroService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AllegroService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        }

        public async Task<string> GetAllegroToken(string givencode)
        {
            var clientId = "46646778f880494daac892af47f93131";
            var clientSecret = "tiTCAK2naNJxxLyfAY9x8YXI0lk1ufkMTI5f9vO6UnEcDg2HG0e33eTdjPAAXINo";

            var base64Auth = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{clientId}:{clientSecret}"));

//            var data = new
//            {
//                grant_type = "authorization_code",
//                code = givencode,
//                redirect_uri = "https://massive-buffalo-happily.ngrok-free.app/loginAllegro"
//            };

            var client = _httpClientFactory.CreateClient();

            var httpRequest = new HttpRequestMessage(HttpMethod.Post, $"https://allegro.pl.allegrosandbox.pl/auth/oauth/token?grant_type=authorization_code&code={givencode}&redirect_uri=https://massive-buffalo-happily.ngrok-free.app/loginAllegro");
            httpRequest.Headers.Authorization = new AuthenticationHeaderValue("Basic", base64Auth);
//            httpRequest.Content = new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");

            var response = await client.SendAsync(httpRequest);

            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                var responseObject = JsonSerializer.Deserialize<string>(responseContent);
                return responseObject;
            }
            else
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                var responseObject = JsonSerializer.Deserialize<string>(responseContent);
                return responseObject;
            }
        }

    }
}