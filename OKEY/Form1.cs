using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OKEY
{
    public partial class Form1 : Form
    {
        bool sirabende = true;
        List<tas> taslar = new List<tas>();
        List<tas> benimTaslarim = new List<tas>();
        List<tas> benimDizilmisTaslarim = new List<tas>();
        List<tas> rakipTaslari = new List<tas>();
        List<tas> ortadakiTaslar = new List<tas>();
        List<tas> rakipDizilmisTaslar = new List<tas>();
       
        List<tas> attigimTaslar = new List<tas>();
        List<tas> rakibinAttigiTaslar = new List<tas>();
        int index = 1;
        public Form1()
        {
            InitializeComponent();

          
        }
        void tas_dagit(Panel a,int tasSayisi)
        {
          
            foreach (Control c in a.Controls)
            {
                if (c.Tag == null && c.GetType() == typeof(Label) && tasSayisi > 0)
                {
                    int rast = r.Next(0, taslar.Count);

                    tas v = new tas();
                    v = taslar[rast];
                    if(a==panelimm)
                        benimTaslarim.Add(taslar[rast]);
                    else if (a == panelRakip)
                        rakipTaslari.Add(taslar[rast]);
                    taslar.Remove(taslar[rast]);
                    c.Text = v.sayi.ToString();
                    c.Tag = v.key;
                    c.BackColor = Color.White;

                    if (v.ismi == "K")
                        c.ForeColor = Color.Red;
                    if (v.ismi == "Y")
                        c.ForeColor = Color.DarkGreen;
                    if (v.ismi == "M")
                        c.ForeColor = Color.Blue;
                    if (v.ismi == "S")
                        c.ForeColor = Color.Black;
                    tasSayisi--;

                }


            }

           


        }
        private void button1_Click(object sender, EventArgs e)
        {
            //taslar.Clear();
            //listBox1.Items.Clear();
            //listBox2.Items.Clear();
            //benimTaslarim.Clear();
            //benimDizilmisTaslarim.Clear();
            //rakipTaslari.Clear();
            //rakipDizilmisTaslar.Clear();
            //attigimTaslar.Clear();
            //lbAtilan.Tag=null;
            //lbAtilan.Text = "";
            //foreach (Label item in panelimm.Controls)
            //{
            //    item.Text = "";
            //    item.Tag = null;
            //}
            //foreach (Label item in panelRakip.Controls)
            //{
            //    item.Text = "";
            //    item.Tag = null;
            //}
            //taslari_olustur();
            //taslari_olustur();
            //tas_dagit(panelimm,14);
            //tas_dagit(panelRakip,13);


            ////taslari_dagit();

            //ortayaEkle();
            ////rakipTaslariniEkle();

        }
        public void ortayaEkle()
        {
            int a = 0;
            //MessageBox.Show(ortadakiTaslar.Count.ToString());
            for (int i = 0; i < 77; i++)
            {

                a = r.Next(0, taslar.Count-1);
                ortadakiTaslar.Add(taslar[a]);
                taslar.Remove(taslar[a]);

            }
            lbOrtadaki.Click += LbOrtadaki_Click;
            lbOrtadaki.MouseDown += LbOrtadaki_MouseDown;
            lbGelen.MouseDown +=  LbOrtadaki_MouseDown;
        }

        public void LbOrtadaki_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Clicks == 1)
            {
                Label a = (Label)sender;
               // MessageBox.Show(a.Text);
                a.Select();
                a.DoDragDrop(a, DragDropEffects.Copy);
                //throw new NotImplementedException();
            }
        }

        private void LbOrtadaki_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            MessageBox.Show("sss");
            //MessageBox.Show(lbOrtadaki.Tag.ToString());
        }

        public void taslari_olustur()
        {

            for (int i = 1; i <= 4; i++)
            {
                for (int j = 1; j <= 13; j++)
                {
                    tas a = new tas();
                    a.key = index.ToString();
                    index++;
                    if (i == 1)
                    { //kırmızı renkliler

                        a.ismi = "K";
                        a.sayi = j;
                        taslar.Add(a);
                    }
                    else if (i == 2)
                    { //mavi renkliler

                        a.ismi = "M";
                        a.sayi = j;
                        taslar.Add(a);
                    }
                    else if (i == 3)
                    { //siyah renkliler

                        a.ismi = "S";
                        a.sayi = j;
                        taslar.Add(a);
                    }
                    else if (i == 4)
                    { //kırmızı renkliler

                        a.ismi = "Y";
                        a.sayi = j;
                        taslar.Add(a);
                    }
                }
            }

        }
        Random r = new Random();
       

        private void Form1_Load(object sender, EventArgs e)
        {
            tahtalar();

            //bb = panelimm;

            taslar.Clear();
            listBox1.Items.Clear();
            listBox2.Items.Clear();
           // benimTaslarim.Clear();
            benimDizilmisTaslarim.Clear();
            rakipTaslari.Clear();
            rakipDizilmisTaslar.Clear();
            attigimTaslar.Clear();
            lbAtilan.Tag = null;
            lbAtilan.Text = "";

            //MessageBox.Show(panelimm.Controls.Count.ToString());


            foreach (Label item in panelimm.Controls)
            {
                item.Text = "";
                item.Tag = null;
            }
            foreach (Label item in panelRakip.Controls)
            {
                item.Text = "";
                item.Tag = null;
            }
            taslari_olustur();
            taslari_olustur();
           

            tas_dagit(panelimm, 13);
            tas_dagit(panelRakip, 12);


            //taslari_dagit();

            ortayaEkle();
            //rakipTaslariniEkle();


            timer1.Enabled = true;

        }

        private void button2_Click(object sender, EventArgs e)
        {
           // MessageBox.Show(benimTaslarim.Count.ToString());
           // taslari_duzenle(rakip, benimDizilmisTaslarim);


        }

        

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (ortadakiTaslar.Count > 0)
                label1.Text ="ortadaki taş sayısı :" +ortadakiTaslar.Count.ToString();
            else MessageBox.Show("tas bitti");
            label2.Text = "oyundaki toplam tas :"+(taslar.Count+benimTaslarim.Count+ortadakiTaslar.Count+rakipTaslari.Count).ToString();

            if (!sirabende)
                pictureBox1.Location = new Point(24,64);
            else if (sirabende)
                pictureBox1.Location = new Point(24, 309);

            if (ortadakiTaslar.Count > 0)
            {
                tas sondaki = ortadakiTaslar[ortadakiTaslar.Count - 1];

                lbOrtadaki.Tag = sondaki.key;

                lbOrtadaki.Text = sondaki.sayi.ToString();
                if (sondaki.ismi == "K")
                    lbOrtadaki.ForeColor = Color.Red;
                if (sondaki.ismi == "Y")
                    lbOrtadaki.ForeColor = Color.DarkGreen;
                if (sondaki.ismi == "M")
                    lbOrtadaki.ForeColor = Color.Blue;
                if (sondaki.ismi == "S")
                    lbOrtadaki.ForeColor = Color.Black;
            }
            label36.Text = "0";
            label37.Text = "0";
            label38.Text = "0";
            label39.Text = "0";

           
            foreach (Label item in panelimm.Controls)
            {
                etrafindakilereBak(item);
                etrafindakilereBak2(item);
            }


        }

        public void label13_DragDrop(object sender, DragEventArgs e)
        {
            //MessageBox.Show("geldi");
            Label a = (Label)sender;
           
            bool benim = false;
            bool rakibinAttigi = false;
            Label numara = (Label)e.Data.GetData(typeof(Label));
            //MessageBox.Show(numara.Text);
            //MessageBox.Show(benimTaslarim.Count.ToString());
            foreach (tas item in benimTaslarim)
            {

                if (item.key == numara.Tag.ToString())
                {
                    benim = true;
                }
            }
            foreach (tas item in rakibinAttigiTaslar)
            {
                if (item.key == numara.Tag.ToString())
                {
                    rakibinAttigi = true;
                    //MessageBox.Show("aa");

                }
            }
            //MessageBox.Show(a.Text.ToString());
            if (a.Text == "" && benim == false)
            {
                // TAŞ ÇEK
                //MessageBox.Show(a.BackColor.ToString());
                if (benimTaslarim.Count<=12)
                    for (int i = 0; i < ortadakiTaslar.Count; i++)
                {
                        //MessageBox.Show("as");
                        if (ortadakiTaslar[i].key == numara.Tag.ToString())
                    {
                           // MessageBox.Show("sa");
                            a.Text = ortadakiTaslar[i].sayi.ToString();
                        a.BackColor = Color.White;
                        a.Tag = ortadakiTaslar[i].key;
                        benimTaslarim.Add(ortadakiTaslar[i]);

                        if (ortadakiTaslar[i].ismi == "K")
                            a.ForeColor = Color.Red;
                        if (ortadakiTaslar[i].ismi == "Y")
                            a.ForeColor = Color.DarkGreen;
                        if (ortadakiTaslar[i].ismi == "M")
                            a.ForeColor = Color.Blue;
                        if (ortadakiTaslar[i].ismi == "S")
                            a.ForeColor = Color.Black;

                        ortadakiTaslar.Remove(ortadakiTaslar[i]);

                    }
                }

                
                    
            }
            if (a.Text == "" && rakibinAttigi == true)
            {
                if (benimTaslarim.Count <= 12 && sirabende)
                    for (int i = 0; i < rakibinAttigiTaslar.Count; i++)
                {

                    if (rakibinAttigiTaslar[i].key == numara.Tag)
                    {
                        a.Text = rakibinAttigiTaslar[i].sayi.ToString();
                        a.BackColor = Color.White;
                        a.Tag = rakibinAttigiTaslar[i].key;
                        benimTaslarim.Add(rakibinAttigiTaslar[i]);

                        if (rakibinAttigiTaslar[i].ismi == "K")
                            a.ForeColor = Color.Red;
                        if (rakibinAttigiTaslar[i].ismi == "Y")
                            a.ForeColor = Color.DarkGreen;
                        if (rakibinAttigiTaslar[i].ismi == "M")
                            a.ForeColor = Color.Blue;
                        if (rakibinAttigiTaslar[i].ismi == "S")
                            a.ForeColor = Color.Black;

                        rakibinAttigiTaslar.Remove(rakibinAttigiTaslar[i]);
                        lbGelen.Text = "";
                        lbGelen.Tag = null;

                    }
                }

            }
            else if (a.Text == "" && benim == true)
            {
                Label numara2 = (Label)e.Data.GetData(typeof(Label));
                for (int i = 0; i < benimTaslarim.Count; i++)
                {

                    if (benimTaslarim[i].key == numara.Tag)
                    {
                        a.Text = benimTaslarim[i].sayi.ToString();
                        a.BackColor = Color.White;
                        a.Tag = benimTaslarim[i].key;
                        benimTaslarim.Add(benimTaslarim[i]);

                        if (benimTaslarim[i].ismi == "K")
                            a.ForeColor = Color.Red;
                        if (benimTaslarim[i].ismi == "Y")
                            a.ForeColor = Color.DarkGreen;
                        if (benimTaslarim[i].ismi == "M")
                            a.ForeColor = Color.Blue;
                        if (benimTaslarim[i].ismi == "S")
                            a.ForeColor = Color.Black;

                        benimTaslarim.Remove(benimTaslarim[i]);
                        //MessageBox.Show(numara2.Tag.ToString());
                        numara2.Text = "";
                        numara2.BackColor = Color.LightGray;
                        numara2.Tag = null;
                    }
                }
            }
        }


        public void label13_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
            //MessageBox.Show("aa");
        }

        void etrafindakilereBak(Label a)
        {
            foreach (Label item in panelimm.Controls)
            {
                if (a.Location.X + 25 == item.Location.X && item.Tag != null && a.Tag != null && item.Location.Y == a.Location.Y
                    && a.ForeColor != item.ForeColor)
                {
                    foreach (Label item2 in panelimm.Controls)
                    {
                        if (item2.Tag != null && item.Location.X + 25 == item2.Location.X && item2.ForeColor != item.ForeColor && item.Location.Y == item2.Location.Y)
                        {
                            if (a.Text == item.Text && item.Text == item2.Text)
                            {
                                //panelimm.TabIndex()
                                // MessageBox.Show("oley");
                                label36.Text = "1";

                                //*************************
                                ikinciKontrol(a, item);
                                //break;
                            }
                        }
                    }

                }
            }



        }

        void ikinciKontrol(Label a, Label item)
        {
            foreach (Label item4 in panelimm.Controls)
            {
                if (item4.Location.X != a.Location.X && item4.Location != item.Location)

                    foreach (Label item3 in panelimm.Controls)
                    {

                        if (item4.Location.X + 25 == item3.Location.X && item3.Tag != null && item4.Tag != null && item3.Location.Y == item4.Location.Y
                            && item4.ForeColor != item3.ForeColor)
                        {
                            foreach (Label item5 in panelimm.Controls)
                            {
                                if (item5.Tag != null && item3.Location.X + 25 == item5.Location.X && item5.ForeColor != item3.ForeColor && item3.Location.Y == item5.Location.Y)
                                {
                                    if (item4.Text == item3.Text && item3.Text == item5.Text)
                                    {
                                        //panelimm.TabIndex()
                                        // MessageBox.Show("oley");
                                        label37.Text = "1";
                                        //break;
                                    }
                                }
                            }

                        }
                    }
            }
        }

        void etrafindakilereBak2(Label a)
        {
            foreach (Label item in panelimm.Controls)
            {
                if (a.Location.X + 25 == item.Location.X && item.Tag != null && a.Tag != null && item.Location.Y == a.Location.Y
                    && a.ForeColor == item.ForeColor)
                {
                    foreach (Label item2 in panelimm.Controls)
                    {
                        if (item2.Tag != null && item.Location.X + 25 == item2.Location.X && item2.ForeColor == item.ForeColor && item.Location.Y == item2.Location.Y)
                        {
                            if (Math.Abs(Convert.ToInt32(a.Text) - Convert.ToInt32(item.Text))==1 && Math.Abs(Convert.ToInt32(item.Text) - Convert.ToInt32(item2.Text))==1)
                            {
                                //panelimm.TabIndex()
                                // MessageBox.Show("oley");
                                label38.Text = "1";

                                //*************************
                                ikinciKontrol2(a, item);
                                //break;
                            }
                        }
                    }

                }
            }
        }
        void ikinciKontrol2(Label a, Label item)
        {
            foreach (Label item4 in panelimm.Controls)
            {
                if (item4.Location.X != a.Location.X && item4.Location != item.Location)

                    foreach (Label item3 in panelimm.Controls)
                    {
                        if (item3.Location.X != a.Location.X && item3.Location != item.Location)
                            if (item4.Location.X + 25 == item3.Location.X && item3.Tag != null && item4.Tag != null && item3.Location.Y == item4.Location.Y
                            && item4.ForeColor == item3.ForeColor)
                        {
                            foreach (Label item5 in panelimm.Controls)
                            {
                                if (item5.Tag != null && item3.Location.X + 25 == item5.Location.X && item5.ForeColor == item3.ForeColor && item3.Location.Y == item5.Location.Y)
                                {
                                    if (Math.Abs(Convert.ToInt32(item4.Text) - Convert.ToInt32(item3.Text))==1 && Math.Abs(Convert.ToInt32(item3.Text) - Convert.ToInt32(item5.Text))==1)
                                    {
                                        //if (Convert.ToInt32(a.Text) - Convert.ToInt32(item.Text) == 1 && Convert.ToInt32(item.Text) - Convert.ToInt32(item2.Text) == 1)
                                            //panelimm.TabIndex()
                                            // MessageBox.Show("oley");
                                            label39.Text = "1";
                                        //break;
                                    }
                                }
                            }

                        }
                    }
            }
        }

        public void label13_DoubleClick(object sender, EventArgs e)
        {
           // MessageBox.Show("aassadfa");
            if (sirabende)
            {
                Label gelen = (Label)sender;
                tas a = new tas();
               // tas.sayi = Convert.ToInt32(gelen.Text);
                //if (gelen.ForeColor == Color.DarkGreen)
                //{
                //    tas.ismi = "Y";
                //}
                for (int i = 0; i < benimTaslarim.Count; i++)

                {
                    if (gelen.Tag !=null&& benimTaslarim[i].key == gelen.Tag.ToString())
                    {
                        a = benimTaslarim[i];
                        benimTaslarim.Remove(a);
                        attigimTaslar.Add(a);
                      
                            
                        //panelimm.Controls.Remove(gelen);
                        lbAtilan.Text = a.sayi.ToString() ;
                        lbAtilan.ForeColor = gelen.ForeColor;

                        gelen.Text = "";
                        gelen.BackColor = Color.LightGray;
                        gelen.Tag = null;
                        gelen.ForeColor = Color.LightGreen;
                        break;
                    }
                }


                sirabende = false;
            }
        }

        public void rakipOynuyor()
        {
            tas a = new tas();
            a = attigimTaslar[attigimTaslar.Count - 1];
            attigimTaslar.Remove(attigimTaslar[attigimTaslar.Count - 1]);
            lbAtilan.Tag = null;
            lbAtilan.Text = "";


            for (int i = 0; i < panelRakip.Controls.Count; i++)

            {
                int rastgele = r.Next(0, panelRakip.Controls.Count);
                Label item = (Label)panelRakip.Controls[rastgele];
                if (item.Tag == null)
                {
                    item.Tag = a.key;
                    item.Text = a.sayi.ToString();
                    if (a.ismi == "K")
                        item.ForeColor = Color.Red;
                    if (a.ismi == "M")
                        item.ForeColor = Color.Blue;
                    if (a.ismi == "Y")
                        item.ForeColor = Color.DarkGreen;
                    if (a.ismi == "S")
                        item.ForeColor = Color.Black;
                    item.BackColor = Color.White;
                    break;
                }
            }
            //lbGelen.Click += LbOrtadaki_Click;
            for (int i = 0; i < panelRakip.Controls.Count; i++)
            
            {
                int rastgele=r.Next(0, panelRakip.Controls.Count);
                Label item = (Label)panelRakip.Controls[rastgele];
                if (item.Tag != null)
                {
                    tas g = new tas();
                    g.key = item.Tag.ToString();
                    g.sayi = Convert.ToInt32(item.Text);
                    item.Tag = null;
                    if (item.ForeColor == Color.Red)
                    {
                        g.ismi = "K";

                    }
                    if (item.ForeColor == Color.Black)
                    {
                        g.ismi = "S";
                    }
                    if (item.ForeColor == Color.DarkGreen)
                    {
                        g.ismi = "Y";
                    }
                    if (item.ForeColor == Color.Blue)
                    {
                        g.ismi = "M";
                    }
                    lbGelen.Text = g.sayi.ToString();
                    lbGelen.ForeColor = item.ForeColor;
                    lbGelen.Tag = g.key;
                    rakibinAttigiTaslar.Add(g);
                    item.Text = "";
                    item.BackColor = Color.LightGray;

                    break;
                }
                else continue;
            }

                   
            sirabende = true;
        }

        private void timerRakip_Tick(object sender, EventArgs e)
        {
            if (!sirabende)
            {
                if (label36.Text == "1" && label37.Text == "1" && label38.Text == "1" && label39.Text == "1")
                {
                    MessageBox.Show("Tebrikler Kazandınız!");
                    timerRakip.Enabled = false;
                }
                //MessageBox.Show("sirasende");
                rakipOynuyor();

            }
        }

        private void panelimm_Paint(object sender, PaintEventArgs e)
        {

        }

        public void button3_Click(object sender, EventArgs e)
        {
            tahta a = new tahta();
            a.Location = new Point(2, 3);
            //foreach (Label item in a.Controls)
            //{
            //   // item.DoubleClick+=label13_DoubleClick;
            //    //item.DragEnter-=valueType;
            //    item.DragEnter += label13_DragEnter;
            //}
            this.Controls.Add(a);
             //MessageBox.Show("eklendi");
          
        }


        public void tahtalar()
        {
            //tahta t = new tahta();
            //List<Label> dizia = t.elemanlar();
            //panelimmm.Size = t.Size;
            //panelimmm.BackColor = t.BackColor;
            //foreach (Label item in t.Controls)
            //{
            //    if(item!=null)
            //    panelimmm.Controls.Add(item);

            //}
          
           
           
        }
    }
}
