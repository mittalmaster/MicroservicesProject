namespace Mango.web
{
    public class SD //to hold the sataic api
    {
        public static string ProductAPIBase { get; set; }
        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE
        }
    }
}
