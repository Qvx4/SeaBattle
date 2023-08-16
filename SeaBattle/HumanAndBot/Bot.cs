using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle
{
    public class Bot
    {
        public Field MyField { get; set; }
        public Field EnemyField { get; set; }
        public string Name { get; set; }
        public List<Point> NeedShoot { get; set; }
        public List<Point> WereShotDead { get; set; }

        public Bot()
        {
            MyField = new Field();
            EnemyField = new Field();
            Name = "Bot_1";
            NeedShoot = new List<Point>();
            WereShotDead = new List<Point>();
        }
        public Point BotShooting()
        {

            Random rnd = new Random();
            int numberX = rnd.Next(1, 11), numberY = rnd.Next(1, 11);
            while
            (
                EnemyField.GameField[numberX][numberY].Type == CellType.Miss ||
                EnemyField.GameField[numberX][numberY].Type == CellType.Padded ||
                EnemyField.GameField[numberX][numberY].Type == CellType.Destroyed)
            {
                numberX = rnd.Next(1, 11);
                numberY = rnd.Next(1, 11);
            }
            Point point = new Point(numberX,numberY);
            return point;
        }
        public void ShowField()
        {
            MyField.ShowField();
        }
    }
}
