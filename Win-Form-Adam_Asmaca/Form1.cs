using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Win_Form_Adam_Asmaca.isler;

namespace Win_Form_Adam_Asmaca
{
    public partial class Form1 : Form
    {

        public Bitmap[] Resimler { get; }
        public Button[] Butonlar { get; } = AdamAsmacaMetotlari.GetirHarfButonlari();
        public byte Hak { get; set; } = 7;
        public float Puan { get; set; } = 100;
        public Form1()
        {
            InitializeComponent();

            YeniOyun();
            
            this.Controls.AddRange(Butonlar);
            lblSehir.Text = AdamAsmacaMetotlari.ArayaBoslukEkle(AdamAsmacaMetotlari.EkranMetni);

            Resimler = new Bitmap[]
            {
              Properties.Resources._8, Properties.Resources._7,
              Properties.Resources._6, Properties.Resources._5,
               Properties.Resources._4, Properties.Resources._3,
                Properties.Resources._2 
            };
        
  
        }
        void YeniOyun()
        {
            AdamAsmacaMetotlari.RastgeleSehirSec();
          
            for (int i = 0; i < Butonlar.Length; i++)
            {
              
                Butonlar[i].BackColor= Color.White;
                Butonlar[i].ForeColor = Color.Black;
                Butonlar[i].Enabled = true;
                Butonlar[i].Click += HarfeBasildiginda;
            }
            lblSehir.Text = AdamAsmacaMetotlari.ArayaBoslukEkle(AdamAsmacaMetotlari.EkranMetni);
            pbResim.Image = null;
            Hak = 7;

        }
        void MesajVer(bool KazanildiMi)
        {
            string metin = KazanildiMi ? "Tebrikler Kazandınız " : "Oyunu Kaybettiniz";
            var cevap = MessageBox.Show($@"{metin}"
                        + $"\nAranan Şehir : {AdamAsmacaMetotlari.SecilenSehir}\n"
                        + $"Puan : {Math.Ceiling(Puan)}"
                        + $"\nDevam Etmek ister misiniz?",
                        "Oyun Durumu",
                         MessageBoxButtons.YesNo,
                         MessageBoxIcon.Question);

            if (cevap == DialogResult.Yes)
            {
                Puan += 100;
                YeniOyun();
            }
            else
            {
               Application.Exit();
            }
        }

        private void HarfeBasildiginda(object sender, EventArgs e)
        {
            var buton = ((Button)sender);
            char basilanHarf = buton.Text[0];
            string secilenSehir = AdamAsmacaMetotlari.SecilenSehir;
            string ekranMetni = AdamAsmacaMetotlari.EkranMetni;
            buton.Enabled = false;
            if (secilenSehir.Contains(basilanHarf.ToString()))
            {
                var dizi = secilenSehir.ToCharArray();
                var diziEkran = ekranMetni.ToCharArray();

                for (int i = 0; i < dizi.Length; i++)
                {
                    if (dizi[i] == basilanHarf)
                    {
                        diziEkran[i] = dizi[i];
                    }
                }
                AdamAsmacaMetotlari.EkranMetni = new string(diziEkran);
                lblSehir.Text = AdamAsmacaMetotlari.ArayaBoslukEkle(new string(diziEkran));

                buton.BackColor = Color.DarkGreen;
                buton.ForeColor = Color.White;
                if ((!AdamAsmacaMetotlari.EkranMetni.Contains("_")) && Hak>0 )
                {
                    MesajVer(true);
                }

            }
            else
            {
                buton.BackColor = Color.Red;
                buton.ForeColor = Color.White;
                Hak--;
                pbResim.Image = Resimler[Hak];
                Puan -= 100f / Resimler.Length;

                if (Hak == 0)
                    MesajVer(false);                          
              
            }

        }









    }
}
