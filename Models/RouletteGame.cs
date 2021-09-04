using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasinoProject.Models
{
    public class RouletteGame
    {
        public static List<Roulette> Roulettes = new List<Roulette>() {
            new Roulette(1, RoulettePosibleStatus.open)
        };
        public IEnumerable<Roulette> GetRoulettes() 
        {
            return Roulettes;
        }
        public Roulette GetRoulette(int id) {
            var roulette = Roulettes.Where(r => r.Id == id);
            return roulette.FirstOrDefault();
        }
        public int AddRoulette() {
            var roulette = new Roulette(Roulettes.Count() + 1, RoulettePosibleStatus.open);
            return roulette.Id;
        }
    }
}
