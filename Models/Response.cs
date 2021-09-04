using System;
namespace CasinoProject.Models
{
    public class Response : InterfaceResponse
    {
        public String message { get; set; }
        public Object data { get; set; }
        public Response(String message, Object data)
        {
            this.message = message;
            this.data = data;
        }
    }
}
