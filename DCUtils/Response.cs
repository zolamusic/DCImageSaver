using System.Net.Http.Headers;

namespace DCUtils
{
    public class Response
    {
        public HttpResponseHeaders Headers { get; set; }
        public string Contents { get; set; }

        public Response(HttpResponseHeaders httpResponseHeaders, string responsedBody)
        {
            Headers = httpResponseHeaders;
            Contents = responsedBody;
        }
    }
}
