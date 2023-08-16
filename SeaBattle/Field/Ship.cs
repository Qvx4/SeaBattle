using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle
{
    public class Ship
    {
        public List<Point> Point { get; set; }
         
        public Ship()
        {
            Point = new List<Point>();
        }
    }
}
