using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
     class AI:IAi // класс компьютер 
    {
        public void AI_motion (IObj Enemy, IObj Player) // метод ход компьютера
        {
            Random rand = new Random();
            Console.WriteLine(" ****Ход противника****");
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
    }
}
