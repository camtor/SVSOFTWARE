﻿namespace SVSOFTWARE
{
    partial class FrmConsultarProducto
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
            this.SuspendLayout();
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(188, 9);
            this.label2.Size = new System.Drawing.Size(239, 25);
            this.label2.Text = "CONSULTAS PRODUCTOS";
            // 
            // FrmConsultarProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 377);
            this.Name = "FrmConsultarProducto";
            this.Text = "";
            this.Load += new System.EventHandler(this.FrmConsultarProducto_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}