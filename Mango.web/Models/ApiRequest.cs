using Microsoft.AspNetCore.Mvc;
using static Mango.web.SD;


namespace Mango.web.Models
{
    public class ApiRequest
    {
        public ApiType ApiType { get; set; }
        public string Url { get; set; }
        public object Data { get; set; }
        public string AccessToken { get; set; }//not implemeted rightKow
        //as we are not implemeting authentication

    }
}
