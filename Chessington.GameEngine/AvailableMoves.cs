using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine
{
    public class AvailableMoves
    {
        public readonly List<Square> Squares;
        public readonly Square Current;

        public AvailableMoves(Square current)
        {
            Squares = new List<Square>();
            Current = current;
        }

        public void AddForwardMoves(List<int> numberOfRowsToMove)
        {
            foreach (int i in numberOfRowsToMove)
            {
                // create new position
                Square newPosition = Square.At(Current.Row + i, Current.Col);

                // Add move to list
                Squares.Add(newPosition);
            }
        }

        public void AddLateralSquares()
        {
            for (int i = 0; i < 8; i++)
            {
                //create new squares where row remains const and col iterates from 0 - 7
                Squares.Add(Square.At(Current.Row, i));

                //create new squares where column remains const and row iterates from 0 - 7
                Squares.Add(Square.At(i, Current.Col));
            }
        }

        public void AddDiagonalSquares()
        {
            // Calculate row values at left and right edges of board
            int topRowLeftEdge = Current.Row - Current.Col;
            int bottomRowRightEdge = topRowLeftEdge + 7;
            int bottomRowLeftEdge = Current.Row + Current.Col;
            int topRowRightEdge = bottomRowLeftEdge - 7;

            // add squares from top left to bottom right
            AddSquareForEachColAtSpecifiedRows(
                Enumerable.Range(topRowLeftEdge, bottomRowRightEdge - topRowLeftEdge + 1).ToList());

            // add squares from bottom left to top right
            AddSquareForEachColAtSpecifiedRows(
                Enumerable.Range(topRowRightEdge, bottomRowLeftEdge - topRowRightEdge + 1).Reverse().ToList());
        }

        public void RemoveCurrentSquare()
        {
            //remove squares that match current position
            Squares.RemoveAll(s => s == Current);
        }

        private void AddSquareForEachColAtSpecifiedRows(List<int> rows)
        {
            for (int i = 0; i < 8; i++)
            {
                // only add square if row value is within board
                if (rows[i] >= 0 && rows[i] < 8)
                    Squares.Add(Square.At(rows[i], i));
            }
        }
    }
}
