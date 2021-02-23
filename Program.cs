using System;
using System.Threading;

namespace Game_Snake
{
    class Program
    {
		static void Main(string[] args)
		{
			Console.SetWindowSize(80, 25);

			Wall wall = new Wall(80, 25);
			wall.Draw();

			// Отрисовка точек			
			Points p = new Points(4, 5, '*');
			Snake snake = new Snake(p, 4, Direction.RIGHT);
			snake.Draw();

			FoodGenerator foodgenerator = new FoodGenerator(80, 25, '$');
			Points food = foodgenerator.CreateFood();
			food.Draw();

			while (true)
			{
				if (wall.IsHit(snake) || snake.IsHitTail())
				{
					break;
				}
				if (snake.Eat(food))
				{
					food = foodgenerator.CreateFood();
					food.Draw();
				}
				else
				{
					snake.Move();
				}

				Thread.Sleep(100);
				if (Console.KeyAvailable)
				{
					ConsoleKeyInfo key = Console.ReadKey();
					snake.HandleKey(key.Key);
				}
			}
			WriteGameOver();
			Console.ReadLine();
		}


		static void WriteGameOver()
		{
			int xOffset = 25;
			int yOffset = 8;
			Console.ForegroundColor = ConsoleColor.Red;
			Console.SetCursorPosition(xOffset, yOffset++);
			WriteText("============================", xOffset, yOffset++);
			WriteText("GAME OVER!", xOffset + 1, yOffset++);
			yOffset++;
			WriteText("Try Again.", xOffset + 1, yOffset++);
			WriteText("============================", xOffset, yOffset++);
		}

		static void WriteText(String text, int xOffset, int yOffset)
		{
			Console.SetCursorPosition(xOffset, yOffset);
			Console.WriteLine(text);
		}
    }
}
