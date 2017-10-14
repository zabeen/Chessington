using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Knight : Piece
    {
        public Knight(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            AvailableMoves moves = new AvailableMoves(board.FindPiece(this));
            moves.AddKnightsSquares();

            return moves.Squares;
        }
    }
}