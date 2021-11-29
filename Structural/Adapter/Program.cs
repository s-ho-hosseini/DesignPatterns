using System;

namespace Adapter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var imageView = new ImageView(new Image());
            imageView.Apply(new CaramelFilter(new Caramel()));
            
        }
    }


    public class Image
    {

    }

    public interface Filter
    {
        void Apply(Image image);
    }

    public class VividFilter : Filter
    {
        public void Apply(Image image)
        {
            Console.WriteLine("Applying Vivid Filter");
        }
    }

    public class ImageView
    {
        private Image image;

        public ImageView(Image image)
        {
            this.image = image;
        }

        public void Apply(Filter filter)
        {
            filter.Apply(image);
        }
    }

    public class Caramel
    {
        public void Init()
        {

        }

        public void Render(Image image)
        {
            Console.WriteLine("Caramel Filter");
        }
    }

    public class CaramelFilter : Filter
    {
        private Caramel caramel;
        public CaramelFilter(Caramel caramel)
        {
            this.caramel = caramel;
        }
        public void Apply(Image image)
        {
            caramel.Init();
            caramel.Render(image);
        }
    }
}