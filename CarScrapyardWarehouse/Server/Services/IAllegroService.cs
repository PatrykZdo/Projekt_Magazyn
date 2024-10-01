using CarScrapyardWarehouse.Shared.Models;
using System.Text.Json.Nodes;
using static CarScrapyardWarehouse.Server.Services.AllegroService;
using Attribute = CarScrapyardWarehouse.Shared.Models.Attribute;

namespace CarScrapyardWarehouse.Server.Services
{
    public interface IAllegroService
    {
        Task<string> GetAllegroToken(string givencode);
        Task<string> GetProfileInfo(string givencode);

        Task<string> GetAuthCookieAllegro();
        Task<string> GetProducts(string givencode);

        Task<string> PostAllegroItem(WholeObject jsonData);

    }
}
