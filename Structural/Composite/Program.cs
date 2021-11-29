using System;
using System.Collections.Generic;

namespace Composite
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var group1 = new Group();
            group1.Add(new Shape());
            group1.Add(new Shape());
            group1.Render();

            var group2 = new Group();

        }
    }


    public class Shape : Component
    {
        public void Render()
        {
            Console.WriteLine("Render Shape");
        }
    }

    public class Group : Component
    {
        private List<Component> components = new List<Component>();

        public void Add(Component shape)
        {
            components.Add(shape);
        }

        public void Render()
        {
            foreach (var component in components)
            {
                component.Render();
            }
        }
    }

    public interface Component
    {
        void Render();
    }

}