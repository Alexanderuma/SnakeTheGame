using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeTheGame
{
    internal class Walls // Класс стены
    {
        List<Figure> wallList;

        public Walls(int mapWidth, int mapHeight) // Метод позволяющий отрисовывать стены(рамку)
        {
            wallList = new List<Figure>();

            //Отрисовка рамочки
            HorizontalLine upLine = new HorizontalLine(0, mapWidth - 2, 0, '+');
            HorizontalLine downLine = new HorizontalLine(0, mapWidth - 2, mapHeight - 1, '+');
            VerticalLine leftLine = new VerticalLine(0, mapHeight - 1, 0, '+');
            VerticalLine rightLine = new VerticalLine(0, mapHeight - 1, mapWidth - 2, '+');

            wallList.Add(upLine);
            wallList.Add(downLine);
            wallList.Add(leftLine);
            wallList.Add(rightLine);
        }

        internal bool IsHit(Figure figure) // Функция которая проверяет столкнулась ли Змейка со стеной
        {
            foreach (var wall in wallList)
            {
                if (wall.IsHit(figure))
                {
                    return true;
                }
            }
            return false;
        }

        public void Draw() // Метод, который отрисовывает стены(рамку игрового поля)
        {
            foreach (var wall in wallList)
            {
                wall.Draw();
            }
        }
    }
}
