namespace plants
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            gradient1 = new Gradient();
            textBox3 = new TextBox();
            label3 = new Label();
            textBox2 = new TextBox();
            label2 = new Label();
            textBox1 = new TextBox();
            label1 = new Label();
            gradient1.SuspendLayout();
            SuspendLayout();
            // 
            // gradient1
            // 
            gradient1.bottomColor = Color.FromArgb(98, 146, 158);
            gradient1.Controls.Add(textBox3);
            gradient1.Controls.Add(label3);
            gradient1.Controls.Add(textBox2);
            gradient1.Controls.Add(label2);
            gradient1.Controls.Add(textBox1);
            gradient1.Controls.Add(label1);
            gradient1.Location = new Point(0, 0);
            gradient1.Name = "gradient1";
            gradient1.Size = new Size(500, 500);
            gradient1.TabIndex = 0;
            gradient1.topColor = Color.FromArgb(198, 197, 185);
            // 
            // textBox3
            // 
            textBox3.BackColor = SystemColors.InactiveBorder;
            textBox3.Font = new Font("Calibri", 20F);
            textBox3.Location = new Point(12, 292);
            textBox3.Multiline = true;
            textBox3.Name = "textBox3";
            textBox3.ReadOnly = true;
            textBox3.Size = new Size(449, 157);
            textBox3.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Calibri", 20F);
            label3.ForeColor = SystemColors.MenuText;
            label3.Location = new Point(12, 256);
            label3.Name = "label3";
            label3.Size = new Size(141, 33);
            label3.TabIndex = 4;
            label3.Text = "References:";
            // 
            // textBox2
            // 
            textBox2.BackColor = SystemColors.InactiveBorder;
            textBox2.Font = new Font("Calibri", 20F);
            textBox2.Location = new Point(12, 157);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(449, 96);
            textBox2.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Calibri", 20F);
            label2.ForeColor = SystemColors.MenuText;
            label2.Location = new Point(12, 88);
            label2.Name = "label2";
            label2.Size = new Size(331, 66);
            label2.TabIndex = 2;
            label2.Text = "Therapeutic effects/\r\npart of the plant that is used:";
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.InactiveBorder;
            textBox1.Font = new Font("Calibri", 20F);
            textBox1.Location = new Point(12, 45);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(331, 40);
            textBox1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Calibri", 20F);
            label1.ForeColor = SystemColors.MenuText;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(189, 33);
            label1.TabIndex = 0;
            label1.Text = "Scientific Name:";
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 461);
            Controls.Add(gradient1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Form2";
            Text = "Form2";
            Deactivate += Form2_Deactivate;
            Load += Form2_Load;
            gradient1.ResumeLayout(false);
            gradient1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Gradient gradient1;
        private Label label1;
        private TextBox textBox1;
        private Label label3;
        private TextBox textBox2;
        private Label label2;
        private TextBox textBox3;
    }
}