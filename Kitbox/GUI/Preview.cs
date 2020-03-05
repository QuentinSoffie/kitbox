using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kitbox.GUI
{
    public partial class Preview : Form
    {
       
    
        private readonly List<int> EdgeFirstFloor = new List<int>() { 116,103,110, 123 };
        private readonly List<List<Point>> Rectangles = new List<List<Point>>();
        private readonly int HeightMap = 12;
        private readonly int WidthMap = 7;
        private  Graphics PreviewBox;

        public Preview(string colorPanel, string colorDoor,string height, string width,string depth)
        {
            InitializeComponent();
            InitializePicture(colorPanel,colorDoor,height,width,depth);
        }
       
        
        public void InitializePicture(string colorPanel, string colorDoor, string height, string width, string depth)
        {
            int x = 0;
            int y = 0;
            Bitmap b = new Bitmap(550,550);
             PreviewBox = Graphics.FromImage(b);
            int cellNumber = 0;
            for (int j = 0; j <= ((HeightMap * 2) - 1); j++)
            {
                for (int i = 0; i <= (WidthMap - 1); i++)
                {
                    if (j % 2 != 0)
                    {
                        x = i * 64 + 64;
                            }
                    else
                    {
                        x = i * 64 + 32;
                    }
                    y = j * 18 + 18;
                    cellNumber += 1;
                    Color couleur = ColorTranslator.FromHtml("#ffffff");

                    Point centre = new Point(x, y);
                   
                    var brush = new SolidBrush(couleur);
                     Point[] points = new Point[4];
                      points[0] = new Point(centre.X, centre.Y - 18);
                    points[1] = new Point(centre.X + 32, centre.Y);
                     points[2] = new Point(centre.X, centre.Y + 18);
                    points[3] = new Point(centre.X - 32, centre.Y);
                    PreviewBox.FillPolygon(brush, points);
                    Pen Box = Pens.LightSlateGray;
                    
                    PreviewBox.DrawPolygon(Box, points);
                    if (cellNumber == EdgeFirstFloor[0] )
                    {
                        PreviewBox.DrawLine(Pens.Red, points[3], new Point(points[3].X,points[3].Y - 72));
                        DrawMeasures(new Point(points[3].X - 10, points[3].Y), new Point(points[3].X-10, points[3].Y -72),height);
                        Rectangles.Add(new List<Point>() { points[3] });

                    }
                    else if(cellNumber == EdgeFirstFloor[1])
                    {
                        PreviewBox.DrawLine(Pens.Red, points[0], new Point(points[0].X, points[0].Y - 72));
                        Rectangles.Add(new List<Point>() { points[0] });
                    }
                    else if (cellNumber == EdgeFirstFloor[2])
                    {
                        PreviewBox.DrawLine(Pens.Green, points[1], new Point(points[1].X, points[1].Y - 72));
                        Rectangles.Add(new List<Point>() { points[1] });
                    }
                    else if (cellNumber == EdgeFirstFloor[3])
                    {
                        PreviewBox.DrawLine(Pens.Green, points[2], new Point(points[2].X, points[2].Y - 72));
                        Rectangles.Add(new List<Point>() { points[2] });
                    }


                }
            }
        
            DrawRectangle(0);
            DrawMeasureDepth(depth,width);
            DrawLegend(colorDoor,colorPanel);
            pictureBox1.Image = (Image)b.Clone();
        }

        private void DrawMeasures(Point point1, Point point2,string height)
        {
            //Height
            PreviewBox.DrawLine(Pens.Black, point1, point2);
            PreviewBox.DrawLine(Pens.Black, point1, new Point(point1.X + 5, point1.Y));
            PreviewBox.DrawLine(Pens.Black, point2, new Point(point2.X + 5, point2.Y));
            PreviewBox.DrawString(height + " cm", new Font("Tahoma", 8), Brushes.Black, point1.X - 40,point2.Y + 25);
           
        }
        private void DrawMeasureDepth(string depth,string width)
        {
            //Depth
            PreviewBox.DrawLine(Pens.Black,182 + 5,306,182,306 + (float)2.81);
            PreviewBox.DrawLine(Pens.Black, 251, 344, 251 - (float)3, 344 + (float)1.6875);
            PreviewBox.DrawLine(Pens.Black, 182, 306 + (float)2.81, 251 - (float)3, 344 + (float)1.6875);
            PreviewBox.DrawString(depth + " cm", new Font("Tahoma", 8), Brushes.Black, 180, 330);

            //Width
            PreviewBox.DrawLine(Pens.Black, 256 + 5, 342 +2, 256 + 10, 342 + 5);
            PreviewBox.DrawLine(Pens.Black, 352 + 5, 288 + 2, 352 + 10, 288 + 5);
            PreviewBox.DrawLine(Pens.Black, 256 + 10, 342 + 5, 352 + 10, 288 + 5);
            PreviewBox.DrawString(width + " cm", new Font("Tahoma", 8), Brushes.Black, 320, 325);
        }

        private void DrawLegend(string colorDoor,string colorPanel)
        {
            //Door
            PreviewBox.DrawLine(Pens.Green, 300, 280 ,300,380);
            PreviewBox.FillEllipse(new SolidBrush(Color.Green), 295, 275, 10, 10);
            PreviewBox.DrawString("Color door : " + colorDoor, new Font("Tahoma", 10), Brushes.Green, 250, 390);

            //Panel
            //g.FillEllipse(new SolidBrush(Color.Green), 218, 283, 10, 10);
            //g.FillEllipse(new SolidBrush(Color.Green), 233, 237, 10, 10);
            //g.FillEllipse(new SolidBrush(Color.Green), 268, 290, 10, 10);
            //g.FillEllipse(new SolidBrush(Color.Green), 316, 228, 10, 10);

              PreviewBox.FillEllipse(new SolidBrush(Color.Red), 92, 193, 10, 10);
            PreviewBox.DrawString("Color panel : " + colorPanel, new Font("Tahoma", 10), Brushes.Red, 105, 190);
            //Pen Datted = new Pen(Color.Green, 1);
            //Datted.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            //g.DrawLine(Datted, 320,233, 160, 197);
            //g.DrawLine(Datted, 237, 243, 160, 197);
            //g.DrawLine(Datted, 222, 288, 160, 197);

        }

      
        private void DrawRectangle(int floor)
        {
            PreviewBox.DrawLine(Pens.Red, Rectangles[floor][0], Rectangles[floor+1][0]);
            PreviewBox.DrawLine(Pens.Green, Rectangles[floor+1][0], Rectangles[floor +3][0]);
            PreviewBox.DrawLine(Pens.Red, Rectangles[floor +2][0], Rectangles[floor][0]);
            PreviewBox.DrawLine(Pens.Red, Rectangles[floor + 3][0], Rectangles[floor +2][0]);

            PreviewBox.DrawLine(Pens.Red, Rectangles[floor][0].X, Rectangles[floor][0].Y -72, Rectangles[floor + 1][0].X, Rectangles[floor + 1][0].Y -72);
            PreviewBox.DrawLine(Pens.Green, Rectangles[floor + 1][0].X, Rectangles[floor+1][0].Y - 72, Rectangles[floor + 3][0].X, Rectangles[floor + 3][0].Y - 72);
            PreviewBox.DrawLine(Pens.Red, Rectangles[floor + 2][0].X, Rectangles[floor+2][0].Y - 72, Rectangles[floor][0].X, Rectangles[floor ][0].Y - 72);
            PreviewBox.DrawLine(Pens.Red, Rectangles[floor + 3][0].X, Rectangles[floor+3][0].Y - 72, Rectangles[floor + 2][0].X, Rectangles[floor + 2][0].Y - 72);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
