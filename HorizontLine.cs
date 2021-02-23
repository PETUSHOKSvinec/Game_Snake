using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Snake
{
    class HorizontLine :Figure
	{
		public HorizontLine(int xLeft, int xRight, int y, char sym)
		{
			pList = new List<Points>();
			for (int x = xLeft; x <= xRight; x++)
			{
				Points p = new Points(x, y, sym);
				pList.Add(p);
			}
		}
	}
}
