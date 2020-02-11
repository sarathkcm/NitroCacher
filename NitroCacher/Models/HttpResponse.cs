using Fiddler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NitroCacher.Models
{
    [Serializable]
    public class HttpResponse
    {
        public HttpResponse()
        {

        }
     
        public HttpResponse(List<Header> headers, string body)
        {
            Headers = headers;
            Body = body;
        }
        public List<Header> Headers { get; set; }
        public string Body { get; set; }
    }
}
