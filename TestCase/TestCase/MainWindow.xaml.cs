using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TestCase.Helpers;

namespace TestCase
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int x = 0, y = 0;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            Shape shape = null;
            StackPanel sp = new StackPanel();
            Random rand = new Random();            
            var maxX = canvas.Height;
            var maxY = canvas.Width;
            if (triangl.IsChecked == true)
            {
                if (a.Text != "" & b.Text != "" & c.Text != "")
                {
                    _Triangl t = new _Triangl();
                    t.a = int.Parse(a.Text);
                    t.b = int.Parse(b.Text);
                    t.c = int.Parse(c.Text);
                    t.loc = new Point(x, y);
                    shape = t.Drawing();
                }
            }
            if (circle.IsChecked == true)
            {
                if (a.Text != "" )
                {
                    _Circle c = new _Circle();
                    c.r = int.Parse(a.Text);
                    c.loc = new Point(x, y);
                    shape = c.Drawing();
                }
            }
            if (ellipse.IsChecked == true)
            {
                if (a.Text != "" & b.Text != "")
                {
                    _Ellipse el = new _Ellipse();
                    el.r = int.Parse(a.Text);
                    el.r2 = int.Parse(b.Text);
                    el.loc = new Point(x, y);
                    shape = el.Drawing();
                }
            }
            if (square.IsChecked == true)
            {
                if (a.Text != "" )
                {
                    _Square s = new _Square();
                    s.a = int.Parse(a.Text);
                    s.loc = new Point(x, y);
                    shape = s.Drawing();
                }
            }
            if (rectangle.IsChecked == true)
            {
                if (a.Text != "" & b.Text != "")
                {
                    _Rectangle r = new _Rectangle();
                    r.a = int.Parse(a.Text);
                    r.b = int.Parse(b.Text);
                    r.loc = new Point(x, y);
                    shape = r.Drawing();
                    
                }
            }
            if (shape != null)
            {
                
                canvas.Children.Add((UIElement)shape);
                x += 10;
                if (x >= maxX)
                {
                    x = 0;
                    y += 50;
                }
                if (y >= maxY)
                    y = 0;
                    
            }


        }

        private void rb_Click(object sender, RoutedEventArgs e)
        {
            if (triangl.IsChecked == true)
            {
                one.IsEnabled = two.IsEnabled = three.IsEnabled = true;
                a.Text = b.Text = c.Text = "";
            }
            if (circle.IsChecked == true)
            {
                one.IsEnabled = true;
                two.IsEnabled = three.IsEnabled = false;
                a.Text = b.Text = c.Text = "";
            }
            if (ellipse.IsChecked == true || square.IsChecked == true || rectangle.IsChecked == true)
            {

                one.IsEnabled = two.IsEnabled = true;
                three.IsEnabled = false;
                a.Text = b.Text = c.Text = "";
            }
        }
    }
}
