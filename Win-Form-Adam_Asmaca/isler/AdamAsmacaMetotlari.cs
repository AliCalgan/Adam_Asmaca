﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Win_Form_Adam_Asmaca.isler
{
    public class AdamAsmacaMetotlari
    {

        public static string[] Sehirler { get; } = SehirleriYukle();

        private static string secilenSehir;
        public static string EkranMetni { get; set; }

        public static string SecilenSehir
        {
            get { return secilenSehir; }
            private set { secilenSehir = value.ToUpper(); }
        }
        public static string[] SehirleriYukle()
        {
            return  new string[] { "Adana", "Adıyaman", "Afyon", "Ağrı", "Amasya", "Ankara", "Antalya", "Artvin", "Aydın", "Balıkesir", "Bilecik", "Bingöl", "Bitlis", "Bolu", "Burdur", "Bursa", "Çanakkale", "Çankırı", "Çorum", "Denizli", "Diyarbakır", "Edirne", "Elazığ", "Erzincan", "Erzurum", "Eskişehir", "Gaziantep", "Giresun", "Gümüşhane", "Hakkari", "Hatay", "Isparta", "Mersin", "İstanbul", "İzmir", "Kars", "Kastamonu", "Kayseri", "Kırklareli", "Kırşehir", "Kocaeli", "Konya", "Kütahya", "Malatya", "Manisa", "Kahramanmaraş", "Mardin", "Muğla", "Muş", "Nevşehir", "Niğde", "Ordu", "Rize", "Sakarya", "Samsun", "Siirt", "Sinop", "Sivas", "Tekirdağ", "Tokat", "Trabzon", "Tunceli", "Şanlıurfa", "Uşak", "Van", "Yozgat", "Zonguldak", "Aksaray", "Bayburt", "Karaman", "Kırıkkale", "Batman", "Şırnak", "Bartın", "Ardahan", "Iğdır", "Yalova", "Karabük", "Kilis", "Osmaniye", "Düzce" };

        }

        public static void RastgeleSehirSec()
        {
            Random rnd = new Random();
            SecilenSehir = Sehirler[rnd.Next(0, 81)];
            EkranMetni = Sifrele(secilenSehir);
            
        }
        public static string Sifrele(string metin)
        {
            string sifreliMetin = "";
            for (int i = 0; i < metin.Length; i++)          
                sifreliMetin += "_";          
            return sifreliMetin;
        }

        public static string ArayaBoslukEkle(string metin)
        {
            string boslukluMetin = "";
            for (int i = 0; i < metin.Length; i++)            
                boslukluMetin += metin[i] + " " ;           
           return boslukluMetin;

        }

        public  static Button[] GetirHarfButonlari()
        {
            char[] charHarfler = new char[] { 'A', 'B', 'C', 'Ç', 'D', 'E', 'F', 'G', 'Ğ', 'H', 'I', 'İ', 'J', 'K', 'L', 'M', 'N', 'O', 'Ö', 'P', 'R', 'S', 'Ş', 'T', 'U', 'Ü', 'V', 'Y', 'Z' };

            Button[] btnHarfler = new Button[charHarfler.Length];
            int xkoor = 10 , ykoor = 100 ;
            for (int i = 0; i < charHarfler.Length; i++)
            {
                btnHarfler[i] = new Button();
                btnHarfler[i].Text = charHarfler[i].ToString();
                btnHarfler[i].Size = new Size(35,35);
                btnHarfler[i].Location =new Point(xkoor, ykoor);
                btnHarfler[i].FlatStyle= FlatStyle.Flat;
                btnHarfler[i].FlatAppearance.BorderColor = Color.Black;
                btnHarfler[i].FlatAppearance.BorderSize = 2;
                xkoor += btnHarfler[i].Width + 5;
                if ((i+1)%10 == 0)
                {
                    xkoor = 10;
                    ykoor += btnHarfler[i].Width+ 5;
                }
              

            }
            return btnHarfler;
        }
       

    }
}
