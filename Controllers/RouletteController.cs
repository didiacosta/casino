using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CasinoProject.Models;
using Newtonsoft.Json.Linq;
using System.Net.Http.Formatting;

namespace CasinoProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouletteController : ControllerBase
    {
        public RouletteGame rouletteGame = new RouletteGame();
        [HttpPost("add")]
        public IActionResult AddRoulette()
        {
            Response response = rouletteGame.AddRoulette();
            if (Convert.ToInt32(response.data) == 0)
            {
                return BadRequest(error: response.message);
            }
            else {
                return CreatedAtAction(nameof(AddRoulette), value: response);
            }
        }
        [HttpGet("open/{id}")]
        public IActionResult Open(int id)
        {
            Roulette roulette = rouletteGame.GetRoulette(id: id);
            if (roulette == null) {
                return BadRequest(error: "No se encontró la ruleta con el id " + id);
            }
            else
            {
                Response response = roulette.Open();
                return Ok(value: response);
            }
        }
        [HttpPost("tobet/{id}")]
        public IActionResult AddBet(Bet bet, int id)
        {
            Roulette roulette = rouletteGame.GetRoulette(id: Convert.ToInt32(id));
            if (roulette == null)
            {
                return BadRequest(error: "No se encontró la ruleta con el id " + id);
            }
            else
            {
                Response response = roulette.AddBet(
                    userid: bet.UserId,
                    betType: bet.BetType,
                    betNumber: bet.BetNumber,
                    betColor: bet.BetColor,
                    amount: bet.Amount);
                return Ok(value: response);
            }

        }
        [HttpPost("close/{id}")]
        public IActionResult Close(int id)
        {
            Roulette roulette = rouletteGame.GetRoulette(id: Convert.ToInt32(id));
            if (roulette == null)
            {
                return BadRequest(error: "No se encontró la ruleta con el id " + id);
            }
            else
            {
                Response response = roulette.Close();
                return Ok(value: response);
            }
        }
        [HttpGet]
        public IActionResult Get()
        {
            Response response = new Response(message: "", data: rouletteGame.GetRoulettes());
            return Ok(value: response);
        }
    }
}