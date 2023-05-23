using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/* Из своего добавил:
 * Меню, чтобы было возможно выбрать несколько опций: 1 - Начать игру, 2 - Посмотреть результаты игроков(Показывает результаты только за текущую игру), 3 - Выход из игры.
 * Использовал переменную playerName, чтобы можно было записывать имя игрока и потом заносить его в список резльтатов.
 * Исползовал счетчик scoreCounter. Он позволяет подсчитать максимальное колличество очков за каждую игру и записать в список результатов.
 * Создал список playersList для записи имен игроков и их резултатов.
 * Также результат набранных очков предварительно выводиться в центре окна в конце игры, после того, как Змейка столкнется и игра остановиться.
 */

namespace SnakeTheGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // "Snake The Game"
            string playerName;
            int scoreCounter = 0; 
            List<string> playersList = new List<string>();

            while (true)
            {
                Console.WriteLine("\nSnake The Game\n\nНачать игру - 1\nПосмотреть результаты игроков - 2\nВыход - 3\n"); // Основное меню игры
                Console.Write("Ваш выбор: ");
                string answer = Console.ReadLine();
                Console.Clear();

                if (answer == "1")
                {
                    Console.Write("\nНапишите имя игрока: ");
                    playerName = Console.ReadLine();
                    Console.Read();

                    Console.Clear(); // Удаляет строчки меню с консоли. Освобождая место для игрового поля.

                    Console.SetWindowSize(80, 25); // Размеры окна, в котором передвигается змейка.
                    Console.SetBufferSize(80, 25);

                    //Отрисовка рамочки
                    Walls walls = new Walls(80, 25);
                    walls.Draw();


                    // Отрисовка точек Змейки
                    Point p = new Point(4, 5, '*');
                    Snake snake = new Snake(p, 4, Direction.RIGHT);
                    snake.Draw();

                    FoodCreator foodCreator = new FoodCreator(80, 25, '$'); // Функция, которая создает еду для змейки
                    Point food = foodCreator.CreateFood();
                    food.Draw();

                    while (true)
                    {
                        if (walls.IsHit(snake) || snake.IsHitTail()) // Проверка столкновения змейки(Реализация находиться в классе Walls) со стеной ИЛИ с хвостом(Реализация находиться в классе Snake)
                        {
                            string centerText = ($"{playerName} ваш результат: { scoreCounter}"); // Результат, показывает колличество очков.
                            int centerX = (Console.WindowWidth / 2) - (centerText.Length / 2); // Появляется в центре экрана, после столкновения.
                            int centerY = (Console.WindowHeight / 2) - 1; //
                            Console.SetCursorPosition(centerX, centerY); //
                            Console.Write(centerText); //
                            
                            Console.ReadLine();
                            break;
                        }
                        if (snake.Eat(food)) // Метод snake.Eat , реализацию которого можно посмотреть в классе Snake
                        {
                            scoreCounter+=1; // Счетчик, считает очки(еду, которую съела Змейка)
                            food = foodCreator.CreateFood(); // На карте появляется новая еда(Вызываем класс FoodCreator и создаем новую рандомную точку еды)
                            food.Draw();
                        }
                        else
                        {
                            snake.Move();
                        }
                        Thread.Sleep(100); // Задержка по времени движения Змейки в 100 мс(миллисекунд)

                        if (Console.KeyAvailable)
                        {
                            ConsoleKeyInfo key = Console.ReadKey(); // Часть кода, которая обрабатывает нажатие кнопок направления. Вызывает метод HandleKey()
                            snake.HandleKey(key.Key);
                        }
                    }

                    string result = playerName + " - " + scoreCounter; // Склеивает имя игрока и его очки в строку и передает в переменную result.
                    playersList.Add(result); // Добовляет переменную result в спмсок playersList
                    scoreCounter = 0; // Обнуляет счетчик
                    Console.ReadLine();

                    Console.Clear(); // Стирает игровое поле с консоли и позволяет вывести меню на пустой экран консоли.
                                     
                }
                else if (answer == "2")
                {
                    Console.WriteLine("\nРезультаты игроков:\n"); // Показывает все результаты играющих. 
                    foreach ( string line in playersList)
                    {
                        Console.WriteLine(line);
                    }

                    Console.ReadKey();
                    Console.Clear();
                }
                else if (answer == "3")
                {
                    break; // Выход из основного меню. 
                }
                else
                    Console.WriteLine("Выберите правильную опцию."); // Если пользователь выбирает неправильную опцию, то подсказывает и выодит в "основное меню"
                    

                
            }   
        }
    }
}
