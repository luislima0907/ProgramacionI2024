using System.Drawing;
using System.Windows.Forms;

namespace AppDeWindows
{
    partial class GridWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtPrimeraFilaYColumna = new System.Windows.Forms.TextBox();
            this.btnDelCentro = new System.Windows.Forms.Button();
            this.panelRectangularDeLaUltimaFilaYColumna = new System.Windows.Forms.Panel();
            this.labelDeLaFilaTresYColumnaUno = new System.Windows.Forms.Label();
            this.btnCondicional = new System.Windows.Forms.Button();
            this.grid = new System.Windows.Forms.TableLayoutPanel();
            this.grid.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtPrimeraFilaYColumna
            // 
            this.txtPrimeraFilaYColumna.Location = new System.Drawing.Point(5, 5);
            this.txtPrimeraFilaYColumna.Name = "txtPrimeraFilaYColumna";
            this.txtPrimeraFilaYColumna.Size = new System.Drawing.Size(100, 31);
            this.txtPrimeraFilaYColumna.TabIndex = 0;
            this.txtPrimeraFilaYColumna.Text = "Elemento 1";
            // 
            // btnDelCentro
            // 
            this.btnDelCentro.Location = new System.Drawing.Point(113, 44);
            this.btnDelCentro.Name = "btnDelCentro";
            this.btnDelCentro.Size = new System.Drawing.Size(567, 339);
            this.btnDelCentro.TabIndex = 1;
            this.btnDelCentro.Text = "Elemento 2";
            // 
            // panelRectangularDeLaUltimaFilaYColumna
            // 
            this.panelRectangularDeLaUltimaFilaYColumna.BackColor = System.Drawing.Color.LightBlue;
            this.panelRectangularDeLaUltimaFilaYColumna.Location = new System.Drawing.Point(688, 391);
            this.panelRectangularDeLaUltimaFilaYColumna.Name = "panelRectangularDeLaUltimaFilaYColumna";
            this.panelRectangularDeLaUltimaFilaYColumna.Size = new System.Drawing.Size(94, 44);
            this.panelRectangularDeLaUltimaFilaYColumna.TabIndex = 2;
            // 
            // labelDeLaFilaTresYColumnaUno
            // 
            this.labelDeLaFilaTresYColumnaUno.Location = new System.Drawing.Point(5, 388);
            this.labelDeLaFilaTresYColumnaUno.Name = "labelDeLaFilaTresYColumnaUno";
            this.labelDeLaFilaTresYColumnaUno.Size = new System.Drawing.Size(100, 23);
            this.labelDeLaFilaTresYColumnaUno.TabIndex = 3;
            this.labelDeLaFilaTresYColumnaUno.Text = "Elemento 4";
            // 
            // btnCondicional
            // 
            this.btnCondicional.Location = new System.Drawing.Point(113, 391);
            this.btnCondicional.Name = "btnCondicional";
            this.btnCondicional.Size = new System.Drawing.Size(200, 44);
            this.btnCondicional.TabIndex = 4;
            this.btnCondicional.Text = "Condicional";
            this.btnCondicional.MouseEnter += new System.EventHandler(this.btnCondicional_MouseEnter);
            // 
            // grid
            // 
            this.grid.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.grid.ColumnCount = 3;
            this.grid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.grid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.grid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 104F));
            this.grid.Controls.Add(this.txtPrimeraFilaYColumna, 0, 0);
            this.grid.Controls.Add(this.btnDelCentro, 1, 1);
            this.grid.Controls.Add(this.panelRectangularDeLaUltimaFilaYColumna, 2, 2);
            this.grid.Controls.Add(this.labelDeLaFilaTresYColumnaUno, 0, 2);
            this.grid.Controls.Add(this.btnCondicional, 1, 2);
            this.grid.Location = new System.Drawing.Point(363, 101);
            this.grid.Name = "grid";
            this.grid.RowCount = 3;
            this.grid.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.grid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.grid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.grid.Size = new System.Drawing.Size(791, 440);
            this.grid.TabIndex = 0;
            // 
            // GridWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1594, 798);
            this.Controls.Add(this.grid);
            this.Name = "GridWindow";
            this.Text = "GridWindow";
            this.grid.ResumeLayout(false);
            this.grid.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private TextBox txtPrimeraFilaYColumna;
        private Button btnDelCentro;
        private Panel panelRectangularDeLaUltimaFilaYColumna;
        private Label labelDeLaFilaTresYColumnaUno;
        private Button btnCondicional;
        private TableLayoutPanel grid;

    }
}