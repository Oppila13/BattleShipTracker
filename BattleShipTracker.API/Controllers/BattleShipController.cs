using BattleShipTracker.API.Constants;
using BattleShipTracker.API.Implementation;
using BattleShipTracker.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace BattleShipTracker.API.Controllers
{
    [Route("api/")]
    [ApiController]
    public class BattleShipController : Controller
    {
        // Assuming the board size based on the question given. 
        private static BattleShipGame game = new BattleShipGame(InputValues.boardSize);

        [HttpPost]
        [Route("add")]
        public IActionResult AddShip([FromBody] List<AddShip> shipCells)
        {
            if (shipCells == null || shipCells.Count == 0)
                return BadRequest(ResponseMessages.InvalidPlacementData);

            for (var i = 0; i < shipCells.Count; i++)
            {
               var result = game.AddShip(shipCells[i].row, shipCells[i].column, shipCells[i].length, shipCells[i].orientation);
               if (result != ResponseMessages.ShipPlaced)
               {
                 return BadRequest(result);
               }
            }
            return Ok(ResponseMessages.ShipPlaced);
        }

        [HttpPost]
        [Route("attack")]
        public IActionResult Attack([FromBody] AttackShip attackCell)
        {
            if (attackCell == null || attackCell.row >= InputValues.boardSize || attackCell.column >= InputValues.boardSize)
                return BadRequest("Invalid attack data.");

            return Ok(game.Attack(attackCell.row, attackCell.column));
        }
    }
}
