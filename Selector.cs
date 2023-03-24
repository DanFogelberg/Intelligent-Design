using System;

//This is the games "Cursor". Works separetly from the actual Console Cursor
namespace Intelligent_Design
{
	public class Selector
	{
        public Game Board; //Set in program. Referenced for rendering and editing hasLife and Changes. Should probably be rebuilt so Game calls Selector functions and passes only needed data.

        public bool Up = false;
        public bool Down = false;
        public bool Left = false;
        public bool Right = false;
		public bool ChangeLife = false;

		private readonly int MaxHeight;
		private readonly int MaxWidth;
		
        private int X = 1;
		private int Y = 1;

		public Selector(int maxHeight, int maxWidth, Game game)
		{
			MaxHeight = maxHeight;
			MaxWidth = maxWidth;
			Board = game;

		}



		public void Tic()
		{
			if (ChangeLife)
			{
				Board.Squares[X, Y].HasLife = !Board.Squares[X, Y].HasLife;
				Board.Squares[X, Y].WillHaveLife = Board.Squares[X, Y].HasLife;

                Game.Changes++;
				Game.ChangesPerRound[Game.Round]++;
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
			if (Board.Squares[X, Y].HasLife == true) Console.BackgroundColor = ConsoleColor.DarkYellow;
			
			Console.Write(" ");
			
		}

		public void Move(int x, int y)
		{
			Board.Squares[X, Y].render = true;
			if (x + X >= 0 && x + X < MaxWidth) X = X + x;
            if (y + Y >= 0 && y + Y < MaxHeight) Y = Y + y;

        }
	}
}

