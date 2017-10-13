using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Rook : Piece
    {
        public Rook(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            // returned list
            List<Square> availablePositions = new List<Square>();

            // get current position
            Square currentPosition = board.FindPiece(this);
          
            for (int i = 0; i < 8; i++)
            {
                //create new squares where row remains const and col iterates from 0 - 7
                availablePositions.Add(new Square(currentPosition.Row, i));
                //create new squares where column remains const and row iterates from 0 - 7
                availablePositions.Add(new Square(i, currentPosition.Col));
            }

            //remove squares that match starting/ current position
            availablePositions.RemoveAll(a => a == currentPosition);

            return availablePositions;
        }
    }
}