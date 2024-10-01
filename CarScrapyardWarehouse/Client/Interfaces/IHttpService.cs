namespace CarScrapyardWarehouse.Client.Interfaces;

public interface IHttpService
{
    Task<T> Get<T>(string url);

    Task<HttpResponseMessage> Post(string url, object data);
    Task<TResponse> Post<TResponse>(string url, object data);
    Task<HttpResponseMessage> Post(string url, HttpContent data);
    Task<TResponse> Post<TResponse>(string url, HttpContent data);

    Task<HttpResponseMessage> Put(string url, object data);
    Task<TResponse> Put<TResponse>(string url, object data);

    Task<HttpResponseMessage> Delete(string url);
    Task<TResponse> Delete<TResponse>(string url);
}
