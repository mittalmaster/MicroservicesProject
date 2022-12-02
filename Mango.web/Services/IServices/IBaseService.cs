using Mango.web.Models;

namespace Mango.web.Services.IServices
{
    public interface IBaseService:IDisposable
    {
        ResponseDto responseModel { get; set; }
        Task<T> SendAsyn<T>(ApiRequest apiRequest);

    }
}
