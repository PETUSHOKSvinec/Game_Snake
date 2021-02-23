using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Snake
{
    class Figure
    {
		protected List<Points> pList;

		public void Draw()
		{
			foreach (Points p in pList)
			{
				p.Draw();
			}
		}

		internal bool IsHit(Figure figure)
		{
			foreach (var p in pList)
			{
				if (figure.IsHit(p))
					return true;
			}
			return false;
		}

		private bool IsHit(Points point)
		{
			foreach (var p in pList)
			{
				if (p.IsHit(point))
					return true;
			}
			return false;
		}
	}
}
