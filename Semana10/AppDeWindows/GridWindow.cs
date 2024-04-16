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
    public partial class GridWindow : Form
    {
        public GridWindow()
        {
            InitializeComponent();
        }

        private void btnCondicional_MouseEnter(object sender, EventArgs e)
        {
            btnCondicional.Font = new Font(btnCondicional.Font.FontFamily, 12); // Tamaño original de la fuente

            btnCondicional.MouseEnter += (s, ex) =>
            {
                btnCondicional.Font = new Font(btnCondicional.Font.FontFamily, 20); // Tamaño de la fuente cuando el mouse está encima
            };

            btnCondicional.MouseLeave += (s, ex) =>
            {
                btnCondicional.Font = new Font(btnCondicional.Font.FontFamily, 12); // Tamaño de la fuente cuando el mouse deja de estar encima
            };

        }
    }
}
