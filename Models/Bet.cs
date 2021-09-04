using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CasinoProject.Models
{
    public class Bet
    {
        public int Id { get; set; }
        public int userId { get; set; }
        public Roulette roulette { get; set; }
        public BetType betType { get; set; }
        [Range(0,36,ErrorMessage ="para la apuesta solo se permiten valores entre 0 y 36")] 
        public int betNumber { get; set; }
        public ColorRoulette betColor { get; set; }
        public Bet(int id, int userid, Roulette roulette, BetType betType, int betNumber, ColorRoulette betColor)
        {
            this.Id = id;
            this.userId = userid;
            this.roulette = roulette;
            this.betType = betType;
            this.betNumber = betNumber;
            this.betColor = betColor;
        }
    }
}