using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeTheGame
{
    internal class FoodCreator // Класс FoodCreator, создает новую еду для Змейки, в произвольных местах, в пределах карты
    {
        int mapWidth; // Переменные объекта класса FoodCreator
        int mapHeight;
        char sym;

        Random random = new Random();

        public FoodCreator(int mapWidth, int mapHeight, char sym) // Конструктор, принимает в качестве аргуметов размеры карты и символ(еды)
        {
            this.mapWidth = mapWidth; // Переменная this.mapWidth - является переменной данного класса. А переменная = mapWidth - является аргументом, которые перечисленны в скобках выше.
            this.mapHeight = mapHeight;
            this.sym = sym;
        }
        public Point CreateFood()
        {
            int x = random.Next(2, mapWidth - 2);
            int y = random.Next(2, mapHeight - 2);
            return new Point(x, y, sym);
        }
    }
}
