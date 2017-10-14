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
            // Get current position
            Square current = board.FindPiece(this);

            // Create object to generate available moves
            AvailableMoves moves = new AvailableMoves(current);

            // check if pawn has moved by its row number
            // if player is white, original row = 6
            // if player is black, original row = 1
            bool hasnotmoved = ((Player == Player.White && current.Row == 6) || (Player == Player.Black && current.Row == 1));

            // pawn can always move at least one square forward
            List<int> rowsToMove = new List<int>(){ 1 };

            // if pawn has not moved, it can also move 2 rows
            if (hasnotmoved)
                rowsToMove.Add(2);

            // convert each int to negative if player is White
            if (Player == Player.White)
                rowsToMove = rowsToMove.Select(i => -i).ToList();

            // add forward moves
            moves.AddForwardSquares(rowsToMove);

            // return list of available moves
            return moves.Squares;
        }
    }
}