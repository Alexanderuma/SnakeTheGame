using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeTheGame
{
    internal class VerticalLine : Figure // Класс горизонтальная линия, который наследует часть свойств от Базового класса Figure
    {

        public VerticalLine(int yUp, int yDown, int x, char sym) // Конструктор, который помогает построить вертикальные линию. Принимает 4 аргумента.
        {
            pList = new List<Point>();
            for (int y = yUp; y <= yDown; y++)
            {
                Point p = new Point(x, y, sym);
                pList.Add(p);
            }
        }
    }
}
