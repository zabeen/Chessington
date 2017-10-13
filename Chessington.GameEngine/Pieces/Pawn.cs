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

           // check if piece has moved -row changes = move
           // if player is white original row = 6
           // if player is black original row = 1

            bool hasnotmoved = ((Player == Player.White && currentPosition.Row == 6) || (Player == Player.Black && currentPosition.Row == 1 ));

            // if not moved can move 2rows, if has moved only move 1row
            List<int> rowstomove = new List<int>();

            // can always move 1row
            rowstomove.Add(1);

            // if not moved we can move 2rows
            if (hasnotmoved)
                rowstomove.Add(2);

            foreach ( int i in rowstomove)
            {
                // Change row according player colour

                int newRow = (Player == Player.White) ? currentPosition.Row - i : currentPosition.Row + i;

                // create new position
                Square newPosition = new Square(newRow, currentPosition.Col);

                // Add move to list
                availableMoves.Add(newPosition);

            }

            // return list of available moves
            return availableMoves;
        }
    }
}