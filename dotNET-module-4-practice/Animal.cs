using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNET_module_4_practice
{
    public abstract class Animal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        public Animal(int id, string name, string type)
        {
            Id = id;
            Name = name;
            Type = type;
        }

        public abstract double CalculateFoodAmount();
    }

    public class Carnivore : Animal
    {
        public Carnivore(int id, string name) : base(id, name, "Хищник") { }

        public override double CalculateFoodAmount()
        {
            // Расчет количества пищи для хищника
            return 2.0;
        }
    }

    public class Omnivore : Animal
    {
        public Omnivore(int id, string name) : base(id, name, "Всеядное") { }

        public override double CalculateFoodAmount()
        {
            // Расчет количества пищи для всеядного
            return 1.5;
        }
    }

    public class Herbivore : Animal
    {
        public Herbivore(int id, string name) : base(id, name, "Травоядное") { }

        public override double CalculateFoodAmount()
        {
            // Расчет количества пищи для травоядного
            return 1.0;
        }
    }

}
