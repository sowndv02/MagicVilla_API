using MagicVilla_Utility;
using MagicVilla_Web.Models;
using MagicVilla_Web.Models.Dto;
using MagicVilla_Web.Services.IServices;

namespace MagicVilla_Web.Services
{
    public class AuthService : IAuthService
    {
        private readonly IHttpClientFactory _clientFactory;
        private string villaUrl;
        private readonly IBaseServices _baseServices;
        public AuthService(IHttpClientFactory clientFactory, IConfiguration configuration, IBaseServices baseServices) 
        {
            _baseServices = baseServices;
            _clientFactory = clientFactory;
            villaUrl = configuration.GetValue<string>("ServiceUrls:VillaAPI");
        }
        public async Task<T> LoginAsync<T>(LoginRequestDTO obj)
        {
            return await _baseServices.SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = obj,
                Url = villaUrl + $"/api/{SD.CurrentAPIVersion}/UsersAuth/register"
            }, withBearer:false);
        }

        public async Task<T> RegisterAsync<T>(RegisterationRequestDTO obj)
        {
            return await _baseServices.SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = obj,
                Url = villaUrl + $"/api/{SD.CurrentAPIVersion}/UsersAuth/login"
            }, withBearer: false);
        }

        public async Task<T> LogoutAsync<T>(TokenDTO obj)
        {
            return await _baseServices.SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = obj,
                Url = villaUrl + $"/api/{SD.CurrentAPIVersion}/UsersAuth/revoke"
            });
        }
    }
}
