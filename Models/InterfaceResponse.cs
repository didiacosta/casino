using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasinoProject.Models
{
    interface InterfaceResponse
    {
        public String message { get; set; }
        public Object data { get; set; }
    }
}
