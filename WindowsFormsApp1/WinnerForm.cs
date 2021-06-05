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
using Game_field;

namespace WindowsFormsApp1
{
    public partial class WinnerForm : Form
    {
        public WinnerForm()
        {
            InitializeComponent();
            var player = new Player("Stamat");
            labelWinnerName.Text = $"{player.Name}";
        }

        private void buttonNewGame_Click(object sender, EventArgs e)
        {
            //старт
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
