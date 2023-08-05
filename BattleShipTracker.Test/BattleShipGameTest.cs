using System;
using Xunit;
using BattleShipTracker.API.Implementation;
using BattleShipTracker.API.Constants;

namespace BattleShipTracker.Test
{
    public class BattleShipGameTests
    {
        [Fact]
        public void AddShip_Horizontal_Success()
        {
            var game = new BattleShipGame(InputValues.boardSize);
            var result = game.AddShip(2, 3, 3, "horizontal");

            // Assert
            Assert.Equal(ResponseMessages.ShipPlaced, result);
        }

        [Fact]
        public void AddShip_Vertical_Success()
        {
            var game = new BattleShipGame(10);
            var result = game.AddShip(3, 5, 4, "vertical");

            // Assert
            Assert.Equal(ResponseMessages.ShipPlaced, result);
        }

        [Fact]
        public void AddShip_InvalidOrientation_Failure()
        {
            var game = new BattleShipGame(10);
            var result = game.AddShip(5, 6, 3, "diagonal");

            // Assert
            Assert.Equal(ResponseMessages.InvalidOrientation, result);
        }

        [Fact]
        public void AddShip_Overlap_Failure()
        {
            var game = new BattleShipGame(10);
            game.AddShip(2, 3, 3, "horizontal");
            var result = game.AddShip(2, 3, 2, "vertical");

            // Assert
            Assert.Equal(ResponseMessages.ShipPlacementOverlaps, result);
        }

        [Fact]
        public void AddShip_Outbound_Failure_Horizontal()
        {
            var game = new BattleShipGame(10);
            var result = game.AddShip(1, 3, 8, "horizontal");

            // Assert
            Assert.Equal(ResponseMessages.ShipPlacementOutOfBounds, result);
        }

        [Fact]
        public void AddShip_Outbound_Failure_Vertical()
        {
            var game = new BattleShipGame(10);
            var result = game.AddShip(3, 1, 8, "vertical");

            // Assert
            Assert.Equal(ResponseMessages.ShipPlacementOutOfBounds, result);
        }

        [Fact]
        public void Invalid_Column_Value()
        {
            var game = new BattleShipGame(10);
            var result = game.AddShip(3, 11, 2, "vertical");

            // Assert
            Assert.Equal(ResponseMessages.ShipPlacementOutOfBounds, result);
        }

        [Fact]
        public void Invalid_Row_Value()
        {
            var game = new BattleShipGame(10);
            var result = game.AddShip(13, 1, 2, "horizontal");

            // Assert
            Assert.Equal(ResponseMessages.ShipPlacementOutOfBounds, result);
        }

        [Fact]
        public void Attack_Miss()
        {
            var game = new BattleShipGame(10);
            string result = game.Attack(7, 9);

            // Assert
            Assert.Equal("miss", result);
        }

        [Fact]
        public void Attack_Hit()
        {
            var game = new BattleShipGame(10);
            game.AddShip(3, 4, 3, "horizontal");
            string result = game.Attack(3, 5);

            // Assert
            Assert.Equal("hit", result);
        }
    }
}
