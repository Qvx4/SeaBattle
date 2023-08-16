using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle
{
    public enum CellType
    {
        Emptiness = 1,
        Border,
        Miss,
        PartOfTheShip,
        Padded,
        Destroyed
    }
}
