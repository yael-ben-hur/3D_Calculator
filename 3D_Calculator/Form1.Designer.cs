namespace _3D_Calculator
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
            this.Draw_Function = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Insert_Function = new System.Windows.Forms.TextBox();
            this.Color_The_Function = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Draw_Function
            // 
            this.Draw_Function.Location = new System.Drawing.Point(12, 12);
            this.Draw_Function.Name = "Draw_Function";
            this.Draw_Function.Size = new System.Drawing.Size(121, 23);
            this.Draw_Function.TabIndex = 0;
            this.Draw_Function.Text = "Draw Function";
            this.Draw_Function.UseVisualStyleBackColor = true;
            this.Draw_Function.Click += new System.EventHandler(this.Draw_Function_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(30, 58);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1306, 724);
            this.panel1.TabIndex = 1;
            // 
            // Insert_Function
            // 
            this.Insert_Function.Location = new System.Drawing.Point(177, 14);
            this.Insert_Function.Name = "Insert_Function";
            this.Insert_Function.Size = new System.Drawing.Size(100, 20);
            this.Insert_Function.TabIndex = 0;
            // 
            // Color_The_Function
            // 
            this.Color_The_Function.Location = new System.Drawing.Point(341, 14);
            this.Color_The_Function.Name = "Color_The_Function";
            this.Color_The_Function.Size = new System.Drawing.Size(127, 23);
            this.Color_The_Function.TabIndex = 0;
            this.Color_The_Function.Text = "Color Function";
            this.Color_The_Function.UseVisualStyleBackColor = true;
            this.Color_The_Function.Click += new System.EventHandler(this.Color_The_Function_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1392, 809);
            this.Controls.Add(this.Color_The_Function);
            this.Controls.Add(this.Insert_Function);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Draw_Function);
            this.Name = "Form1";
            this.Text = "3D Calculator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Draw_Function;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox Insert_Function;
        private System.Windows.Forms.Button Color_The_Function;
    }
}

