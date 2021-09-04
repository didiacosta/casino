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
        public int UserId { get; set; }
        public BetType BetType { get; set; }
        //[Range(0,36,ErrorMessage ="para la apuesta solo se permiten valores entre 0 y 36")] 
        public int BetNumber { get; set; }
        public ColorRoulette BetColor { get; set; }
        public Double Result { get; set; }
        public Double Amount { get; set; }
        public DateTime BetDate { get; }
        public Bet(int id, int userid, BetType betType, int betNumber, Double amount, ColorRoulette betColor)
        {
            this.Id = id;
            this.UserId = userid;
            this.BetType = betType;
            this.BetNumber = betNumber;
            this.BetColor = betColor;
            this.Amount = amount;
            this.Result = 0;
            this.BetDate = DateTime.UtcNow;
        }
        public Bet() { }
    }
}