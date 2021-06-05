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
namespace Isola
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            WindowState = FormWindowState.Maximized;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int parsedSize;
            int parsedName;
            if (string.IsNullOrEmpty(name1.Text))
            {
                MessageBox.Show("Невалидно име за играч едно");
                return;
            }
            else if (string.IsNullOrEmpty(name2.Text))
            {
                MessageBox.Show("Невалидно име за играч две");
                return;
            } 
            else if (!int.TryParse(size.Text, out parsedSize))
            {
                MessageBox.Show("Игралното поле не може да е текст или празно");
                return;
            }
            else if (name1.Text == name2.Text)
            {
                MessageBox.Show("Имената на играчите съвпадат");
                return;
            }
            else if (name1.Text.Length > 10)
            {
                MessageBox.Show("Името на играч едно е прекалено дълго");
                return;
            }
            else if (name2.Text.Length > 10)
            {
                MessageBox.Show("Името на играч две е прекалено дълго");
                return;
            }
            else if (parsedSize > 50 || parsedSize <= 1 || parsedSize % 2 == 0)
            {
                MessageBox.Show("Невалиден размер на поле");
                return;
            }
            else if (int.TryParse(name1.Text,out parsedName) && int.TryParse(name2.Text, out parsedName))
            {
                MessageBox.Show("Името не може да е само цифри");
                return;
            }
            
            var startGame = new Game_field.Form1(new Game_logic.GameController(new Player(name1.Text), new Game_logic.Player(name2.Text), new Game_board(parsedSize)));
            startGame.Show();
            this.Hide();
            startGame.FormClosed += (s, g) => this.Close();
        }

        private void labelHowToPlayHover(object sender, EventArgs e)
        {
            labelInstructions.Visible = true;
        }

        private void labelHowToPlayLeave(object sender, EventArgs e)
        {
            labelInstructions.Visible = false;
        }
    }
}
