using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Tank : IObj // класс танк, реализует интерфейс объект
    {
        private int _Armor;
        private int _Health;
        private int _Damage;
        private int _MaxHealth;
        private string _Name;
        private int _MaxArmor;
        private int _Bullets;
        private int _MaxBullets;
        public int Armor
        {
            get { return _Armor; }
            set { _Armor = value; }
        }
        public int Health
        {
            get { return _Health; }
            set { _Health = value; }
        }
        public int Damage
        {
            get { return _Damage; }
            set { _Damage = value; }
        }
        public int MaxHealth
        {
            get { return _MaxHealth; }
            set { _MaxHealth = value; }
        } 
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        public int MaxArmor
        {
            get { return _MaxArmor; }
            set { _MaxArmor = value; }
        }
        public int Bullets
        {
            get { return _Bullets; }
            set { _Bullets = value; }
        }
        public int MaxBullets
        {
            get { return _MaxBullets; }
            set { _MaxBullets = value; }
        }
        public void Shot(IObj _object) // метод выстрел
        {
            Random rnd = new Random();
            int k = rnd.Next(1, 11); // получаем случайное число от 1 до 10
            double Critdmg = 0; // объявление переменной критического урона
            if (this.Bullets > 0)
            {
                if (k > 9) // 10% вероятность крит.попадания
                {
                    Critdmg = Convert.ToDouble(this.Damage) * 0.2; // вычисление крит.урона
                    Console.WriteLine("\n ****Критический попадание****");
                }
                if (k <= 2) // 20% вероятность промаха
                {
                    Console.WriteLine($"\nИгрок {this.Name} не попал\n");
                    Console.WriteLine(" ****Промах****\n");
                    this.Bullets--;
                    Thread.Sleep(2000);
                    return; // выход из метода если промах - нет попадания
                }
                Console.WriteLine($"\nСтреляет: {this.Name}, По цели: {_object.Name} (Броня: {_object.Armor}, Здоровье: {_object.Health})\n ****Наносится урон: {this.Damage + Convert.ToInt32(Critdmg)}****");
                if (_object.Armor >= this.Damage + Convert.ToInt32(Critdmg)) // проверка: хватит ли брони, чтобы поглотить урон
                {
                    _object.Armor = _object.Armor - this.Damage - Convert.ToInt32(Critdmg); // наносится урон по броне
                    this.Bullets--;
                }
                else // урон наносится по здоровью и броне
                {
                    _object.Health = _object.Health + (_object.Armor - this.Damage - Convert.ToInt32(Critdmg));
                    _object.Armor = 0;
                    this.Bullets--;
                }
                if (_object.Health <= 0)
                    Console.WriteLine($"\n{_object.Name} уничтожен\n");
                else
                    Console.WriteLine($"Есть пробитие по цели: {_object.Name} (Броня: {_object.Armor}, Здоровье: {_object.Health}) \n");
            }
            else if (this.Bullets <= 0 && this.Name == "Игрок танк") // если стреляет игрок без снарядов, пропуск хода
            {
                Console.WriteLine("\nУ Вас нет снарядов, необходимо приобрести снаряды!");
                Console.WriteLine("\n ****Пропуск хода****\n");
            }
            else if (this.Bullets <= 0 && this.Name == "Соперник танк") // если стреляет соперник, он покупает снаряды
            {
                this.Reload();
            }
            Thread.Sleep(2000);
            Critdmg = 0;
        }
        public Tank(int Armor, int Health, int Damage, string Name, int Bullets) // конструктор класса
        {
            this.Armor = Armor;
            this.Health = Health;
            this.Damage = Damage;
            this.Name = Name;
            this.MaxHealth = Health;
            this.MaxArmor = Armor;
            this.Bullets = Bullets;
            this.MaxBullets = Bullets;
        }
        public void SetDif(string i, IObj Enemy) // метод установки сложности (пресетов)
        {
            if (Convert.ToInt32(i) == 1)
            {
                Console.Clear();
                Console.WriteLine($"Игра на легком уровене сложности!");
                Thread.Sleep(1500);
                this.Armor = 100;
                this.MaxArmor = 100;
                this.Health = 100;
                this.MaxHealth = 100;
                this.Damage = 30;
                this.Bullets = 3;
                this.MaxBullets = 3;
                Enemy.Armor = 50;
                Enemy.MaxArmor = 50;
                Enemy.Health = 50;
                Enemy.MaxHealth = 50;
                Enemy.Damage = 20;
                Enemy.Bullets = 3;
                Enemy.MaxBullets = 3;
            }
            else if (Convert.ToInt32(i) == 2)
            {
                Console.Clear();
                Console.WriteLine($"Игра на среднем уровене сложности!");
                Thread.Sleep(1500);
                this.Armor = 100;
                this.MaxArmor = 100;
                this.Health = 100;
                this.MaxHealth = 100;
                this.Damage = 30;
                this.Bullets = 3;
                this.MaxBullets = 3;
                Enemy.Armor = 100;
                Enemy.MaxArmor = 100;
                Enemy.Health = 100;
                Enemy.MaxHealth = 100;
                Enemy.Damage = 30;
                Enemy.Bullets = 3;
                Enemy.MaxBullets = 3;
            }
            else if (Convert.ToInt32(i) == 3)
            {
                Console.Clear();
                Console.WriteLine($"Игра на тяжелом уровене сложности!");
                Thread.Sleep(1500);
                this.Armor = 100;
                this.MaxArmor = 100;
                this.Health = 100;
                this.MaxHealth = 100;
                this.Damage = 30;
                this.Bullets = 3;
                this.MaxBullets = 3;
                Enemy.Armor = 150;
                Enemy.MaxArmor = 150;
                Enemy.Health = 120;
                Enemy.MaxHealth = 120;
                Enemy.Damage = 30;
                Enemy.Bullets = 4;
                Enemy.MaxBullets = 4;
            }
        }
        public void Repair() // метод починки
        {
            Random rnd = new Random();
            int k = rnd.Next(Convert.ToInt32(Convert.ToDouble(this.MaxHealth) * 0.05),Convert.ToInt32(Convert.ToDouble(this.MaxHealth) * 0.20) + 1); // восстановить возможно от 5% до 20% от максимального здоровья объекта
            if (this.Health == this.MaxHealth) // починка не возможна при полном здоровье
            {
                Console.WriteLine($"\nУ Вас полное здоровье!, Вы пропускаете ход...");
                Console.WriteLine($"\n ****Пропуск хода**** \n");
            }
            else
            {
                if ((k + this.Health) >= this.MaxHealth) // ограничение починки по максимальному здоровью
                {
                    this.Health = this.MaxHealth;
                    Console.WriteLine($"\nУспешная починка!");
                    Console.WriteLine($"\n ****Отремонтировано на {k} пунктов здоровья****");
                    Console.WriteLine($"\nПроизведен ремонт: {this.Name} (Здоровье: {this.Health})");
                }
                else
                {
                    this.Health = this.Health + k;
                    Console.WriteLine($"\nУспешная починка!");
                    Console.WriteLine($"\n ****Отремонтировано на {k} пунктов здоровья****");
                    Console.WriteLine($"\nПроизведен ремонт: {this.Name} (Здоровье: {this.Health})");
                }
            }
            Thread.Sleep(1000);
        }
        public void TTHinfo() // метод получения информации
        {
            Console.WriteLine($"|{this.Name}|,Броня:{Armor}/{MaxArmor}, Здоровье:{Health}/{MaxHealth}, Урон пушки:{this.Damage}, Количество снарядов: {this.Bullets}/{this.MaxBullets}");
        }
        public void Reload() // метод покупки снарядов
        {
            Random rnd = new Random();
            if (this.Bullets >= MaxBullets) // проверка попытки приобрести снарядов больше чем возможно иметь
            {
                Console.WriteLine("\nУ Вас максимальное число снарядов, невозможно купить снаряды!");
                Console.WriteLine("\n ****Пропуск хода****\n");
            }
            else
            {
                int k = rnd.Next(1, 11);
                if (k > 9) // 10% шанс полностью восстановить боезапас
                {
                    this.Bullets = this.MaxBullets;
                    Console.WriteLine($"\nКритический успех при покупке снарядов!\n\n ****Весь боезапас {this.Name} восстановлен!****\n");
                    Thread.Sleep(1000);
                    return;
                }
                else if (k >= 7 && k < 10) // 30% шанс восстановить 2 снаряда
                {
                    this.Bullets = this.Bullets + 2;
                    if (this.Bullets >= MaxBullets)
                        this.Bullets = this.MaxBullets;
                    Console.WriteLine($"\nКритический успех при покупке снарядов!\n\n ****Часть боезапаса {this.Name} восстановлена!****\n");
                    Thread.Sleep(1000);
                    return;
                }
                else // покупка 1 снаряда
                {
                    this.Bullets++;
                    Console.WriteLine($"\nПокупка снарядов\n\n ****Часть боезапаса {this.Name} восстановлена!****\n");
                }
            }
            Thread.Sleep(1000);
        }
    }
}

