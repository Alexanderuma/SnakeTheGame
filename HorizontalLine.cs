using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeTheGame
{
    internal class HorizontalLine : Figure // Класс горизонтальная линия, который наследует часть свойств от Базового класса Figure
    {
        public HorizontalLine(int xLeft, int xRight, int y, char sym) // Конструктор, который помогает построить горизонтальную линию. Принимает 4 аргумента.
        {
            pList = new List<Point>();
            for (int x = xLeft; x <= xRight; x++)
            {
                Point p = new Point(x, y, sym);
                pList.Add(p);
            }
        }
    }
}
