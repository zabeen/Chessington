using System;
using NUnit.Framework;
using Chessington.GameEngine.Pieces;
using System.Collections.Generic;
using FluentAssertions;
using System.Linq;

namespace Chessington.GameEngine.Tests
{
    [TestFixture]
    public class AvailableMovesTest
    {
        [Test]
        public void Squares_WithinBounds()
        {
            Board board = new Board();
            List<Piece> pieces = new List<Piece>(){
                new Bishop(Player.White),
                new King(Player.White),
                new Knight(Player.White),
                new Pawn(Player.White),
                new Queen(Player.White),
                new Rook(Player.White)
            };

            // place all pieces at top of board
            for (int i = 0; i < pieces.Count; i++)
            {
                board.AddPiece(Square.At(0, i), pieces[i]);
            }

            // generate available moves for each piece
            List<Square> moves = new List<Square>();
            foreach(Piece piece in pieces)
            {
                moves.AddRange(piece.GetAvailableMoves(board));
            }

            // test that all squares are within bounds
            List<Square> outOfBounds = moves.Where(m => m.Row < 0 || m.Row > 7|| m.Col < 0 || m.Col > 7).ToList();
            outOfBounds.Should().HaveCount(0);
        }


    }
}
