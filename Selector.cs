using System;

//This is the games "Cursor". Works separetly from the actual Console Cursor
namespace Intelligent_Design
{
	public class Selector
	{
		public Game Board; //Set in program. Referenced for rendering and editing hasLife.

		public bool Up = false;
        public bool Down = false;
        public bool Left = false;
        public bool Right = false;
		public bool ChangeLife = false;
		

        public int X = 1;
		public int Y = 1;
		public Selector(Game board)
		{
			Board = board;

		}



		public void Tic()
		{
			if (ChangeLife)
			{
				Board.squares[X, Y].HasLife = !Board.squares[X, Y].HasLife;
				Board.squares[X, Y].WillHaveLife = Board.squares[X, Y].HasLife;

                Game.Changes++;
				Game.ChangesPerYear[Game.Round]++;
			}


			if (Up) Move(0, -1);
            if (Down) Move(0, 1);
            if (Left) Move(-1, 0);
            if (Right) Move(1, 0);

			Up = false;
			Down = false;
			Left = false;
			Right = false;
			ChangeLife = false;
        }
		public void Render()
		{
			Console.SetCursorPosition(X, Y);
			Console.BackgroundColor = ConsoleColor.Yellow;
			if (Board.squares[X, Y].HasLife == true) Console.BackgroundColor = ConsoleColor.DarkYellow;
			
			Console.Write(" ");
			
		}

		public void Move(int x, int y)
		{
			Board.squares[X, Y].render = true;
			if (x + X >= 0 && x + X < Game.Width) X = X + x;

            if (y + Y >= 0 && y + Y < Game.Height) Y = Y + y;

        }
	}
}

