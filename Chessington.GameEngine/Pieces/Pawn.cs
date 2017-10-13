using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Player player) 
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            // returned list
            List<Square> availableMoves = new List<Square>();
 
            // find where pawn is on board
            Square currentPosition = board.FindPiece(this);

            // Change row according player colour
            int newRow = (Player == Player.White) ? currentPosition.Row - 1 : currentPosition.Row + 1;

            // create new position
            Square newPosition = new Square(newRow, currentPosition.Col);

            // Add move to list
            availableMoves.Add(newPosition);

            // return list of available moves
            return availableMoves;
        }
    }
}