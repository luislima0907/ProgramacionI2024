using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppDeWindows
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void botonClick_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            MessageBox.Show("Has presionado el boton " + button.Name);
        }

        private void botonInterno_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Has dado clic en el interno");
        }

        private void botonExterno_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Has dado clic en el Externo");
        }
    }
}
