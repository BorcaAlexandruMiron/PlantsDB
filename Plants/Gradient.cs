using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace plants
{
    internal class Gradient:Panel
    {
        public Color topColor { get; set; }//getter/setter top color
        public Color bottomColor { get; set;}//getter/setter bottom color

        //gradient paint
        protected override void OnPaint(PaintEventArgs e)
        {
            var rgb = new LinearGradientBrush(this.ClientRectangle,this.topColor, this.bottomColor,90F);
            Graphics graphics = e.Graphics;
            graphics.FillRectangle(rgb,this.ClientRectangle);
            base.OnPaint(e);
        }

        //update if resized
        protected override void OnResize(EventArgs eventargs)
        {
            this.Invalidate();  
            this.Refresh(); 

            base.OnResize(eventargs);
        }
    }
}
