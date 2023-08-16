using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle
{
    public class Player : Human
    {
        public Field MyField { get; set; }
        public Field EnemyField { get; set; }
        public string Login { get; set; }
        public Player()
        {
            MyField = new Field();
            EnemyField = new Field();
            Login = "Guest";
        }
        public Player(string name,string surname,int age) : base(name,surname,age)
        {
        }
        public void ShowField()
        {
            MyField.ShowField();
        }
        //Вывод вражеского поля 
        public void EnemyFild()
        {
            EnemyField.ShowField();
        }
    }
}
