using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsole
{
    public abstract class Animal:AnimalSay
    {
        public string Name { get; set; }

        public abstract void Say();
    }

    public interface AnimalSay {
        void Say();
    }

    public class Cat : Animal
    {
        public override void Say()
        {
            Console.WriteLine($"{Name}:喵喵喵");
        }
    }

    public class Dog : Animal
    {
        public override void Say()
        {
            Console.WriteLine($"{Name}:汪汪汪");
        }
    }
}
