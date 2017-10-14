using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class King : Piece
    {
        public King(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            AvailableMoves moves = new AvailableMoves(board.FindPiece(this));
            // create 2D array of move adjustments
            int[,] adjustments = new int[,] { { 1, 1 }, { 1, 0 }, { 1, -1 }, { 0, 1 }, { 0, -1 }, { -1, 1 }, { -1, 0 }, { -1, -1 } };
            moves.AddAdjustedSquares(adjustments);

            return moves.Squares;
        }
    }
}