using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using CarScrapyardWarehouse.Server.Services;
using CarScrapyardWarehouse.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Attribute = CarScrapyardWarehouse.Shared.Models.Attribute;
using static CarScrapyardWarehouse.Server.Services.AllegroService;

[Route("api/[controller]")]
[ApiController]
    public class AllegroController : Controller
    {
    private readonly IAllegroService _allegroService;

    public AllegroController(IAllegroService allegroService)
    {
        _allegroService = allegroService;
    }



    [HttpPost("token")]
    public Task<string> GetAllegroToken([FromBody] TokenRequestModel model)
    {
        return _allegroService.GetAllegroToken(model.Code);
    }

    [HttpGet("profile")]
    public Task<string> GetProfileInfo(string code)
    {
        return _allegroService.GetProfileInfo(code);
    }

    [HttpGet("products")]
    public Task<string> GetProducts(string givencode)
    {
        return _allegroService.GetProducts(givencode);
    }

    [HttpGet("PrevToken")]

    public async Task<string> GetAuthCookieAllegro()
    {
        return await _allegroService.GetAuthCookieAllegro();
    }
    [HttpPost("PostItem")]
    public Task<string> PostAllegroItem([FromBody] WholeObject jsonData)
    {
        return _allegroService.PostAllegroItem(jsonData);
    }
    public class TokenRequestModel
    {
        public string Code { get; set; }
    }
}

