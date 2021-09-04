using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasinoProject.Models
{
    public class Response
    {
        public String message;
        public Object data;

        public Response(String message, Object data)
        {
            this.message = message;
            this.data = data;
        }
    }
}
