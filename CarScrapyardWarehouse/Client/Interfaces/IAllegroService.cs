using CarScrapyardWarehouse.Shared.Models;

namespace CarScrapyardWarehouse.Client.Interfaces
{
    public interface IAllegroService
    {
        Task<string> GetAllegroToken(string givencode);
    }
}
