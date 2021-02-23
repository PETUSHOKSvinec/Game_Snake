using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game_Snake
{
    class Snake:Figure
    {
		Direction direction;

		public Snake(Points tail, int length, Direction _direction)
		{
			direction = _direction;
			pList = new List<Points>();
			for (int i = 0; i < length; i++)
			{
				Points p = new Points(tail);
				p.Move(i, direction);
				pList.Add(p);
			}
		}

		public void Move()
		{
			Points tail = pList.First();
			pList.Remove(tail);
			Points head = GetNextPoint();
			pList.Add(head);

			tail.Clear();
			head.Draw();
		}

		public Points GetNextPoint()
		{
			Points head = pList.Last();
			Points nextPoint = new Points(head);
			nextPoint.Move(1, direction);
			return nextPoint;
		}

		public bool IsHitTail()
		{
			var head = pList.Last();
			for (int i = 0; i < pList.Count - 2; i++)
			{
				if (head.IsHit(pList[i]))
					return true;
			}
			return false;
		}

		public void HandleKey(ConsoleKey key)
		{
			if (key == ConsoleKey.LeftArrow)
				direction = Direction.LEFT;
			else if (key == ConsoleKey.RightArrow)
				direction = Direction.RIGHT;
			else if (key == ConsoleKey.DownArrow)
				direction = Direction.DOWN;
			else if (key == ConsoleKey.UpArrow)
				direction = Direction.UP;
		}

		public bool Eat(Points food)
		{
			Points head = GetNextPoint();
			if (head.IsHit(food))
			{
				food.sym = head.sym;
				pList.Add(food);
				return true;
			}
			else
				return false;
		}
	}
}
