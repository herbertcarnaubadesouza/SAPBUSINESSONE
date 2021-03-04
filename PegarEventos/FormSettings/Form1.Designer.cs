
namespace FormSettings
{
    partial class Form1
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
            this.btnMatrix = new System.Windows.Forms.Button();
            this.btnMudarGrid = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnMatrix
            // 
            this.btnMatrix.Location = new System.Drawing.Point(107, 41);
            this.btnMatrix.Name = "btnMatrix";
            this.btnMatrix.Size = new System.Drawing.Size(98, 23);
            this.btnMatrix.TabIndex = 0;
            this.btnMatrix.Text = "Modal Form";
            this.btnMatrix.UseVisualStyleBackColor = true;
            this.btnMatrix.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnMudarGrid
            // 
            this.btnMudarGrid.Location = new System.Drawing.Point(107, 123);
            this.btnMudarGrid.Name = "btnMudarGrid";
            this.btnMudarGrid.Size = new System.Drawing.Size(98, 23);
            this.btnMudarGrid.TabIndex = 1;
            this.btnMudarGrid.Text = "Trocar Matrix";
            this.btnMudarGrid.UseVisualStyleBackColor = true;
            this.btnMudarGrid.Click += new System.EventHandler(this.btnMudarGrid_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 189);
            this.Controls.Add(this.btnMudarGrid);
            this.Controls.Add(this.btnMatrix);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMatrix;
        private System.Windows.Forms.Button btnMudarGrid;
    }
}