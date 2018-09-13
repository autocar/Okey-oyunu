using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OKEY
{
    class tahta : Panel
    {
       
        Form1 f = new Form1();
        public tahta() {
            // EventHandler c = new EventHandler(clk);

            f = new Form1();

            List<Label> elemnlr = elemanlar();
            
            this.Size = new Size(413,60);
            this.BackColor = Color.Red;
            foreach (Label item in elemnlr)
            {
                this.Controls.Add(item);
            }
            //MessageBox.Show(this.Controls.Count.ToString());

        }

        public List<Label> elemanlar()
        {
            List<Label> dizi = new List<Label>();
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 16; j++)
                {
                    Label a = new Label();
                    a.Size = new Size(23,25);
                    a.Location = new Point(j*25,i*27);
                    a.BackColor = Color.Blue;
                    a.AllowDrop = true;
                    a.DragEnter += f.label13_DragEnter;
                    a.DragDrop += f.label13_DragDrop;
                    a.MouseDown += f.LbOrtadaki_MouseDown;
                    a.DoubleClick += f.label13_DoubleClick;
                    dizi.Add(a);
                   
                }
            }
            return dizi;
           
            

        }
    }
}
