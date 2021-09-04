using System.Collections.Generic;
using System.Linq;
namespace CasinoProject.Models
{
    public class RouletteGame
    {
        public static List<Roulette> Roulettes = new List<Roulette>() {
            new Roulette(id: 1, status: RoulettePosibleStatus.open)
        };
        public IEnumerable<Roulette> GetRoulettes() 
        {
            return Roulettes;
        }
        public Roulette GetRoulette(int id) {
            var roulette = Roulettes.Where(r => r.Id == id);
            return roulette.FirstOrDefault();
        }
        public Response AddRoulette() {
            try
            {
                var roulette = new Roulette(id: Roulettes.Count() + 1, status: RoulettePosibleStatus.open);
                Roulettes.Add(roulette);
                return new Response(message: "La ruleta se ha creado satisfactoriamente", data: roulette.Id);
            }
            catch {
                return new Response(
                    message: "no fue posible crear la ruleta, consulte con el administrador del sistema",
                    data: 0);                
            }
        }
    }
}
