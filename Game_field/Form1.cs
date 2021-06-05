using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Game_logic;
using WindowsFormsApp1;

namespace Game_field
{
    public partial class Form1 : Form
    {
        GameController Controller;
        Panel Game_field;
        Player Current => Controller.Current_Player;
        private Color Player_One_color = Color.Red;
        private Color Player_Two_color = Color.Blue;
        private Color Blocked_Cell = Color.Gray;
        private Color Active_player_Color=> Controller.Current_Player == Controller.Player_One ? Player_One_color : Player_Two_color;
        public Form1(GameController controller)
        {
            Controller = controller;
            this.WindowState = FormWindowState.Maximized;
            /*int width = Screen.PrimaryScreen.Bounds.Width;
            int height = Screen.PrimaryScreen.Bounds.Height;
            Panel panel = new Panel();
            panel.BackColor = Color.White;
            panel.Size = new Size(width / 2, height);
            panel.Left = width / 4;
            this.Controls.Add(panel);*/
            InitializeComponent();
            AutoScroll = true;
            var sizef = Math.Max(25,400 / controller.Board.Size);
            Game_field = DrawGrid<Button>(Controller.Board.Size, Controller.Board.Size, new Size(sizef, sizef), (button) =>
            {

                var tag = (int[])button.Tag;
               
                if (Controller.Board[tag[0], tag[1]] == Game_board.Tile_State.Player)
                {
                    if (Controller.Player_One.X == tag[0] && Controller.Player_One.Y == tag[1])
                        button.BackColor = Player_One_color;
                    else
                        button.BackColor = Player_Two_color;
                }
                else
                    button.BackColor = Color.White;

                button.Click += grid_Button_Clikc;
            });

            Game_field.Location = new Point(100, 200);
            Game_field.AutoScroll = true;

            Active_Player_Change(null, null);
            Active_State_Change(null, null);
            Game_field.Size = new Size(this.Width - 150, this.ClientRectangle.Height - 300);

             Resize+=(g,gf)=> Game_field.Size = new Size(this.Width - 150, this.ClientRectangle.Height - 300);

            Controller.Current_Player_Changed += Active_Player_Change;
            Controller.Current_State_Changed += Active_State_Change;
            Controller.Current_State_Lose += Player_Lose;

            Controls.Add(Game_field);
        }

        private void Player_Lose(object sender, EventArgs e)
        {
            var fdf = new WinnerForm();
            fdf.Show();
            this.Hide();
            fdf.FormClosed += (s, g) => this.Close();
        }

        private void Active_Player_Change(object sender,EventArgs e)
        {
            
            label1.Text = "Играч: " + Controller.Current_Player.Name;
            label1.ForeColor = Active_player_Color;
        }
        private void Active_State_Change(object sender, EventArgs e)
        {
            string toadd = "Блокиране";

            if (Controller.Current_State == GameController.Turn_State.Move)
                toadd = "Местене";

            label2.Text = "Действие: " + toadd;

        }

        private void grid_Button_Clikc(object sender,EventArgs e)
        {
            var tag = (int[])((Button)sender).Tag;
            Button me = (Button)sender;
            var x = tag[0];
            var y = tag[1];
            if (Controller.Current_State == GameController.Turn_State.Move)
            {
                var p = Controller.Current_Player;
                if (Math.Sqrt(Math.Pow((x- p.X), 2) + Math.Pow((y - p.Y), 2)) > 1.6)
                {
                    MessageBox.Show("Не можеш да се преместиш там");
                    return;
                }
                if(Controller.Board[x, y] != Game_board.Tile_State.Free)
                {

                    MessageBox.Show("Недостъпно поле за блокиране");
                    return;
                }
                Game_field.Controls[Current.X + Current.Y * Controller.Board.Size].BackColor = Color.White;
                me.BackColor = Active_player_Color;
                Controller.Player_Move(x, y);
            }
            else
            {
                if (Controller.Board[x, y] != Game_board.Tile_State.Free)
                {
                    MessageBox.Show("Недостъпно поле за блокиране");
                    return;
                }

                Controller.BlocTile(tag[0], tag[1]);

                me.BackColor = Blocked_Cell;
            }

         

           
        }

        public static Panel DrawGrid<T>(int columns, int rows, Size size, Action<T> action) where T : Control, new()
        {


            var result = new Panel();

            result.Size = new Size((columns + 1) * size.Width, (rows + 1) * size.Height);

            var p = new Point(1, 1);

            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    
                    var temp = new T();
                    temp.Size = size;
                    temp.Location = p;
                    temp.Tag = new int[] { column, row };


                    action(temp);
                    result.Controls.Add(temp);
                    p = new Point(p.X + temp.Width + 1, p.Y);
                }
                p = new Point(1, p.Y + size.Height + 1);
            }

            return result;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
