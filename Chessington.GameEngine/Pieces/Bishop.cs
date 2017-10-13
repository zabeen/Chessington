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
            Square curr = board.FindPiece(this);

            // Row values at left and right edges of board
            int topLeft = curr.Row - curr.Col;
            int topRight = curr.Row + curr.Col - 7;
            int bottomLeft = curr.Row + curr.Col;
            int bottomRight = curr.Row - curr.Col + 7;

            // add squares top left to bottom right
            AddSquareForEachColAtSpecifiedRows(
                ref availablePositions,
                rows: Enumerable.Range(topLeft, bottomRight - topLeft + 1).ToList());

            // add squares bottom left to top right
            AddSquareForEachColAtSpecifiedRows(
                ref availablePositions,
                rows: Enumerable.Range(topRight, bottomLeft - topRight + 1).Reverse().ToList());

            //remove squares that match current position
            availablePositions.RemoveAll(a => a == curr);

            return availablePositions;
        }

        private void AddSquareForEachColAtSpecifiedRows (ref List<Square> availablePositions, List<int> rows)
        {            
            for (int col = 0; col < 8; col++)
            {
                // only add square if row value is within board
                if (rows[col] >= 0 && rows[col] < 8)
                    availablePositions.Add(Square.At(rows[col], col));
            }
        }
    }
}