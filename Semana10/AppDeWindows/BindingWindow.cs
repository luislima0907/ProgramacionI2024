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
    public partial class BindingWindow : Form
    {
        public BindingWindow()
        {
            InitializeComponent();
        }

        private void slider1_Scroll(object sender, EventArgs e)
        {
            // Vinculación de los controles
            sliderDelUnoAlCien.ValueChanged += (s, ex) =>
            {
                txtMostrarNumero.Text = sliderDelUnoAlCien.Value.ToString();
            };
        }
    }
}
