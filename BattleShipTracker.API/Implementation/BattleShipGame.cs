using BattleshipApi;
using BattleShipTracker.API.Constants;
using BattleShipTracker.API.Interface;
using System.Data.Common;
using System.Drawing;

namespace BattleShipTracker.API.Implementation
{
    public class BattleShipGame: IBattleShipGame
    {
        private int[,] board;

        public BattleShipGame(int size)
        {
            this.board = new int[size, size];
        }

        public string AddShip(int row, int column, int length, string orientation)
        {
            if (orientation == "horizontal")
            {
                if (column + length > InputValues.boardSize || row >= InputValues.boardSize)
                {
                    return ResponseMessages.ShipPlacementOutOfBounds;
                }
                for (int i = 0; i < length; i++)
                {
                    if (board[row, column + i] != 0)
                    {
                        return ResponseMessages.ShipPlacementOverlaps;
                    }
                    board[row, column + i] = length;
                }
            }
            else if (orientation == "vertical")
            {
                if (row + length > InputValues.boardSize || column >= InputValues.boardSize)
                {
                    return ResponseMessages.ShipPlacementOutOfBounds;
                }
                for (int i = 0; i < length; i++)
                {
                    if (board[row + i, column] != 0)
                    {
                        return ResponseMessages.ShipPlacementOverlaps;
                    }
                    board[row + i, column] = length;
                }
            }
            else
            {
                return ResponseMessages.InvalidOrientation;
            }
            return ResponseMessages.ShipPlaced;
        }

        public string Attack(int row, int column)
        {
            if (board[row, column] == 0)
            {
                return "miss";
            }
            board[row, column] = 0;
            return "hit";
        }
    }
}
