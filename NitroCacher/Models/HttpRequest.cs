using Fiddler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NitroCacher.Models
{
    [Serializable]
    public class HttpRequest
    {
        public HttpRequest()
        {

        }
        public HttpRequest(List<Header> headers, string url, string method, byte[] body)
        {
            Headers = headers;
            Url = url;
            Method = method;
            Body = body;
        }
        public List<Header> Headers { get; set; }
        public string Url { get; set; }
        public string Method { get; set; }
        public byte[] Body { get; set; }
    }
}
