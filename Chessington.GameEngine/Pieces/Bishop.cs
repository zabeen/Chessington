using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            // returned list
            List<Square> availablePositions = new List<Square>();

            // get current position
            Square currentPosition = board.FindPiece(this);

            // set row numbers
            int rowAbove = currentPosition.Row - 1;
            int rowBelow = currentPosition.Row + 1;

            // move from right of current position to right edge of board
            for (int col = currentPosition.Col + 1; col < 8; col++)
            {
                // add new squares until top row is reached
                if (rowAbove > -1)
                {
                    availablePositions.Add(new Square(rowAbove, col));
                    rowAbove--;
                }

                // add new squares until bottom row is reached
                if (rowBelow < 8)
                {
                    availablePositions.Add(new Square(rowBelow, col));
                    rowBelow++;
                }
            }

            // reset row numbers
            rowAbove = currentPosition.Row - 1;
            rowBelow = currentPosition.Row + 1;

            // move from left of current position to left edge of board
            for (int col = currentPosition.Col - 1; col > -1; col--)
            {
                // add new squares until top row is reached
                if (rowAbove > -1)
                {
                    availablePositions.Add(new Square(rowAbove, col));
                    rowAbove--;
                }

                // add new squares until bottom row is reached
                if (rowBelow < 8)
                {
                    availablePositions.Add(new Square(rowBelow, col));
                    rowBelow++;
                }
            }

            //remove squares that match starting/ current position
            availablePositions.RemoveAll(a => a == currentPosition);

            return availablePositions;
        }
    }
}