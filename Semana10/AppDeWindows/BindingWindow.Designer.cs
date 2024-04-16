using System.Drawing;
using System.Windows.Forms;

namespace AppDeWindows
{
    partial class BindingWindow
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
            this.txtMostrarNumero = new System.Windows.Forms.TextBox();
            this.sliderDelUnoAlCien = new System.Windows.Forms.TrackBar();
            this.grid = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.sliderDelUnoAlCien)).BeginInit();
            this.grid.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtMostrarNumero
            // 
            this.txtMostrarNumero.BackColor = System.Drawing.Color.AliceBlue;
            this.txtMostrarNumero.Location = new System.Drawing.Point(3, 3);
            this.txtMostrarNumero.Name = "txtMostrarNumero";
            this.txtMostrarNumero.Size = new System.Drawing.Size(200, 31);
            this.txtMostrarNumero.TabIndex = 0;
            this.txtMostrarNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // sliderDelUnoAlCien
            // 
            this.sliderDelUnoAlCien.Location = new System.Drawing.Point(3, 103);
            this.sliderDelUnoAlCien.Maximum = 100;
            this.sliderDelUnoAlCien.Name = "sliderDelUnoAlCien";
            this.sliderDelUnoAlCien.Size = new System.Drawing.Size(973, 90);
            this.sliderDelUnoAlCien.TabIndex = 1;
            this.sliderDelUnoAlCien.TickStyle = System.Windows.Forms.TickStyle.None;
            this.sliderDelUnoAlCien.Scroll += new System.EventHandler(this.slider1_Scroll);
            // 
            // grid
            // 
            this.grid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 979F));
            this.grid.Controls.Add(this.sliderDelUnoAlCien, 0, 1);
            this.grid.Controls.Add(this.txtMostrarNumero, 0, 0);
            this.grid.Location = new System.Drawing.Point(301, 43);
            this.grid.Name = "grid";
            this.grid.RowCount = 2;
            this.grid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.grid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.grid.Size = new System.Drawing.Size(979, 458);
            this.grid.TabIndex = 0;
            // 
            // BindingWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1548, 865);
            this.Controls.Add(this.grid);
            this.Name = "BindingWindow";
            this.Text = "BindingWindow";
            ((System.ComponentModel.ISupportInitialize)(this.sliderDelUnoAlCien)).EndInit();
            this.grid.ResumeLayout(false);
            this.grid.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TextBox txtMostrarNumero;
        private TrackBar sliderDelUnoAlCien;
        private TableLayoutPanel grid;
    }
}