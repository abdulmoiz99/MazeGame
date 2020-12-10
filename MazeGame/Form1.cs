using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MazeGame
{
    public partial class Form1 : Form
    {
        int x = 30, y = 20;
        char[,] arr; 
        int PosX = 0, PosY = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            RectangleF bounds = e.Graphics.VisibleClipBounds;
            // um die Groesse des sichtbaren Bereichs zu ermitteln
           DrawMap(e.Graphics);
        }
        public  void DrawMap(Graphics g)
        {
            arr = new char[x, y];
            var lines = File.ReadAllLines(Application.StartupPath + "\\Map.txt");

            for (int i = 0; i < lines.Length; i++)
            {
                string zeile = lines[i];
                for (int j = 0; j < zeile.Length; j++)
                {
                    arr[j, i] = zeile[j];
                }
            }
            arr[0, 4] = '@';
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    if (arr[i, j] == '#')
                    {
                        g.DrawString("■", new Font("Arial", 20), Brushes.DodgerBlue, new PointF(0 + (i * 30), 0 + (j * 35)));
                    }

                    else if (arr[i, j] == '.')
                    {
                        g.DrawString(" ", new Font("Arial", 20), Brushes.Blue, new PointF(0 + (i * 30), 0 + (j * 35)));
                    }

                    else if (arr[i, j] == '@')
                    {
                        g.DrawString("@", new Font("Arial", 20), Brushes.Red, new PointF(0 + (i * 30), 0 + (j * 35)));
                        PosX = i; PosY = j;

                    }
                }
            }
        }
        override protected void OnKeyDown(KeyEventArgs e)
        {
            Pen p = new Pen(this.BackColor);
            //try
            //{

            Graphics g = CreateGraphics();//= new Graphics()
            switch (e.KeyCode)
            {
                case Keys.Up:
                    PosY--;
                    if (arr[PosX, PosY] != '#')
                    {
                        g.Clear(this.BackColor);
                        ReDrawMap();
                        if (arr[PosX, PosY] == '.') arr[PosX, PosY] = ' ';
                        g.DrawString("@", new Font("Arial", 20), Brushes.Red, new PointF(0 + (PosX * 30), 0 + (PosY * 35)));

                    }
                    else PosY++;
                    break;

                case Keys.Down:
                    PosY++;
                    if (arr[PosX, PosY] != '#')
                    {
                        g.Clear(this.BackColor);
                        ReDrawMap();
                        if (arr[PosX, PosY] == '.') arr[PosX, PosY] = ' ';
                        g.DrawString("@", new Font("Arial", 20), Brushes.Red, new PointF(0 + (PosX * 30), 0 + (PosY * 35)));

                    }
                    else PosY--;

                    break;

                case Keys.Left:
                    if (PosX > 0)
                    {
                        PosX--;
                        if (arr[PosX, PosY] != '#')
                        {
                            g.Clear(this.BackColor);
                            ReDrawMap();

                            if (arr[PosX, PosY] == '.') arr[PosX, PosY] = ' ';
                            g.DrawString("@", new Font("Arial", 20), Brushes.Red, new PointF(0 + (PosX * 30), 0 + (PosY * 35)));
                        }
                        else PosX++;
                    }
                    break;

                case Keys.Right:
                    PosX++;
                    if (arr[PosX, PosY] != '#')
                    {

                        g.Clear(this.BackColor);
                        ReDrawMap();
                        if (arr[PosX, PosY] == '.') arr[PosX, PosY] = ' ';
                        g.DrawString("@", new Font("Arial", 20), Brushes.Red, new PointF(0 + (PosX * 30), 0 + (PosY * 35)));
                    }
                    else PosX--;
                    break;
            }

            //  }
            //catch (Exception ex)
            //{

            //    MessageBox.Show(ex.Message);
            //}

        }
        /// <summary>
        /// Refresh the Map 
        /// </summary>
        public void ReDrawMap()
        {
            Graphics g = CreateGraphics();
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    if (arr[i, j] == '#')
                    {
                        // 0 + (i * 30), 0 + (j * 35))
                        g.DrawString("■", new Font("Arial", 20), Brushes.DodgerBlue, new PointF(0 + (i * 30), 0 + (j * 35)));
                    }

                    else if (arr[i, j] == '.')
                    {
                        g.DrawString(" ", new Font("Arial", 20), Brushes.Blue, new PointF(0 + (i * 30), 0 + (j * 35)));
                    }


                }
            }
        }
    }
}
