using Microsoft.EntityFrameworkCore;
using plants.Models;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;

namespace plants
{
    public partial class Form1 : Form
    {

        #region DWMWINDOWATTRIBUTE
        public enum DWMWINDOWATTRIBUTE
        {
            DWMWA_WINDOW_CORNER_PREFERENCE = 33
        }

        public enum DWM_WINDOW_CORNER_PREFERENCE
        {
            DWMWCP_DEFAULT = 0,
            DWMWCP_DONOTROUND = 1,
            DWMWCP_ROUND = 2,
            DWMWCP_ROUNDSMALL = 3,
        }


        [DllImport("dwmapi.dll", CharSet = CharSet.Unicode, PreserveSig = false)]
        internal static extern void DwmSetWindowAttribute(IntPtr hwnd,
                                                         DWMWINDOWATTRIBUTE attribute,
                                                         ref DWM_WINDOW_CORNER_PREFERENCE pvAttribute,
                                                         uint cbAttribute);
        #endregion

        private Point center;
        private int radius;
        private double radian;
        private bool state;
        private SolidBrush b;
        private StringFormat format;
        private Graphics g;
        private Pen pen;
        private plants[] bt;
        private List<Point> points;

        private static async Task<List<PlantDb>> GetAll()
        {
            using (var pd = new PlantContext())
            {
                var que = from it in pd.PlanteDbs
                          select it;
                return await que.ToListAsync();
            }
        }

        private static async Task<List<PlantDb>> getByName(string name)
        {
            using (var pd = new PlantContext())
            {
                var que = from it in pd.PlanteDbs
                          where it.TherapeuticEffects.Contains(name)
                          select it;
                return await que.ToListAsync();
            }
        }

        private async Task<List<Point>> getPoints(int nof, int size)
        {
            var aux = new List<Point>();

            await Task.Run(() =>
            {
                center = new Point(this.panel1.Width / 2, (this.panel1.Height / 2) + size / nof);
                radius = this.panel1.Height / 2 - 50;
                radian = (2 * Math.PI) / nof;

                for (double angle = 0; angle < 2 * Math.PI; angle += radian)
                {
                    var currentPoint = new Point((int)(center.X + radius * Math.Cos(angle)) - size / 2, (int)(center.Y + radius * Math.Sin(angle)) - size / 2);
                    aux.Add(currentPoint);
                }
            });
            return aux;

        }

        public Form1()
        {
            InitializeComponent();
            #region rounded
            var attribute = DWMWINDOWATTRIBUTE.DWMWA_WINDOW_CORNER_PREFERENCE;
            var preference = DWM_WINDOW_CORNER_PREFERENCE.DWMWCP_ROUND;
            DwmSetWindowAttribute(this.Handle, attribute, ref preference, sizeof(uint));
            #endregion
            #region panel1_init
            this.panel1.Width = this.Width / 2 + this.Width / 4;
            this.panel1.Height = this.Height;
            this.panel1.HorizontalScroll.Enabled = true;
            //double buffered panel
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty
           | BindingFlags.Instance | BindingFlags.NonPublic, null,
           panel1, new object[] { true });
            #endregion          
            #region textbox1_init
            this.textBox1.Location = new Point(this.panel1.Width + 2, 0);
            this.textBox1.Width = this.Width - this.panel1.Width - 19;
            #endregion
            #region dataGridView1_init
            this.dataGridView1.Location = new Point(this.panel1.Width + 2, this.textBox1.Location.Y + this.textBox1.Height);
            this.dataGridView1.Width = this.Width - this.panel1.Width - 19;
            this.dataGridView1.Height = this.Height - (this.textBox1.Height) - 40;
            #endregion
            #region button1_init
            this.button1.Height = this.textBox1.Height;
            this.button1.Location = new Point(this.textBox1.Location.X + (this.textBox1.Width - this.button1.Width), this.textBox1.Location.Y);
            #endregion
            b = new SolidBrush(Color.Black);
            format = new StringFormat();
            format.Alignment = StringAlignment.Center;
            state = true;
            pen = new Pen(Color.Black, 1);
            points = new List<Point>();
        }

