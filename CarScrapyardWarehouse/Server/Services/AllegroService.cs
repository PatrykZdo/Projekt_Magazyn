using CarScrapyardWarehouse.Shared.Models;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using CarScrapyardWarehouse.Server.Services;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using CarScrapyardWarehouse.Client.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static CarScrapyardWarehouse.Server.Services.AllegroService;

namespace CarScrapyardWarehouse.Server.Services
{
    public class AllegroService : IAllegroService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IDbContextFactory<Server.Models.AppContext> _db;

        public AllegroService(IDbContextFactory<Server.Models.AppContext> db, IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
        {
            _db = db;
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<string> GetAllegroToken(string givencode)
        {
            var clientId = "46646778f880494daac892af47f93131";
            var clientSecret = "tiTCAK2naNJxxLyfAY9x8YXI0lk1ufkMTI5f9vO6UnEcDg2HG0e33eTdjPAAXINo";
            var code_challange = "CbAijeNvdSeloYlVcOh3SAcgZX57wDeVHiwRFQKO2F9DsDV";


            var base64Auth = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{clientId}:{clientSecret}"));



            var client = _httpClientFactory.CreateClient();

            var httpRequest = new HttpRequestMessage(HttpMethod.Post, $"https://allegro.pl.allegrosandbox.pl/auth/oauth/token?grant_type=authorization_code&code={givencode}&redirect_uri=https://massive-buffalo-happily.ngrok-free.app/loginAllegro");
            httpRequest.Headers.Authorization = new AuthenticationHeaderValue("Basic", base64Auth);


            var response = await client.SendAsync(httpRequest);
            

            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                var responceobject = System.Text.Json.JsonSerializer.Deserialize<TokenResponse>(responseContent);
                var cookieOptions = new CookieOptions
                {
                    HttpOnly = true,
                    Expires = DateTime.UtcNow.AddHours(1), 
                                                           
                };
                _httpContextAccessor.HttpContext.Response.Cookies.Append("AuthCookie", responceobject.access_token, cookieOptions);

                return responseContent;
            }
            else
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                return responseContent;
            }
        }
        public async Task<string> GetAuthCookieAllegro()
        {
            var cookieValue = _httpContextAccessor.HttpContext.Request.Cookies["AuthCookie"];
            return cookieValue;
        }
        public async Task<string> GetProfileInfo(string givencode)
        {
            var client = _httpClientFactory.CreateClient();


            var httpRequest = new HttpRequestMessage(HttpMethod.Get, "https://api.allegro.pl.allegrosandbox.pl/me");
            httpRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", givencode);
            httpRequest.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.allegro.public.v1+json"));
            
            
            var response = await client.SendAsync(httpRequest);

            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                return responseContent;
            }
            else
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                return responseContent;
            }
        }
        public async Task<string> PostAllegroItem(WholeObject jsonData)
        {
            var client = _httpClientFactory.CreateClient();
            var content = new StringContent(JsonConvert.SerializeObject(jsonData.data), Encoding.UTF8, "application/vnd.allegro.public.v1+json");


              var httpRequest = new HttpRequestMessage(HttpMethod.Post, "https://api.allegro.pl.allegrosandbox.pl/sale/product-offers");
              httpRequest.Content = content;
              httpRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", jsonData.Code);
              httpRequest.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.allegro.public.v1+json"));

            var response = await client.SendAsync(httpRequest);

            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                return responseContent;
            }
            else
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                return responseContent;
            }

        }
        public async Task<string> GetProducts(string givencode)
        {
            var client = _httpClientFactory.CreateClient();
            StringBuilder responseContent = new StringBuilder();
            string curentContent;


                var httpRequest = new HttpRequestMessage(HttpMethod.Get, $"https://api.allegro.pl.allegrosandbox.pl/sale/products?phrase=4027816301257%category.id=3&mode=GTIN");
                httpRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", givencode);
                httpRequest.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.allegro.public.v1+json"));

                try
                {
                    var response = await client.SendAsync(httpRequest);
                    curentContent = await response.Content.ReadAsStringAsync();
                    responseContent.Append(curentContent);
                }
                catch (HttpRequestException e)
                {
                    // Handle the error accordingly
                    Console.WriteLine($"Request for category 3 failed: {e.Message}");
                }
            

            return responseContent.ToString();
        }
        public class WholeObject
        {
            public string Code { get; set; }

            public Data data { get; set; }
        }
        public class Data
        {
            public ProductSet[] productSet { get; set; }

            public string? name { get; set; }

            public SellingMode sellingMode { get; set; }
            public Stock stock { get; set; }
            public Description description { get; set; }
        }

        public class ProductSet
        {
            public Product product { get; set; }
        }

        public class Product
        {
            public string id { get; set; }
            public List<string> images { get; set; }
        }

        public class SellingMode
        {
            public Price price { get; set; }
        }
        public class Description
        {
            public List<Section> sections { get; set; }
        }

        public class Item
        {
            public string type { get; set; }
            public string content { get; set; }
        }

        public class Section
        {
            public List<Item> items { get; set; }
        }

        public class Price
        {
            public string amount { get; set; }
            public string currency { get; set; }
        }

        public class Stock
        {
            public int available { get; set; }
        }
    }
}
