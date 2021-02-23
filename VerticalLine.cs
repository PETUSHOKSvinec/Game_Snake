using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Snake
{
    class VerticalLine:Figure
    {
		public VerticalLine(int yUp, int yDown, int x, char sym)
		{
			pList = new List<Points>();
			for (int y = yUp; y <= yDown; y++)
			{
				Points p = new Points(x, y, sym);
				pList.Add(p);
			}
		}
	}
}
