using System;
namespace Intelligent_Design
{
	public class HUD
	{
		private readonly int StartHeight;
		private readonly int Height = 6; //Size of HUD
		private readonly int Width;

		public HUD(int height, int width)
		{
			StartHeight = height;
            Width = width;
            for (var x = 0; x < Width; x++) for (var y = 0; y < Height; y++)
            {
                Console.SetCursorPosition(x, y + StartHeight);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write(" ");
            }

        }

        public void Render()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkRed;

            //First row.
            Console.SetCursorPosition(3, StartHeight + 1);
            Console.WriteLine($"Year:      {Game.Round.ToString("d2")}");
            Console.SetCursorPosition(3, StartHeight + 2);
            Console.WriteLine($"Max Year:  {Game.MaxRounds}");
            Console.SetCursorPosition(3, StartHeight + 3);
            Console.WriteLine($"Changes:   {Game.Changes.ToString("d2")}");
            //Second row.
            Console.SetCursorPosition(Width / 2, StartHeight + 1);
            Console.WriteLine($"Change Year:  Q/W");
            Console.SetCursorPosition(Width / 2, StartHeight + 2);
            Console.WriteLine($"Change Life:  Space");
            Console.SetCursorPosition(Width / 2, StartHeight + 3);
            Console.WriteLine($"Change Space: Arrows");
            Console.SetCursorPosition(Width / 2, StartHeight + 4);
            Console.WriteLine($"Win State:    Tab");

        }
    }
}

