using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        const int multiplier = 50;
        public Form1()
        {
            InitializeComponent();
            Draw();
        }
        public void Draw()
        {
            GeneratePoints();//генерирует точки для видимого отрезка

            pictureBox1.Image = new Bitmap(1000, 1000);//создание новой поверхности
            Graphics g = Graphics.FromImage(pictureBox1.Image); //данные отрисовки поверхности
            Pen p = new Pen(Color.Black);
            g.DrawLines(p, Multiplier(Info.window));//отрисовка окна
            g.DrawLines(p, Multiplier(new Point[2] {Info.window[3], Info.window[0] }));//замыкание отрезка
            g.DrawLines(p, Multiplier(Info.line));//отрисовка видимого отрезка
            SolidBrush br = new SolidBrush(Color.White);
            g.FillRectangle(br, RecMultiplier(Multiplier(Info.window)));
            pictureBox1.Invalidate();//обновление поверхности
        }

        public Point[] Multiplier(Point[] points)//изменение размера
        {
            List<Point> newPoints = new List<Point>();
            
           foreach(Point p in points)
           {
                newPoints.Add(new Point(p.X * multiplier + Info.zero.X * multiplier, p.Y * multiplier + Info.zero.Y * multiplier));
           }
            return newPoints.ToArray();
        }
        public Rectangle RecMultiplier(Point[] points)//изменение размера
        {
            
            for(int i = 0; i < points.Length; i++)
            {
                if (i == 0 || i == 3)
                {
                    points[i] = new Point(points[i].X+1, points[i].Y+1);
                }
                else
                {
                    points[i] = new Point(points[i].X-1, points[i].Y+1);
                }
            }
            Info.size.Width = points[3].X - points[0].X-1;
            Info.size.Height = points[1].Y - points[0].Y-1;
            return new Rectangle(points[0],Info.size);
        }
        public void GeneratePoints()
        {
            if (Info.window[2].X == Info.window[0].X)
            {
                Info.visibleLine[0] = new Point(Info.window[0].X,Info.line[0].Y + ((Info.line[1].Y - Info.line[0].Y) * (Info.window[0].X - Info.line[0].X)) / (Info.line[1].X - Info.line[0].X));
                Info.visibleLine[1] = new Point(Info.window[2].X,Info.line[0].Y + ((Info.line[1].Y - Info.line[0].Y) * (Info.window[2].X - Info.line[0].X)) / (Info.line[1].X - Info.line[0].X));
            }
            else
            {
                Info.visibleLine[0] = new Point(Info.line[0].X + ((Info.line[1].X - Info.line[0].X) * (Info.window[0].Y - Info.line[0].Y)) /
                (Info.line[1].Y - Info.line[0].Y), Info.line[0].Y);

                Info.visibleLine[1] = new Point(Info.line[0].X + ((Info.line[0].X - Info.line[0].X) * (Info.window[2].Y - Info.line[0].Y)) /
                (Info.line[1].Y - Info.line[0].Y), Info.window[2].Y);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
    
}
