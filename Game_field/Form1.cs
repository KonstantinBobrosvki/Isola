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

namespace Game_field
{
    public partial class Form1 : Form
    {

        static GameController controller = new GameController(new Player("Stamat"), new Player("Kostq"), new Game_board(5));
        public Form1()
        {
            this.WindowState = FormWindowState.Maximized;
            /*int width = Screen.PrimaryScreen.Bounds.Width;
            int height = Screen.PrimaryScreen.Bounds.Height;
            Panel panel = new Panel();
            panel.BackColor = Color.White;
            panel.Size = new Size(width / 2, height);
            panel.Left = width / 4;
            this.Controls.Add(panel);*/
            InitializeComponent();
            var grid = DrawGrid<Button>(controller.Board.Size, controller.Board.Size, new Size(controller.Board.Size * 20, controller.Board.Size * 20), (button) =>
            {
                var tag = (int[])button.Tag;

                if (controller.Board[tag[0], tag[1]] == Game_board.Tile_State.Player)
                    button.BackColor = Color.Red;
                else
                    button.BackColor = Color.Blue;

             button.Click += (o, a) => {
                   
                };
            });
            
            grid.Location = new Point(500, 200);

            Controls.Add(grid);
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
                    var scale = controller.Board.Board[row, column];
                    if (scale is Game_board.Tile_State.Blocked)
                        temp.BackColor = Color.Red;
                    else if (scale is Game_board.Tile_State.Player)
                        temp.BackColor = Color.Blue;
                    action(temp);
                    result.Controls.Add(temp);
                    p = new Point(p.X + temp.Width + 1, p.Y);
                }
                p = new Point(1, p.Y + size.Height + 1);
            }

            return result;
        }
    }
}
