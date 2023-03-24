using System;

namespace Intelligent_Design
{
	public class Game
	{
        public bool Running = true;

		public Square[,] squares;
        public static int Width;
        public static int Height;
        public BoardState[] BoardStates;
        public BoardState WinState;

        public static int MaxRounds;
        public static int Round = 1;


        public static int Changes = 0;
        public static int[] ChangesPerYear; //Since rounds is not 0-index

        public bool StepForward = false;
        public bool StepBackward = false;
        public BoardState StartBoard;

        public Game(int width, int height, int rounds)
		{
            Width = width;
            Height = height;

            MaxRounds = rounds; 
            BoardStates = new BoardState[MaxRounds];

            ChangesPerYear = new int[MaxRounds + 1];

            squares = new Square[Width, Height];
            for (int y = 0; y < Height; y++) for (int x = 0; x < Width; x++)
            {
                squares[x, y] = new Square(x, y);
            }
            StartBoard = new BoardState(squares);


            //Win state currently hardcoded. Should get this from JSON file for each level.
            WinState = new BoardState(squares);
            WinState.Squares[5, 5].HasLife = true;
            WinState.Squares[6, 5].HasLife = true;
            WinState.Squares[7, 5].HasLife = true;

            WinState.Squares[4, 6].HasLife = true;
            WinState.Squares[8, 6].HasLife = true;

            WinState.Squares[3, 7].HasLife = true;
            WinState.Squares[9, 7].HasLife = true;

            WinState.Squares[3, 8].HasLife = true;
            WinState.Squares[9, 8].HasLife = true;

            WinState.Squares[3, 9].HasLife = true;
            WinState.Squares[9, 9].HasLife = true;

            WinState.Squares[4, 10].HasLife = true;
            WinState.Squares[8, 10].HasLife = true;

            WinState.Squares[5, 11].HasLife = true;
            WinState.Squares[6, 11].HasLife = true;
            WinState.Squares[7, 11].HasLife = true;





        }


        public void Render()
        {
            
            foreach (Square square in squares)
            {
                if (square.render == false) continue;
                Console.SetCursorPosition(square.X, square.Y);
                //Since console sometimes skips writing whitespaces i set ForegroundColor = BackgroundColor and write . instead
                if (square.HasLife == true)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Green;
                    
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.ForegroundColor = ConsoleColor.DarkBlue;

                }
                Console.Write(".");
                square.render = false;
                
            }
        }



        public int GetLiveNeighbours(int x, int y)
        {
            int neighbours = 0;
            for (int yOffset = -1; yOffset <= 1; yOffset++) for (int xOffset = -1; xOffset <= 1; xOffset++)
            {
                    int newY = y + yOffset;
                    int newX = x + xOffset;
                    if (newY == y && newX == x) continue; //Skip self

                    if (newY < 0 || newY >= Height || newX < 0 || newX >= Width) continue; //Out of bounds
                    else if (squares[newX, newY].HasLife == true) neighbours += 1;

            }
            return neighbours;

        }

        public void Tic()
        {
            if (StepForward)
            {
                StepForward = false;
                if (Round + 1 > MaxRounds) return;




                BoardStates[Round] = new BoardState(squares);
                Round++;






                foreach (Square square in squares)
                {
                    int liveNeighbours = GetLiveNeighbours(square.X, square.Y);
                    square.PrepareUpdate(liveNeighbours);
                    



                }
                foreach (Square square in squares) square.Update();
                
            }
            if (StepBackward)
            {
                StepBackward = false;
                if (Round <= 1)
                {
                    Reset();
                    return;
                }
                Game.Changes -= Game.ChangesPerYear[Round];
                Game.ChangesPerYear[Round] = 0;

                Round--;

                

               
                for (int y = 0; y < Height; y++) for (int x = 0; x < Width; x++)
                    {
                        if (squares[x, y].HasLife != BoardStates[Round].Squares[x, y].HasLife) squares[x, y].render = true;
                        squares[x, y].HasLife = BoardStates[Round].Squares[x, y].HasLife;
                        squares[x, y].WillHaveLife = BoardStates[Round].Squares[x, y].WillHaveLife;
                    }



            }


        
        }

        public void SaveStart()
        {
            StartBoard = new BoardState(squares);

        }

        public void Reset()
        {
            Game.Changes = 0;
            for (int y = 0; y < Height; y++) for (int x = 0; x < Width; x++)
            {
                    if (squares[x, y].HasLife != StartBoard.Squares[x, y].HasLife) squares[x, y].render = true;
                    squares[x, y].HasLife = StartBoard.Squares[x, y].HasLife;
                    squares[x, y].WillHaveLife = StartBoard.Squares[x, y].WillHaveLife;
            }

        }

        public void RenderWinCondition()//Should probably use Render() with a condition instead
        {
            foreach (Square square in WinState.Squares)
            {
                Console.SetCursorPosition(square.X, square.Y);
                //Since console sometimes skips writing whitespaces i set ForegroundColor = BackgroundColor and write . instead
                if (square.HasLife == true)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Green;

                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.ForegroundColor = ConsoleColor.DarkBlue;

                }
                Console.Write(".");
            }
            foreach (Square square in squares) square.render = true;
            System.Threading.Thread.Sleep(1000);

        }


        public void CheckWinState()
        {
            for (int y = 0; y < Height; y++) for (int x = 0; x < Width; x++)
                {
                    if (squares[x, y].HasLife != WinState.Squares[x, y].HasLife) return;
                }

            Console.Clear();

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Red;

            Console.SetCursorPosition(5, 5);
            Console.WriteLine($"You have won the game! With just {Changes} changes! You have earned yourself a kebab.");
            Console.SetCursorPosition(5, 7);
            Console.WriteLine($"Press any key to quit!");
            Console.ReadKey();
            Running = false;
           




        }

    }
}