        private async void Form1_Resize(object sender, EventArgs e)
        {
            this.gradient1.Width = this.Width;
            this.gradient1.Height = this.Height;
            this.panel1.Width = this.Width / 2 + this.Width / 4;
            this.panel1.Height = this.Height;
            this.textBox1.Location = new Point(this.panel1.Width + 2, 0);
            this.textBox1.Width = this.Width - this.panel1.Width - 19;
            this.dataGridView1.Location = new Point(this.panel1.Width + 2, this.textBox1.Location.Y + this.textBox1.Height);
            this.dataGridView1.Width = this.Width - this.panel1.Width - 19;
            this.dataGridView1.Height = this.Height - (this.textBox1.Height) - 40;
            this.button1.Height = this.textBox1.Height;
            this.button1.Location = new Point(this.textBox1.Location.X + (this.textBox1.Width - this.button1.Width), this.textBox1.Location.Y);

            if ((this.WindowState.ToString() == "Maximized" || (this.WindowState.ToString() == "Normal" && state == true)) && dataGridView1.RowCount > 0)
            {
                points.Clear();
                panel1.Controls.Clear();



                if (dataGridView1.RowCount >= 43)
                {
                    points = await getPoints(dataGridView1.RowCount, panel1.Height / (dataGridView1.RowCount / 2));

                    int i = 0;
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {

                        bt[(int)(row.Cells[0].Value) - 1].Width = panel1.Height / (dataGridView1.RowCount / 2);
                        bt[(int)(row.Cells[0].Value) - 1].Height = panel1.Height / (dataGridView1.RowCount / 2);
                        bt[(int)(row.Cells[0].Value) - 1].Location = points[i];
                        i++;
                        panel1.Controls.Add(bt[(int)(row.Cells[0].Value) - 1]);

                    }

                }
                else
                {
                    int i = 0;
                    points = await getPoints(dataGridView1.RowCount, 40);


                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {

                        bt[(int)(row.Cells[0].Value) - 1].Width = 40;
                        bt[(int)(row.Cells[0].Value) - 1].Height = 40;
                        bt[(int)(row.Cells[0].Value) - 1].Location = points[i];
                        i++;
                        panel1.Controls.Add(bt[(int)(row.Cells[0].Value) - 1]);
                    }

                }

                if (this.WindowState.ToString() == "Maximized")
                {
                    state = true;
                }
                else
                {
                    state = false;
                }

                panel1.Refresh();
                g = panel1.CreateGraphics();

                for (int j = 0; j < dataGridView1.RowCount; j++)
                {
                    g.DrawLine(pen, center, points[j]);
                }

                g.DrawImage(Properties.Resources.center1, center.X - panel1.Height / 8, center.Y - panel1.Height / 8, panel1.Height / 4, panel1.Height / 4);
                g.DrawString("Therapeutic Effects", this.Font, Brushes.Black, center, format);

            }

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            this.ActiveControl = panel1;
        }

        private void panel1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

