using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeTheGame
{
    internal class Snake : Figure // Класс Змейка, который является наследником класса фигура(Figure)
    {
        Direction direction; // Класс Snake хранит данные направления, в котором змейка должна двигаться
        public Snake(Point tail, int lenght, Direction _direction)  // Конструктор, позволящий создавать Змейку из списка точек.
        {
            direction = _direction;
            pList = new List<Point>();
            for (int i = 0; i < lenght; i++)
            {
                Point p = new Point(tail);
                p.Move(i, direction);
                pList.Add(p);

            }
        }

        internal void Move() //
        {
            Point tail = pList.First(); // Метод First возвращает первый элемент списка
            pList.Remove(tail);
            Point head = GetNextPoint(); // Переменная head заполниться значением, которое вернет функцию GetNextPoint(Результат работы этой функции будет записан в переменную head).
            pList.Add(head);

            tail.Clear();
            head.Draw();
        }

        public Point GetNextPoint() // Функция, которая генерирует новую точку и сдвигает в направлении движения(direction).(Функция, которая вычисляет в какой точке будет Змейка в следующий момент).

        {
            Point head = pList.Last();
            Point nextPoint = new Point(head);
            nextPoint.Move(1, direction);
            return nextPoint;
        }


        internal bool IsHitTail() // Функция, которая проверяет было ли столкновение гловы Змейки с "хвостом"(с телом змейки)
        {
            var head = pList.Last();
            for (int i = 0; i < pList.Count - 2; i++)
            {
                if (head.IsHit(pList[i]))
                    return true;
            }
            return false;
        }


        public void HandleKey(ConsoleKey key) // Метод, который реагирует на нажатие клавиш управления и направляет Змейку
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

        internal bool Eat(Point food) // Метод Eat, который реализует "поедание" еды Змейкой
        {
            Point head = GetNextPoint(); // Получаем точку, соответсвующую следующему положению головы Змейки.
            if (head.IsHit(food)) // Делаем проверку сравнения по координатам: будет ли точка головы в следующий момент в точке, где находиться еда? // Если да, то Змейка "съедает" еду.
            {
                food.sym = head.sym; // Змейка удлиняется (Изменяет символ еды на звездочку. Добовляет еду в список точек своего тела)
                pList.Add(food);
                return true;
            }
            else
                return false; // Если нет, то "ползет" дальше
        }
    }
}
