using System;
using System.Drawing;
using System.Windows.Forms;

namespace Running_button
{
    public partial class Form1 : Form
    {
        private int _ticks;
        private int _buttonSpeed;
        private int _buttonSrinkage;
        private int _srinkageCoeficient;
        private CursorPositions Position { get; set; }
        public Form1()
        {
            InitializeComponent();

            _ticks = 0;
            _buttonSpeed = 2;
            _srinkageCoeficient = 15;
            _buttonSrinkage = buttonOK.Width * _srinkageCoeficient;

            MouseMove += MyEvent;
        }

        private void MyEvent(object sender, MouseEventArgs e)
        {
            if (DeterminateDistance(e.Location) < buttonOK.Width / 2 + 50)
            {
                Point newPosition = new Point(buttonOK.Location.X, buttonOK.Location.Y);
                switch (Position)
                {
                    case CursorPositions.IsOnTop:
                        newPosition.Y += _buttonSpeed;
                        break;
                    case CursorPositions.IsOnTopRight:
                        newPosition.Y += _buttonSpeed;
                        newPosition.X -= _buttonSpeed;
                        break;
                    case CursorPositions.IsOnRight:
                        newPosition.X -= _buttonSpeed;
                        break;
                    case CursorPositions.IsOnBottomRight:
                        newPosition.Y -= _buttonSpeed;
                        newPosition.X -= _buttonSpeed;
                        break;
                    case CursorPositions.IsOnBottom:
                        newPosition.Y -= _buttonSpeed;
                        break;
                    case CursorPositions.IsOnBottomLeft:
                        newPosition.Y -= _buttonSpeed;
                        newPosition.X += _buttonSpeed;
                        break;
                    case CursorPositions.IsOnLeft:
                        newPosition.X += _buttonSpeed;
                        break;
                    case CursorPositions.IsOnTopLeft:
                        newPosition.Y += _buttonSpeed;
                        newPosition.X += _buttonSpeed;
                        break;
                    default:
                        break;
                }
                buttonOK.Location = CheckColision(newPosition);

                _buttonSrinkage--;

                if (_buttonSrinkage < _srinkageCoeficient)
                {
                    MessageBox.Show("Кнопка ОК не може бути натиснена");
                    MouseMove -= MyEvent;
                }

                buttonOK.Width = _buttonSrinkage / _srinkageCoeficient;
                buttonOK.Height = _buttonSrinkage / _srinkageCoeficient;
            }
        }
        private double DeterminateDistance(Point point)
        {
            if (point.X > buttonOK.Location.X && point.X <= buttonOK.Location.X + buttonOK.Width
                && point.Y <= buttonOK.Location.Y)
                Position = CursorPositions.IsOnTop;
            else if (point.X >= buttonOK.Location.X && point.X < buttonOK.Location.X + buttonOK.Width
                && point.Y >= buttonOK.Location.Y + buttonOK.Height)
                Position = CursorPositions.IsOnBottom;
            else if (point.X <= buttonOK.Location.X
                && point.Y >= buttonOK.Location.Y && point.Y < buttonOK.Location.Y + buttonOK.Height)
                Position = CursorPositions.IsOnLeft;
            else if (point.X >= buttonOK.Location.X + buttonOK.Width
                && point.Y >= buttonOK.Location.Y && point.Y < buttonOK.Location.Y + buttonOK.Height)
                Position = CursorPositions.IsOnRight;
            else if (point.X > buttonOK.Location.X + buttonOK.Width && point.Y > buttonOK.Location.Y + buttonOK.Height)
                Position = CursorPositions.IsOnBottomRight;
            else if (point.X >= buttonOK.Location.X + buttonOK.Width &&
                point.Y < buttonOK.Location.Y)
                Position = CursorPositions.IsOnTopRight;
            else if (point.X < buttonOK.Location.X
                && point.Y > buttonOK.Location.Y + buttonOK.Height)
                Position = CursorPositions.IsOnBottomLeft;
            else
                Position = CursorPositions.IsOnTopLeft;

            return GetVector(point);
        }

        private double GetVector(Point point)
        {
            return Math.Sqrt(
                Math.Pow(point.X - buttonOK.Location.X - buttonOK.Width / 2, 2)
                + Math.Pow(point.Y - buttonOK.Location.Y - buttonOK.Height / 2, 2)
                );
        }
        private Point CheckColision(Point position)
        {
            if ((position.X > 0 && position.X + buttonOK.Width < this.Width)
                && position.Y < 1)
                return new Point(position.X, this.Height - buttonOK.Height - 50);
            else if ((position.X > 0 && position.X + buttonOK.Width < this.Width)
                && position.Y + buttonOK.Height == this.Height)
                return new Point(position.X, 10);
            else if (position.X < 0
                && (position.Y > 0 && position.Y + buttonOK.Height < this.Height))
                return new Point(this.Width - buttonOK.Width - 30, position.Y);
            else if (position.X + buttonOK.Width > this.Width - 15
                && (position.Y > 0 && position.Y + buttonOK.Height < this.Height))
                return new Point(10, position.Y);
            return position;
        }
        private void buttonOK_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Кнопка ОК була натиснена!");
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_ticks < 8)
            {
                if (this.Text != "")
                    this.Text = "";
                else
                {
                    this.Text = "Натисніть кнопку ОК!!!";
                    _ticks++;
                }
            }
            else
                timer1.Stop();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
