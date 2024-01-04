namespace plants
{
    partial class plants
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            imageList1 = new ImageList(components);
            SuspendLayout();
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageSize = new Size(16, 16);
            imageList1.TransparentColor = Color.Transparent;
            // 
            // plants
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.Transparent;
            BackgroundImage = Properties.Resources.normal;
            BackgroundImageLayout = ImageLayout.Stretch;
            DoubleBuffered = true;
            Name = "plants";
            Size = new Size(40, 40);
            Click += plants_Click;
            MouseLeave += plants_MouseLeave;
            MouseHover += plants_MouseHover;
            ResumeLayout(false);
        }

        #endregion

        private ImageList imageList1;
    }
}
