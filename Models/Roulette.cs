using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace CasinoProject.Models
{
    public class Roulette
    {
        public int Id { get; set; }
        public RoulettePosibleStatus Status { get; set; }
        public Roulette(int id,RoulettePosibleStatus status) {
            Id = id;
            Status = status;
        }
    }
}
