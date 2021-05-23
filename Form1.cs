using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Geometric_shapes_3
{
    public partial class Form1 : Form
    {
        private Bitmap bm;
        private Graphics paper;
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           var graphics = Panel.CreateGraphics();
            graphics.Clear(Color.White);
        }

        private void Draw_Click(object sender, EventArgs e)
        {
            var graphics = Panel.CreateGraphics();
            Pen pen = new Pen(Color.Black, 5);
            string box = BoxText.Text;

            if (box == "Segment")
            {
                graphics.DrawLine(pen, 50, 50, 250, 150);
            }

            if (box == "Triangle")
            {
                Point First = new Point(40, 40);
                Point Second = new Point(200, 250);
                Point Third = new Point(40, 250);

                Point[] Polygon = {First, Second, Third};

                graphics.DrawPolygon(pen, Polygon);
            }

            if (box == "Rectangle")
            {
                graphics.DrawRectangle(pen, 100, 100, 100, 100);
            }

            if (box == "Circle")
            {
                graphics.DrawEllipse(pen, 100, 100, 100, 100);
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {

            if (Panel.Image != null)
            {  
                var SFD = new SaveFileDialog();
                SFD.Filter = "(*.BMP;)|*.BMP|(*.JPG)|*.JPG|(*.PNG)|*.PNG|All Files(*.*)|*.*";
                
                if (SFD.ShowDialog() == DialogResult.OK)
                {   
                    Panel.Image.Save(SFD.FileName);
                }

                else
                {
                    MessageBox.Show("Ошибка");
                }
            }
        }

        private void Load_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "Image Files(*.BMP;*.JPG;*.PNG)|*.BMP;*.JPG;*.PNG|All Files (*.*)|*.*";

            if(ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Panel.Image = new Bitmap(ofd.FileName);
                }
                catch
                {
                    MessageBox.Show("Невозможно отркрыть файл или фото");
                }
            }
        }
    }
}
