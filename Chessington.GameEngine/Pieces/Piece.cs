using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public abstract class Piece
    {
        public Player Player { get; private set; }

        protected Piece(Player player)
        {
            Player = player;
        }

        public abstract IEnumerable<Square> GetAvailableMoves(Board board);

        public void MoveTo(Board board, Square newSquare)
        {
            var currentSquare = board.FindPiece(this);
            board.MovePiece(currentSquare, newSquare);
        }

        protected IEnumerable<Square> GetAvailableMoves_Diagonal(Square current)
        {
            // returned list
            List<Square> availablePositions = new List<Square>();

            // Row values at left and right edges of board
            int topRowLeftEdge = current.Row - current.Col;
            int bottomRowRightEdge = topRowLeftEdge + 7;
            int bottomRowLeftEdge = current.Row + current.Col;
            int topRowRightEdge = bottomRowLeftEdge - 7;

            // add squares top left to bottom right
            AddSquareForEachColAtSpecifiedRows(
                ref availablePositions,
                rows: Enumerable.Range(topRowLeftEdge, bottomRowRightEdge - topRowLeftEdge + 1).ToList());

            // add squares bottom left to top right
            AddSquareForEachColAtSpecifiedRows(
                ref availablePositions,
                rows: Enumerable.Range(topRowRightEdge, bottomRowLeftEdge - topRowRightEdge + 1).Reverse().ToList());

            //remove squares that match current position
            availablePositions.RemoveAll(a => a == current);

            return availablePositions;
        }

        private void AddSquareForEachColAtSpecifiedRows(ref List<Square> availablePositions, List<int> rows)
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