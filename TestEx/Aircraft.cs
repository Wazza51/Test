using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Aircraft : IObj, IAi // отдельный класс объекта (самолёт) наследующий интерфейсы объекта и компьютера
    {
        public int Armor { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }
        public int MaxHealth { get; set; }
        public string Name { get; set; }
        public int MaxArmor { get; set; }
        public int Bullets { get; set; }
        public int MaxBullets { get; set; }
        public void AI_motion(IObj Enemy, IObj Player)
        {
            Random rand = new Random();
            Console.WriteLine(" ****Ход противника самолёт****");
            if (Enemy.Health == Enemy.MaxHealth)
            {
                Enemy.Shot(Player);
            }
            else if (Enemy.Health >= Convert.ToDouble(Enemy.MaxHealth) * 0.75)
            {
                int k = rand.Next(1, 6);
                if (k <= 4)
                    Enemy.Shot(Player);
                else Enemy.Repair();
            }
            else if (Enemy.Health >= Convert.ToDouble(Enemy.MaxHealth) * 0.55 && Enemy.Health < Convert.ToDouble(Enemy.MaxHealth) * 0.75)
            {
                int k = rand.Next(1, 5);
                if (k <= 2)
                    Enemy.Shot(Player);
                else Enemy.Repair();
            }
            else if (Enemy.Health > 0 && Enemy.Health < Convert.ToDouble(Enemy.MaxHealth) * 0.55)
            {
                int k = rand.Next(1, 5);
                if (k <= 3)
                    Enemy.Repair();
                else Enemy.Shot(Player);
            }
        }
        public Aircraft (int Armor, int Health, int Damage, string Name, int Bullets)
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
        public void Reload()
        {
            Random rnd = new Random();
            if (this.Bullets >= MaxBullets)
            {
                Console.WriteLine("\nУ Вас максимальное число снарядов, невозможно купить снаряды!");
                Console.WriteLine("\n ****Пропуск хода****\n");
            }
            else
            {
                int k = rnd.Next(1, 11);
                if (k > 9)
                {
                    this.Bullets = this.MaxBullets;
                    Console.WriteLine($"\nКритический успех при покупке снарядов!\n\n ****Весь боезапас {this.Name} восстановлен!****\n");
                    Thread.Sleep(2000);
                    return;
                }
                else if (k >= 7 && k < 10)
                {
                    this.Bullets = this.Bullets + 2;
                    if (this.Bullets >= MaxBullets)
                        this.Bullets = this.MaxBullets;
                    Console.WriteLine($"\nКритический успех при покупке снарядов!\n\n ****Часть боезапаса {this.Name} восстановлена!****\n");
                    Thread.Sleep(2000);
                    return;
                }
                else
                {
                    this.Bullets++;
                    Console.WriteLine($"\nПокупка снарядов\n\n ****Часть боезапаса {this.Name} восстановлена!****\n");
                }
            }
            Thread.Sleep(2000);
        }
        public void Repair()
        {
            Random rnd = new Random();
            int k = rnd.Next(Convert.ToInt32(Convert.ToDouble(this.MaxHealth) * 0.05), Convert.ToInt32(Convert.ToDouble(this.MaxHealth) * 0.20) + 1);
            if (this.Health == this.MaxHealth)
            {
                Console.WriteLine($"\nУ Вас полное здоровье!, Вы пропускаете ход...");
                Console.WriteLine($"\n ****Пропуск хода**** \n");
            }
            else
            {
                if ((k + this.Health) >= this.MaxHealth)
                {
                    this.Health = this.MaxHealth;
                    Console.WriteLine($"\nУспешная починка!");
                    Console.WriteLine($"\n ****Отремонтировано на {k} пунктов здоровья****");
                    Console.WriteLine($"\nПроизведен ремонт: {this.Name} (Здоровье: {this.Health})\n");
                }
                else
                {
                    this.Health = this.Health + k;
                    Console.WriteLine($"\nУспешная починка!");
                    Console.WriteLine($"\n ****Отремонтировано на {k} пунктов здоровья****");
                    Console.WriteLine($"\nПроизведен ремонт: {this.Name} (Здоровье: {this.Health})\n");
                }
            }
            Thread.Sleep(1000);
        }
        public void SetDif(string i, IObj Enemy)
        {
            if (Convert.ToInt32(i) == 1)
            {
                Console.Clear();
                Console.WriteLine($"Выбран легкий уровень сложности!");
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
                Console.WriteLine($"Выбран средний уровень сложности!");
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
                Console.WriteLine($"Выбран тяжелый уровень сложности!");
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
        public void Shot(IObj _object)
        {
            Random rnd = new Random();
            int k = rnd.Next(1, 11);
            double Critdmg = 0;
            if (this.Bullets > 0)
            {
                if (k > 9)
                {
                    Critdmg = Convert.ToDouble(this.Damage) * 0.2;
                    Console.WriteLine("\n ****Критический попадание****");
                }
                if (k <= 2)
                {
                    Console.WriteLine($"\n{this.Name} не попал\n");
                    Console.WriteLine(" ****Промах****\n");
                    this.Bullets--;
                    Thread.Sleep(2000);
                    return;
                }
                Console.WriteLine($"\nВыпускает ракеты: {this.Name}, По цели: {_object.Name} (Броня: {_object.Armor}, Здоровье: {_object.Health})\n ****Наносится урон: {this.Damage + Convert.ToInt32(Critdmg)}****");
                if (_object.Armor >= this.Damage + Convert.ToInt32(Critdmg))
                {
                    _object.Armor = _object.Armor - this.Damage - Convert.ToInt32(Critdmg);
                    this.Bullets--;
                }
                else
                {
                    _object.Health = _object.Health + (_object.Armor - this.Damage - Convert.ToInt32(Critdmg));
                    _object.Armor = 0;
                    this.Bullets--;
                }
                if (_object.Health <= 0)
                    Console.WriteLine($"\n{_object.Name} уничтожен");
                else
                    Console.WriteLine($"Есть попадание ракет по цели: {_object.Name} (Броня: {_object.Armor}, Здоровье: {_object.Health}) \n");
            }
            else if (this.Bullets <= 0 && this.Name == "Игрок самолёт")
            {
                Console.WriteLine("\nУ Вас нет ракет, необходимо приобрести ракеты!");
                Console.WriteLine("\n ****Пропуск хода****\n");
            }
            else if (this.Bullets <= 0 && this.Name == "Соперник самолёт")
            {
                this.Reload();
            }
            Thread.Sleep(2000);
            Critdmg = 0;
        }
        public void TTHinfo()
        {
            Console.WriteLine($"|{this.Name}|,Броня:{Armor}/{MaxArmor}, Здоровье:{Health}/{MaxHealth}, Урон ракеты:{this.Damage}, Количество ракет: {this.Bullets}/{this.MaxBullets}");
        }
    }
}
