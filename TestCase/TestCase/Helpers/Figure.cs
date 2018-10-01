using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace TestCase.Helpers
{
    public abstract class _Figure
    {
        /// <summary>
        /// нач позиция
        /// </summary>
        public Point loc { get; set; }
        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Метод для подготовики к рисованию объекта
        /// </summary>
        /// <returns>Готовый объект для рисования</returns>
        public abstract Shape Drawing();
    }

    public class _Circle : _Figure
    {
        /// <summary>
        /// Радиус круга
        /// </summary>
        public int r { get; set; }
        public override Shape Drawing()
        {
            Ellipse circl = new Ellipse();
            circl.Height = circl.Width = r * 2;
            SolidColorBrush scb = new SolidColorBrush();
            scb.Color = Color.FromRgb(100, 255, 100);
            circl.Fill = scb;
            circl.Margin = new Thickness(loc.X, loc.Y, 0 ,0);
            return circl;
        }
    }
    public class _Ellipse : _Circle
    {
        /// <summary>
        /// Радиус елипса по ОХ
        /// </summary>
        public int r2 { get; set; }
        public override Shape Drawing()
        {
            Ellipse ellips = new Ellipse();
            ellips.Height = r * 2;
            ellips.Width = r2 * 2; ;
            SolidColorBrush scb = new SolidColorBrush();
            scb.Color = Color.FromRgb(200, 200, 100);
            ellips.Fill = scb;
            ellips.Margin = new Thickness(loc.X, loc.Y, 0, 0);
            return ellips;
        }
    }
    public class _Square : _Figure
    {
        /// <summary>
        /// Высота
        /// </summary>
        public int a { get; set; }

        public override Shape Drawing()
        {
            Rectangle square = new Rectangle() { Height = a, Width = a };
            SolidColorBrush scb = new SolidColorBrush();
            scb.Color = Color.FromRgb(200, 200, 200);
            square.Fill = scb;
            square.Margin = new Thickness(loc.X, loc.Y, 0, 0);
            return square;
        }
    }

    public class _Rectangle : _Square
    {
        /// <summary>
        /// Ширина 
        //// </summary>
        public int b { get; set; }

        public override Shape Drawing()
        {
            Rectangle rectangle = new Rectangle() { Height = a, Width = b };
            SolidColorBrush scb = new SolidColorBrush();
            scb.Color = Color.FromRgb(200, 0, 200);
            rectangle.Fill = scb;
            rectangle.Margin = new Thickness(loc.X, loc.Y, 0, 0);
            return rectangle;
        }
    }

    public class _Triangl : _Figure
    {
        /// <summary>
        /// AB 
        //// </summary>
        public int a { get; set; }
        /// <summary>
        /// BC
        //// </summary>
        public int b { get; set; }
        /// <summary>
        /// CA 
        //// </summary>
        public int c { get; set; }


        public override Shape Drawing()
        {
            Polygon triangl = new Polygon();
            triangl.Points = getPoints();
            SolidColorBrush scb = new SolidColorBrush();
            scb.Color = Color.FromRgb(0, 200, 200);
            triangl.Fill = scb;
            return triangl;
        }
        private PointCollection getPoints()
        {
            double A = 0, B = 0, C = 0;
            if (b > a & b > c)
            {
                A = a;
                B = b;
                C = c;
            }
            else
            {
                if (a > b)
                {
                    B = a;
                    A = B;
                    C = c;
                }
                if (c > b)
                {
                    B = c;
                    C = b;
                    A = a;
                }
            }
            PointCollection pc = new PointCollection();
            double ac = A / C;
            double p = (A + B + C) / 2;
            double h = 2 * Math.Sqrt(p * (p - A) * (p - B) * (p - C)) / b;
            var x = Math.Sqrt(C * C - h * h);
            pc.Add(loc);
            pc.Add(new Point(loc.X, loc.Y + b));
            pc.Add(new Point(loc.X + h, loc.Y + b - x));
            pc.Add(loc);
            return pc;
        }


    }
}
