using Plants.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace plants
{
    public partial class plants : UserControl
    {

        public plants()
        {
            InitializeComponent();

        }

        public string name { get; set; }

        public int index { get; set; }

        private void plants_MouseHover(object sender, EventArgs e)
        {
            //MessageBox.Show(index.ToString());
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            Form1 p = (Form1)this.Parent.Parent.Parent;

            foreach (DataGridViewRow row in p.dataGridView1.Rows)
            {
                if (((int)(row.Cells[0].Value)).Equals(index))
                {
                    p.dataGridView1.Rows[row.Index].Selected = true;
                    p.dataGridView1.FirstDisplayedScrollingRowIndex = p.dataGridView1.SelectedRows[0].Index;
                    this.selected();
                    ToolTip1.SetToolTip(this, name);
                    break;
                }
            }
        }

        private void plants_MouseLeave(object sender, EventArgs e)
        {
            Form1 p = (Form1)this.Parent.Parent.Parent;
            this.normal();
            p.dataGridView1.ClearSelection();
        }

        public void selected()
        {
            this.BackgroundImage = Properties.Resources.selected;
        }

        public void normal()
        {
            this.BackgroundImage = Properties.Resources.normal;
        }

        public void plants_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2(index,name);
            form.Show();
        }
    }
}
