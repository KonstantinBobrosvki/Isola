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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
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
                MessageBox.Show("Невалидно игрално поле");
                return;
            }
            else if (int.TryParse(name1.Text,out parsedName) && int.TryParse(name2.Text, out parsedName))
            {
                MessageBox.Show("Името не може да е само цифри");
                return;
            }
            
            var fdf = new Game_field.Form1(new Game_logic.GameController(new Player(name1.Text), new Game_logic.Player(name2.Text), new Game_board(parsedSize)));
            fdf.Show();
            this.Hide();
            fdf.FormClosed += (s, g) => this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
