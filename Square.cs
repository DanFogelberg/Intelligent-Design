using System;
namespace Intelligent_Design
{
	public class Square
	{
		public int X;
		public int Y;
		public bool HasLife = false;
		public bool WillHaveLife;
		public bool render = true;




		public Square(int x, int y)
		{
			X = x;
			Y = y;
		}


		public void Tic()
		{

			int xToCheck = X - 1;
	
		}

		public void PrepareUpdate(int liveNeighbours)
		{
			if (HasLife == true)
			{
				if (liveNeighbours > 3) WillHaveLife = false;
				if (liveNeighbours < 2) WillHaveLife = false;
			}
			else if (HasLife == false)
			{
				if (liveNeighbours == 3) WillHaveLife = true;
			}
			else WillHaveLife = HasLife;
        }

		public void Update()
		{
			if (HasLife != WillHaveLife) render = true;
			HasLife = WillHaveLife;
		}



	}
}

