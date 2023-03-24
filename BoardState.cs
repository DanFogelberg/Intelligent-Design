using System;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Globalization;
using System.Text;


//This Class keeps track of a previous board state. Board States are kept in an array to allow the player to step back to a previous state
namespace Intelligent_Design
{
	public class BoardState
	{
        public Square[,] Squares;
        //int Width;
        //int Height;

        public BoardState(Square[,] squares)
		{
            Squares = new Square[squares.GetLength(0), squares.GetLength(1)];

            //Create new Squares and save data. I do it this way because deep copy of 2D array is tricky
            for (int y = 0; y < squares.GetLength(1); y++) for (int x = 0; x < squares.GetLength(0); x++)
                {
                    Squares[x, y] = new Square(x, y);
                    Squares[x, y].HasLife = squares[x, y].HasLife;
                    Squares[x, y].WillHaveLife = squares[x, y].WillHaveLife;
                }

        }
	}
}