            if (e.KeyCode == Keys.Oem6)
            {
                foreach (Control control in panel1.Controls)
                {
                    control.Size += new Size(10, 10);
                    MessageBox.Show(bt[0].Size.ToString());
                }
            }
            if (e.KeyCode == Keys.Oem4)
            {
                foreach (Control control in panel1.Controls)
                {
                    control.Size -= new Size(10, 10);
                }
            }
            gradient1.Refresh();
        }

        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            //panel1.Focus();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {

            dataGridView1.DataSource = await GetAll();
            bt = new plants[dataGridView1.RowCount];
            this.ActiveControl = panel1;
            if (dataGridView1.RowCount >= 43)
            {
                for (var i = 0; i < dataGridView1.RowCount; i++)
                {
                    bt[i] = new plants();
                    bt[i].index = (int)dataGridView1.Rows[i].Cells[0].Value;
                    bt[i].name = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    bt[i].Width = panel1.Height / (dataGridView1.RowCount / 2);
                    bt[i].Height = bt[i].Width;
                    ControlExtension.Draggable(bt[i], true);
                }
            }
            else
            {
                for (var i = 0; i < dataGridView1.RowCount; i++)
                {
                    bt[i] = new plants();
                    bt[i].index = (int)dataGridView1.Rows[i].Cells[0].Value;
                    bt[i].name = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    ControlExtension.Draggable(bt[i], true);
                }
            }

            points = await getPoints(dataGridView1.RowCount, bt[0].Width);

            for (var i = 0; i < dataGridView1.RowCount; i++)
            {
                bt[i].Location = points[i];
                panel1.Controls.Add(bt[i]);
            }

            g = panel1.CreateGraphics();
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                g.DrawLine(pen, center, points[i]);
            }

            g.DrawImage(Properties.Resources.center1, center.X - panel1.Height / 8, center.Y - panel1.Height / 8, panel1.Height / 4, panel1.Height / 4);
            g.DrawString("Therapeutic Effects", this.Font, Brushes.Black, center, format);

        }

        private async void Form1_ResizeEnd(object sender, EventArgs e)
        {
            //dataGridView1.DataSource = await getByName(textBox1.Text);
            if (dataGridView1.RowCount > 0)
            {
                panel1.Controls.Clear();

                points.Clear();

                if (dataGridView1.RowCount >= 43)
                {

                    points = await getPoints(dataGridView1.RowCount, panel1.Height / (dataGridView1.RowCount / 2));

                    int i = 0;
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {

                        bt[(int)(row.Cells[0].Value) - 1].Width = panel1.Height / (dataGridView1.RowCount / 2);
                        bt[(int)(row.Cells[0].Value) - 1].Height = panel1.Height / (dataGridView1.RowCount / 2);
                        bt[(int)(row.Cells[0].Value) - 1].Location = points[i];
                        i++;
                        panel1.Controls.Add(bt[(int)(row.Cells[0].Value) - 1]);

                    }

                }
                else
                {
                    points = await getPoints(dataGridView1.RowCount, 40);
                    int i = 0;

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {

                        bt[(int)(row.Cells[0].Value) - 1].Width = 40;
                        bt[(int)(row.Cells[0].Value) - 1].Height = 40;
                        bt[(int)(row.Cells[0].Value) - 1].Location = points[i];
                        i++;
                        panel1.Controls.Add(bt[(int)(row.Cells[0].Value) - 1]);
                    }
                }
                panel1.Refresh();
                g = panel1.CreateGraphics();

                for (int j = 0; j < dataGridView1.RowCount; j++)
                {
                    g.DrawLine(pen, center, points[j]);
                }

                g.DrawImage(Properties.Resources.center1, center.X - panel1.Height / 8, center.Y - panel1.Height / 8, panel1.Height / 4, panel1.Height / 4);
                g.DrawString("Therapeutic Effects", this.Font, Brushes.Black, center, format);
            }

        }

        private void dataGridView1_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //MessageBox.Show(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                dataGridView1.Rows[e.RowIndex].Selected = true;
                bt[((int)dataGridView1.Rows[e.RowIndex].Cells[0].Value) - 1].selected();
            }
        }

        private void dataGridView1_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //MessageBox.Show(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                dataGridView1.Rows[e.RowIndex].Selected = true;
                bt[((int)dataGridView1.Rows[e.RowIndex].Cells[0].Value) - 1].normal();
            }
            dataGridView1.ClearSelection();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = await getByName(textBox1.Text);

            if (dataGridView1.RowCount > 0)
            {
                panel1.Controls.Clear();
                points.Clear();
                panel1.Refresh();

                if (dataGridView1.RowCount >= 43)
                {
                    points = await getPoints(dataGridView1.RowCount, panel1.Height / (dataGridView1.RowCount / 2));
                    int i = 0;
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {

                        bt[(int)(row.Cells[0].Value) - 1].Width = panel1.Height / (dataGridView1.RowCount / 2);
                        bt[(int)(row.Cells[0].Value) - 1].Height = panel1.Height / (dataGridView1.RowCount / 2);
                        bt[(int)(row.Cells[0].Value) - 1].Location = points[i];
                        i++;
                        panel1.Controls.Add(bt[(int)(row.Cells[0].Value) - 1]);
                        /*bt[(int)dataGridView1.Rows[i].Cells[0].Value].Width = panel1.Height / ((int)dataGridView1.Rows[i].Cells[0].Value / 2);
                        bt[(int)dataGridView1.Rows[i].Cells[0].Value].Height = bt[(int)dataGridView1.Rows[i].Cells[0].Value].Width;*/
                    }

                }
                else
                {
                    points = await getPoints(dataGridView1.RowCount, 40);
                    int i = 0;
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {

                        bt[(int)(row.Cells[0].Value) - 1].Width = 40;
                        bt[(int)(row.Cells[0].Value) - 1].Height = 40;
                        bt[(int)(row.Cells[0].Value) - 1].Location = points[i];
                        i++;
                        panel1.Controls.Add(bt[(int)(row.Cells[0].Value) - 1]);
                    }
                }
                for (int j = 0; j < dataGridView1.RowCount; j++)
                {
                    g.DrawLine(pen, center, points[j]);
                }

                g.DrawImage(Properties.Resources.center1, center.X - panel1.Height / 8, center.Y - panel1.Height / 8, panel1.Height / 4, panel1.Height / 4);
                g.DrawString("Therapeutic Effects", this.Font, Brushes.Black, center, format);
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Search a therapeutic effect")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.White;

            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Search a therapeutic effect";
                textBox1.ForeColor = Color.Silver;
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(new object(), new EventArgs());
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            bt[(int)(dataGridView1.Rows[e.RowIndex].Cells[0].Value) - 1].plants_Click(new object(), new EventArgs());
        }
    }
}