using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _2DGame
{
    public partial class Form1 : Form
    {
        enum Position
        {
            Left, Right, Up, Down, DiaDownLeft, DiaDownRight, DiaUpLeft, DiaUpRight
        }

        private int step = 10;
        private int xPos = 0;
        private int yPos = 0;
        private Position _ObjectPosition;

        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 1;
            timer1.Start();
            
            int xScreen = this.Height;
            int yScreen = this.Width;

            int xCenter = xScreen / 2;
            int yCenter = yScreen / 2;
            _ObjectPosition = Position.DiaDownRight;
        }

        public void Form1_Paint(object sender, PaintEventArgs e)
        {
            int xMove = 10;
            int yMove = 10;

            Graphics g = e.Graphics;
            Pen p = new Pen(Color.Green, 5);

            //g.DrawRectangle(p, xPos, yPos, 100, 100);
            g.FillRectangle(Brushes.Purple, xPos, yPos, 100, 100);

            g.Dispose();
        }

        public void timer1_Tick(object sender, EventArgs e)
        {
            int xScreen = this.Height;
            int yScreen = this.Width;

            /*if (xPos >= this.Width - 100) { _ObjectPosition = Position.Left; }
            else if (xPos <= 0) { _ObjectPosition = Position.Right; }

            if (yPos >= this.Height - 100) { _ObjectPosition = Position.Up; }
            else if (yPos <= 0) { _ObjectPosition = Position.Down; }*/

            if (_ObjectPosition == Position.DiaDownRight && xPos >= (xScreen - 100) ||
                _ObjectPosition == Position.DiaDownRight && yPos >= (yScreen - 100))
            {
                _ObjectPosition = Position.DiaUpLeft;
            }
            if (_ObjectPosition == Position.DiaUpLeft && xPos <= 0 ||
                _ObjectPosition == Position.DiaUpLeft && yPos <= 0)
            {
                _ObjectPosition = Position.DiaDownRight;
            }

            if (_ObjectPosition == Position.Right)
            {
                xPos += step;
            }
            else if (_ObjectPosition == Position.Left)
            {
                xPos -= step;
            }
            else if (_ObjectPosition == Position.Up)
            {
                yPos -= step;
            }
            else if (_ObjectPosition == Position.Down)
            {
                yPos += step;
            }
            else if (_ObjectPosition == Position.DiaDownRight)
            {
                xPos += step;
                yPos += step;
            }
            else if (_ObjectPosition == Position.DiaUpLeft)
            {
                xPos -= step;
                yPos -= step;
            }

            Invalidate();
        }
    }
}
