using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    interface IAi // интерфейс класса компьютер
    {
        void AI_motion(IObj Enemy, IObj Player); //объявление метод ход компьютера
    }
}
