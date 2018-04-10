using System;
using System.Windows.Forms;

namespace Matematica {
    public partial class Form1 : Form {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Multiplicacao().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Divisao().Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new Subtracao().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Soma().Show();
        }
    }
}
