using System;
namespace Intelligent_Design
{
	public class HUD
	{
		public int StartHeight;
		public int Height = 6; //Size of HUD
		public int Width;

		public HUD()
		{
			StartHeight = Game.Height;
            Width = Game.Width;
            for (var x = 0; x < Width; x++) for (var y = 0; y < Height; y++)
                {
                    Console.SetCursorPosition(x, y + StartHeight);
                    //Since console sometimes skips writing whitespaces i set ForegroundColor = BackgroundColor and write . instea
                    Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkRed;


            Console.Write(" ");

            }


    }

        public void Render()
        {

            //for(var x = 0; x < Width ; x++) for(var y = 0; y < Height; y++)
            //{
            //    Console.SetCursorPosition(x, y + StartHeight);
            //    //Since console sometimes skips writing whitespaces i set ForegroundColor = BackgroundColor and write . instea
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkRed;


            //    Console.Write(" ");

            //}

            Console.SetCursorPosition(3, StartHeight + 1);
            Console.WriteLine($"Year:      {Game.Round.ToString("d2")}");
            Console.SetCursorPosition(3, StartHeight + 2);
            Console.WriteLine($"Max Year:  {Game.MaxRounds}");
            Console.SetCursorPosition(3, StartHeight + 3);
            Console.WriteLine($"Changes:   {Game.Changes.ToString("d2")}");



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

