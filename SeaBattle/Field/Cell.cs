using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle
{
    public class Cell
    {
        public CellType Type { get; set; }
        public Cell()
        {
            Type = CellType.Emptiness;
        }
    }
}
