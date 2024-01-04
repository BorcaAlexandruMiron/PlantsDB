namespace plants
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            gradient1 = new Gradient();
            button1 = new Button();
            dataGridView1 = new DataGridView();
            panel1 = new Panel();
            textBox1 = new TextBox();
            gradient1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // gradient1
            // 
            gradient1.bottomColor = Color.FromArgb(98, 146, 158);
            gradient1.Controls.Add(button1);
            gradient1.Controls.Add(dataGridView1);
            gradient1.Controls.Add(panel1);
            gradient1.Controls.Add(textBox1);
            gradient1.Location = new Point(0, 0);
            gradient1.Name = "gradient1";
            gradient1.Size = new Size(1156, 539);
            gradient1.TabIndex = 0;
            gradient1.topColor = Color.FromArgb(198, 197, 185);
            // 
            // button1
            // 
            button1.AutoSize = true;
            button1.BackColor = Color.Gainsboro;
            button1.Location = new Point(1035, 41);
            button1.Name = "button1";
            button1.Size = new Size(75, 25);
            button1.TabIndex = 4;
            button1.Text = "Search";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = Color.FromArgb(84, 106, 123);
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.GridColor = SystemColors.Highlight;
            dataGridView1.Location = new Point(769, 75);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Size = new Size(341, 449);
            dataGridView1.TabIndex = 3;
            dataGridView1.CellClick += dataGridView1_CellClick;
            dataGridView1.CellMouseLeave += dataGridView1_CellMouseLeave;
            dataGridView1.CellMouseMove += dataGridView1_CellMouseMove;
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.BackColor = Color.Transparent;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(763, 524);
            panel1.TabIndex = 2;
            panel1.MouseDown += panel1_MouseDown;
            panel1.MouseEnter += panel1_MouseEnter;
            panel1.PreviewKeyDown += panel1_PreviewKeyDown;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.FromArgb(84, 106, 123);
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.CausesValidation = false;
            textBox1.Font = new Font("Calibri", 20F);
            textBox1.ForeColor = Color.Silver;
            textBox1.Location = new Point(769, 29);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(341, 40);
            textBox1.TabIndex = 1;
            textBox1.Text = "Search a therapeutic effect";
            textBox1.Enter += textBox1_Enter;
            textBox1.KeyDown += textBox1_KeyDown;
            textBox1.Leave += textBox1_Leave;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1110, 526);
            Controls.Add(gradient1);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(1126, 565);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = " ";
            TransparencyKey = Color.Lime;
            Load += Form1_Load;
            ResizeEnd += Form1_ResizeEnd;
            Resize += Form1_Resize;
            gradient1.ResumeLayout(false);
            gradient1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Gradient gradient1;
        private TextBox textBox1;
        private Panel panel1;
        private Button button1;
        public DataGridView dataGridView1;
    }
}
