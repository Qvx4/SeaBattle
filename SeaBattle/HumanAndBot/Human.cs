using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle
{
    public abstract class Human
    {
        public string Name { get; }
        public string Surname { get; }
        public int Age { get; }
        public Human()
        {

        }
        public Human(string name, string surname, int age)
        {
            Name = name;
            Surname = surname;
            Age = age;
        }
    }
}
