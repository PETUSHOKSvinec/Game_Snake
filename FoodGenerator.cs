using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Snake
{
    class FoodGenerator
    {
		int mapWidht;
		int mapHeight;
		char sym;

		Random random = new Random();

		public FoodGenerator(int mapWidth, int mapHeight, char sym)
		{
			this.mapWidht = mapWidth;
			this.mapHeight = mapHeight;
			this.sym = sym;
		}

		public Points CreateFood()
		{
			int x = random.Next(2, mapWidht - 2);
			int y = random.Next(2, mapHeight - 2);
			return new Points(x, y, sym);
		}
	}
}
