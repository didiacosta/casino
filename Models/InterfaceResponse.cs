using System;
namespace CasinoProject.Models
{
    interface InterfaceResponse
    {
        public String message { get; set; }
        public Object data { get; set; }
    }
}
