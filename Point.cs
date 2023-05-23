using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeTheGame
{
    internal class Point // Класс точка
    {
        public int x; // Переменные класса точка, которые хранят данные определенных типов(типы: целочисленный тип, символ)
        public int y;
        public char sym;

        public Point() // Пример простого конструктора(пустого)
        {

        }

        public Point(int _x, int _y, char _sym) // Конструктор для создания точки
        {
            x = _x;
            y = _y;
            sym = _sym;
        }

        public Point(Point p) // Конытруктор для создания точки хвоста Змейки
        {
            x = p.x;
            y = p.y;
            sym = p.sym;
        }

        public void Move(int offset, Direction direction) //Метод, который позволяет переместить точку/сдвигающий Змейку в нужном направлении(вправо, влево, вверх, вниз)
        {
            if (direction == Direction.RIGHT)
            {
                x = x + offset;
            }
            else if (direction == Direction.LEFT)
            {
                x = x - offset;
            }
            else if (direction == Direction.UP)
            {
                y = y - offset;
            }
            else if (direction == Direction.DOWN)
            {
                y = y + offset;
            }
        }

        public bool IsHit(Point p) // Проверка на равенство координат(еды и головы Змейки). Используется в Классе FoodCreator в Методе Eat 
        {
            return p.x == this.x && p.y == this.y;
        }

        public void Draw() // Метод отрисовки и вывода точки на экран
        {
            Console.SetCursorPosition(x, y);
            Console.Write(sym);
        }

        public void Clear() // Метод, который стирает точку.(Данный метод помогает стереть точку хвоста, во время смещении змейки в напралении движения, когда работает метод Move)
        {
            sym = ' ';
            Draw();
        }

        public override string ToString() // Не совсем понимяю для чего Евгений Картавец создал этот метод!?!?
        {
            return x + ", " + y + ", " + sym;
        }
    }
}
