// See https://aka.ms/new-console-template for more information
using Game;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Xml.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Numerics;

namespace Game
{
    class Programm
    {
        static void Main(string[] args)
        {
            string i = StartGame(); // получение уровня сложности, вызов стартового меню
            IObj Player = new Tank(0, 0, 0, "Игрок танк", 0); // создание объекта игрока
            IObj Enemy = ChooseEnemy(); // создание объекта соперника и присваивание ему объекта полученного из меню выбора соперника
            Player.SetDif(i, Enemy); // вызов метода установка сложности игры
            Console.Clear();
            BattleFight(Player, Enemy); // передача объектов для "Сражения"
        }
        public static string StartGame() // стартовое меню
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("1.Начать игру \n2.Выход");
                string check_key = Console.ReadLine();
                switch (check_key)
                {
                    case "1":
                        string k = ChooseDif(); // переход в меню выбора сложности
                        return k;
                    case "2":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Выберите доступный пункт меню");
                        Thread.Sleep(750);
                        Console.Clear();
                        continue;
                }
            }
        }
        public static string ChooseDif() // меню выбора сложности
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("Выберите уровень сложности \n 1.Лёгкий \n 2.Нормальный \n 3.Тяжелый");
                string check_key = Console.ReadLine();
                switch (check_key)
                {
                    case "1":
                        return check_key;
                    case "2":
                        return check_key;
                    case "3":
                        return check_key;
                    default:
                        Console.WriteLine("Выберите доступный пункт меню");
                        Thread.Sleep(750);
                        Console.Clear();
                        continue;
                }
            }
        }
        public static void BattleFight(IObj Player, IObj Enemy) // меню "Сражения"
        {
            Random rand = new Random();
            while (Player.Health > 0 && Enemy.Health > 0) 
            {
                Console.Clear();
                Player.TTHinfo(); // вызов метода информации о текущем состоянии объекта
                Enemy.TTHinfo();  // вызов метода информации о текущем состоянии объекта
                Console.WriteLine("\nВыберите действие!\n");
                Console.WriteLine("1:Выстрел|2:Починка|3:Покупка снарядов");
                string h = Console.ReadLine();
                        switch (h)
                        {
                            case "1":
                                Player.Shot(Enemy); // вызов метода выстрел игрока по сопернику
                                break;
                            case "2":
                                Player.Repair(); // вызов метода починка игрока
                                break;
                            case "3":
                                Player.Reload(); // вызов метода перезорядка игрока
                                break;
                            default:
                                Console.WriteLine("Выбрано не верное действие\n");
                                Thread.Sleep(1000);
                                continue;
                        }
                if (Enemy.Health > 0)
                {
                    IAi artif_intell = new AI(); // создание объекта класса компьютер
                    artif_intell.AI_motion(Enemy, Player); // выозов метода ход компьютера
                }
                else
                {
                    Console.WriteLine("\nВы победили!");
                }
                Console.WriteLine("Нажмите любую клавишу, чтобы продолжить...");
                Console.ReadKey();
            }
            Console.WriteLine("\nКонец игры!");
        }
        public static IObj ChooseEnemy() // меню выбора соперника
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("Выберите соперника \n 1.Танк \n 2.Самолёт");
                string check_key = Console.ReadLine();
                switch (check_key)
                {
                    case "1":
                        IObj EnemyT = new Tank(0, 0, 0, "Соперник танк", 0); // создание соперника объекта танк
                        Console.Clear();
                        Console.WriteLine($"Игра против {EnemyT.Name}!");
                        Thread.Sleep(1500);
                        return EnemyT; // передача объекта
                    case "2":
                        IObj EnemyS = new Aircraft(0, 0, 0, "Соперник самолёт", 0); // создание соперника объекта самолёт
                        Console.Clear();
                        Console.WriteLine($"Игра против {EnemyS.Name}!");
                        Thread.Sleep(1500);
                        return EnemyS; // передача объекта
                    default:
                        Console.WriteLine("Выберите доступный пункт меню");
                        Thread.Sleep(750);
                        Console.Clear();
                        continue;
                }
            }
        }
    }
}