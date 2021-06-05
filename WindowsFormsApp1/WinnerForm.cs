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

namespace WindowsFormsApp1
{
    public partial class WinnerForm : Form
    {
        public WinnerForm(Player winner)
        {
            InitializeComponent();
            labelWinnerName.Text = $"{winner.Name}";
        }

        private void buttonNewGame_Click(object sender, EventArgs e)
        {

            this.Hide();
            var openNewGame = new Isola.Form1();
            openNewGame.Show();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void WinnerForm_Load(object sender, EventArgs e)
        {

        }
    }
}
