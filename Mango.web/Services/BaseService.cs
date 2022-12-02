using Mango.web.Models;
using Mango.web.Services.IServices;

namespace Mango.web.Services
{
    public class BaseService : IBaseService
    {
        public ResponseDto responseModel { get; set; }

        

        public Task<T> SendAsyn<T>(ApiRequest apiRequest)
        {
            throw new NotImplementedException();
        }
        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }
    }
}
