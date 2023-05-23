using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeTheGame
{
    internal class Figure // Базовый класс для классов наследников(HorizontalLine и VerticalLine)
    {
        protected List<Point> pList; // Список точек класса Figure

        public void Draw() // Метод отриовки фигуры(Figure), который обращается к методу отрисовки точки.
        {
            foreach (Point p in pList)
            {
                p.Draw();
            }
        }

        internal bool IsHit(Figure figure) // Проявление полиморфизма, две функции с одинаковым названием принимают разные аргументы. В этой функции IsHit принимается фигура. В нижней функции IsHit принимается точка. 
        {
            foreach (var p in pList)
            {
                if (figure.IsHit(p))
                    return true;
            }
            return false;
        }

        private bool IsHit(Point point) // Функция, которая проверяет на столкновение с какой-либо точкой
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
