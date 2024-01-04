using plants.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using plants.Models;
using Microsoft.EntityFrameworkCore;

namespace plants
{
    public partial class Form2 : Form
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

        private int index;
        public Form2(int index, string name)
        {
            InitializeComponent();
            this.index = index;
            this.Text = name;
            this.Refresh();
            #region rounded
            var attribute = DWMWINDOWATTRIBUTE.DWMWA_WINDOW_CORNER_PREFERENCE;
            var preference = DWM_WINDOW_CORNER_PREFERENCE.DWMWCP_ROUND;
            DwmSetWindowAttribute(this.Handle, attribute, ref preference, sizeof(uint));
            #endregion
            textBox2.ScrollBars = ScrollBars.Vertical;
            textBox3.ScrollBars = ScrollBars.Vertical;
        }
        private static async Task<List<PlantDb>> getById(int id)
        {
            using (var pd = new PlantContext())
            {
                var que = from it in pd.PlanteDbs
                          where it.Id == id
                          select it;
                return await que.ToListAsync();
            }
        }
        private async void Form2_Load(object sender, EventArgs e)
        {
            var result = await getById(index);

            if (result != null)
            {
                textBox1.Text = result[0].ScientificName;
                textBox2.Text = result[0].TherapeuticEffects;
                textBox3.Text = result[0].References;
            }
        }

        private void Form2_Deactivate(object sender, EventArgs e)
        {
            this.Close();   
        }
    }
}
