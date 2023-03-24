using Intelligent_Design;
using System.Windows.Input;

internal class Program
{
    private static void Main(string[] args)
    {
        int ticTimer = 100; //In MS. Will probably run a lot slower due to console limitations.
        int gameHeight = 15;
        int gameWidth = Console.WindowWidth / 2 - 2;
        int maxRounds = 50;

        Game game = new Game(gameWidth, gameHeight, maxRounds);

        //HUD hud = new HUD();
        //Selector selector = new Selector(game); //Reference to game needed for rendering.


        //Game Loop
        while (game.Running)
        {
            game.CheckWinState();//Ends game if won.

            // listen to key presses
            if (Console.KeyAvailable)
            {
                var input = Console.ReadKey();
                switch (input.Key)
                {
                    //Key presses set states used in board/selector.tic()
                    case ConsoleKey.UpArrow: //Move cursor
                        game.Selector.Up = true;
                        break;
                    case ConsoleKey.DownArrow:
                        game.Selector.Down = true;
                        break;
                    case ConsoleKey.LeftArrow:
                        game.Selector.Left = true;
                        break;
                    case ConsoleKey.RightArrow:
                        game.Selector.Right = true;
                        break;
                    case ConsoleKey.W: //Next frame
                        game.StepForward = true;
                        break;
                    case ConsoleKey.Q: //Previous frame
                        game.StepBackward = true;
                        break;
                    case ConsoleKey.Spacebar: //Flip square life
                        game.Selector.ChangeLife = true;
                        break;
                    case ConsoleKey.Tab: //Flip square life
                        game.RenderWinCondition();
                        continue;
                    case ConsoleKey.Escape:
                        game.Running = false; //Stops game
                        return;


                }
            }
            game.Tic();
            //selector.Tic();
            //hud.Render();
            game.Render();
            //selector.Render();


            Console.SetCursorPosition(0, 10000); //Hiding cursor. Since Console.CursorVisible doesn't work properly.
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Black;

            Thread.Sleep(ticTimer);
        }
    }
}