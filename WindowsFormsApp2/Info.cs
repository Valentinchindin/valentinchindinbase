using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    public static class Info
    {
        public static Point[] window = new Point[4] 
        {
            new Point(0, 0),
            new Point(0, 4),
            new Point(8, 4),
            new Point(8, 0)
        };

        public static Size size = new Size(window[2]);

        public static Rectangle rectangle = new Rectangle(window[0], size);

        public static Point[] line = new Point[2]
        {
            new Point(-50,-40),
            new Point(18,16)
        };

        public static Point[] visibleLine = new Point[100];//координаты видимого отрезка

        public static Point zero = new Point(3, 3);//координаты нуля
        
    }
}
