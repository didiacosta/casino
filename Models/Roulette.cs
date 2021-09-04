using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
namespace CasinoProject.Models
{
    public class Roulette
    {
        public int Id { get; set; }
        public RoulettePosibleStatus Status { get; set; }
        public static List<Bet> Bets = new List<Bet>();
        public Roulette(int id,RoulettePosibleStatus status) {
            Id = id;
            Status = status;
        }
        public IEnumerable<Bet> GetBets()
        {
            return Bets;
        }
        private int WinnerNumber = 0;
        private ColorRoulette WinnerColor;
        private String WinnerColorString;
        public Bet GetBet(int id)
        {
            var bet = Bets.Where(r => r.Id == id);
            return bet.FirstOrDefault();
        }
        public Response AddBet(int userid, BetType betType, int betNumber, ColorRoulette betColor, Double amount)
        {
            try
            {
                if ((betType == BetType.color) && ((betColor != ColorRoulette.red) && (betColor != ColorRoulette.black)))
                {
                    return new Response(message: "Su apuesta es por color, debe elegir rojo o negro.", 
                        data: null);
                }
                if ((betType == BetType.number) && ((betNumber < 0) || (betNumber > 36))) {
                    return new Response(message: "Su apuesta es por numero, debe elegir un numero de 0 a 36.", 
                        data: null);
                }
                if (this.Status == RoulettePosibleStatus.closed) {
                    return new Response(message: "La Ruleta se encuentra cerrada, no es posible apostar.", data: null);
                }
                if (amount <= 0 || amount > 10000) {
                    return new Response(
                        message: "Solo se permiten apuestas de 1 a 10.000 dolares, no es posible apostar.", data: null);
                }
                Bet bet = new Bet(id: this.GetBets().Count() + 1, userid: userid, betType: betType,
                    betNumber: betNumber, amount: amount, betColor: betColor);
                Bets.Add(bet);
                return new Response(message: "La apuesta se ha creado correctamente", data: bet);
            }
            catch
            {
                return new Response(
                    message: "no fue posible agregar la apuesta, consulte con el administrador del sistema",
                    data: null);
            }
        }
        public Response Open() {
            try
            {
                this.Status = RoulettePosibleStatus.open;
                return new Response(message: "La ruleta ha sido abierta correctamente", data: this.Status);
            }
            catch
            {
                return new Response(
                    message: "no fue posible abir la ruleta, consulte con el administrador del sistema",
                    data: this.Status);
            }
        }
        private void Play()
        {
            Random random = new Random();
            this.WinnerNumber = random.Next(0, 37);
            if (this.WinnerNumber % 2 == 0)
            {
                this.WinnerColor = ColorRoulette.red;
                this.WinnerColorString = "rojo";
            }
            else
            {
                this.WinnerColor = ColorRoulette.black;
                this.WinnerColorString = "negro";
            }
            this.Status = RoulettePosibleStatus.closed;
        }
        public Response Close() {
            try
            {
                if (this.Status == RoulettePosibleStatus.open)
                {
                    //Thread thread = new Thread(new ThreadStart(Play));
                    //thread.Start();
                    Play();
                    foreach (Bet bet in Bets)
                    {
                        if (bet.BetType == BetType.color)
                        {
                            bet.Result = (this.WinnerColor == bet.BetColor) ? bet.Amount * 1.8 : bet.Amount * -1;
                        }
                        if (bet.BetType == BetType.number)
                        {
                            bet.Result = (this.WinnerNumber == bet.BetNumber) ? bet.Amount * 5 : bet.Amount * -1;
                        }
                    }
                    String message = "Las apuestas se han cerrado, el resultado es " +
                        this.WinnerColorString + " " + this.WinnerNumber.ToString();
                    return new Response(message: message, data: Bets);
                }
                else
                {
                    return new Response(message: "La ruleta " + this.Id + " se encuentra cerrada.", data: null);
                }
            } catch {
                return new Response(
                    message: "no fue posible cerrar la ruleta, consulte con el administrador del sistema",
                    data: this.Status);
            }
        }   
    }
}
