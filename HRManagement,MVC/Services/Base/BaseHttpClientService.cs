using HRManagement.MVC.Contracts;
using System.Net.Http.Headers;

namespace HRManagement.MVC.Services.Base
{
    public class BaseHttpClientService
    {
       protected readonly IClient _client;

       protected readonly ILocalStorageService _localStorage;

        public BaseHttpClientService(IClient client, ILocalStorageService localStorage)
        {
            _client = client;
            _localStorage = localStorage;
        }

        protected Response<Guid> ConvertApiExeption<Guid>(ApiException exception)
        {
            if (exception.StatusCode == 400) {
                return new Response<Guid> { ValidationError = exception.Message, Succedded = false, Message = "An error Ocured" };          
            }else if (exception.StatusCode == 404)
            {
                return new Response<Guid> { Message = "NotFound", Succedded = false };
            }
            else
            {
                return new Response<Guid> { Message = "something wrong", Succedded = false };
            }
        }

        protected void AddbrearToken()
        {
            if (_localStorage.Exist("token"))
            {
                _client.httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", _localStorage.GetLocalStorage<string>("token"));
            }
        }
    }
}
