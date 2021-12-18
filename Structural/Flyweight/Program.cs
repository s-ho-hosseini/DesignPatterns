using System.Security.Cryptography.X509Certificates;
namespace Facade
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var service = new PointService(new PointIconFactory());
            foreach (var point in service.GetPoints())
                point.draw();
        }
    }

    public class Point
    {
        private int x;
        private int y;
        private PointIcon _icon;


        public Point(int _x, int _y, PointIcon icon)
        {
            x = _x;
            y = _y;
            _icon = icon;
        }

        public void draw()
        {
            Console.WriteLine($"{_icon.PointType} at ({x},{y})");
        }
    }

    public enum PointType
    {
        Hospital,
        Cafe,
        Restaurant
    }

    public class PointService
    {
        private PointIconFactory _iconFactory;

        public PointService(PointIconFactory iconFactory)
        {
            _iconFactory = iconFactory;
        }

        public List<Point> GetPoints()
        {
            List<Point> points = new List<Point>();
            var point = new Point(1, 2, _iconFactory.GetPointIcon(PointType.Cafe));
            points.Add(point);

            return points;

        }
    }

    public class PointIcon
    {
        private readonly PointType _type;
        private readonly byte[]? _icon;

        public PointIcon(PointType type, byte[]? icon)
        {
            _type = type;
            _icon = icon;
        }

        public PointType PointType
        {
            get
            {
                return _type;
            }
        }
    }

    public class PointIconFactory
    {
        private IDictionary<PointType, PointIcon> icons = new Dictionary<PointType, PointIcon>();

        public PointIcon GetPointIcon(PointType type)
        {
            if (!icons.Keys.Contains(type))
            {
                var icon = new PointIcon(type, null);
                icons.Add(type, icon);
            }

            return icons[type];
        }


    }


}