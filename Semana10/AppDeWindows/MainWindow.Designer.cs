using System.Windows.Forms;

namespace AppDeWindows
{
    partial class MainWindow
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBoxDeItems = new System.Windows.Forms.ListBox();
            this.txtHolaMundo = new System.Windows.Forms.TextBox();
            this.botonClick = new System.Windows.Forms.Button();
            this.botonExterno = new System.Windows.Forms.Button();
            this.botonInterno = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxDeItems
            // 
            this.listBoxDeItems.FormattingEnabled = true;
            this.listBoxDeItems.ItemHeight = 25;
            this.listBoxDeItems.Items.AddRange(new object[] {
            "item 1",
            "item 2",
            "item 3"});
            this.listBoxDeItems.Location = new System.Drawing.Point(720, 118);
            this.listBoxDeItems.Name = "listBoxDeItems";
            this.listBoxDeItems.Size = new System.Drawing.Size(239, 179);
            this.listBoxDeItems.TabIndex = 2;
            // 
            // txtHolaMundo
            // 
            this.txtHolaMundo.Location = new System.Drawing.Point(765, 70);
            this.txtHolaMundo.Margin = new System.Windows.Forms.Padding(20);
            this.txtHolaMundo.Multiline = true;
            this.txtHolaMundo.Name = "txtHolaMundo";
            this.txtHolaMundo.Size = new System.Drawing.Size(146, 35);
            this.txtHolaMundo.TabIndex = 3;
            this.txtHolaMundo.Text = "Hola Mundo";
            this.txtHolaMundo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // botonClick
            // 
            this.botonClick.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonClick.Location = new System.Drawing.Point(720, 323);
            this.botonClick.Name = "botonClick";
            this.botonClick.Size = new System.Drawing.Size(245, 72);
            this.botonClick.TabIndex = 4;
            this.botonClick.Text = "Click Aqui";
            this.botonClick.UseVisualStyleBackColor = true;
            this.botonClick.Click += new System.EventHandler(this.botonClick_Click);
            // 
            // botonExterno
            // 
            this.botonExterno.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonExterno.Location = new System.Drawing.Point(664, 412);
            this.botonExterno.Name = "botonExterno";
            this.botonExterno.Size = new System.Drawing.Size(352, 212);
            this.botonExterno.TabIndex = 5;
            this.botonExterno.UseVisualStyleBackColor = true;
            this.botonExterno.Click += new System.EventHandler(this.botonExterno_Click);
            // 
            // botonInterno
            // 
            this.botonInterno.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonInterno.Location = new System.Drawing.Point(743, 482);
            this.botonInterno.Name = "botonInterno";
            this.botonInterno.Size = new System.Drawing.Size(194, 72);
            this.botonInterno.TabIndex = 6;
            this.botonInterno.Text = "Interno";
            this.botonInterno.UseVisualStyleBackColor = true;
            this.botonInterno.Click += new System.EventHandler(this.botonInterno_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1765, 925);
            this.Controls.Add(this.botonInterno);
            this.Controls.Add(this.botonExterno);
            this.Controls.Add(this.botonClick);
            this.Controls.Add(this.txtHolaMundo);
            this.Controls.Add(this.listBoxDeItems);
            this.Name = "MainWindow";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ListBox listBoxDeItems;
        private TextBox txtHolaMundo;
        private Button botonClick;
        private Button botonExterno;
        private Button botonInterno;
    }
}

