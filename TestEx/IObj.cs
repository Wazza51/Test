using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    interface IObj // интерфейс класса объекта
    {
        int Armor { get; set; }
        int Health { get; set; }
        int Damage { get; set; }
        int MaxHealth { get; set; }
        string Name { get; set; }
        int MaxArmor { get; set; }
        int Bullets { get; set; }
        int MaxBullets { get; set; } // объявление свойств
        void Shot(IObj _object);
        void SetDif(string i, IObj Enemy);
        void Repair();
        void TTHinfo();
        void Reload(); // объявление методов
    }
}
