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
            AvailableMoves moves = new AvailableMoves(board.FindPiece(this));
            moves.AddDiagonalSquares();
            moves.RemoveCurrentSquare();

            return moves.Squares;
        }
    }
}