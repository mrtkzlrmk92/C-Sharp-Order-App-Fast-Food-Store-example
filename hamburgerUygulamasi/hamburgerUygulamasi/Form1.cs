using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hamburgerUygulamasi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        double hesap = 0;
        double toplamTutar = 0;
        double[] sayidizisi = new double[10];

        string metin;
        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Hamburger 20₺ ");
            comboBox1.Items.Add("Lahmacun 10₺ ");
            comboBox1.Items.Add("Kebap 30₺ ");
           comboBox1.SelectedIndex=0;
            radioButton1.Checked = true;
            numericUpDown1.Value = 1;
            numericUpDown1.Minimum = 1;

        }

        private void button1_Click(object sender, EventArgs e)
        { //combobox kontrolü
            if (comboBox1.SelectedIndex == 0)
            {
                hesap = 20;
                metin = "Hamburger 20₺ ";
            }
            else if(comboBox1.SelectedIndex == 1)
            {
                metin = "Lahmacun 10₺ ";
                hesap = 10;
            } else if(comboBox1.SelectedIndex == 2)
            {
                hesap = 30;
                metin = "Kebap 30₺ ";
            }


            // radio button kontrolü
            if (radioButton2.Checked == true)
            {
                hesap += 2;
                metin += "Büyük Boy(+2) ";
            }else if (radioButton3.Checked == true)
            {
                hesap += 4;
                metin += "King Boy(+4) ";
            }
            else
            {
                metin += "Orta Boy ";
            }
            //checkbox kontrolü
            int sayac = 0;
            foreach (Control item in groupBox1.Controls)
            { 
                if(item is CheckBox)
                {
                    CheckBox chb = new CheckBox();
                    chb =(CheckBox) item;
                    if (chb.Checked == true)
                    {
                        sayac++;
                        hesap += 0.5;
                    }
                }
            }
            metin += "Ekstralar:" + (sayac*0.5) +"₺ " ;

            hesap *= Convert.ToDouble(numericUpDown1.Value);
            metin += "menü adeti: " + numericUpDown1.Value;
            metin += " Tutar: " + hesap;
          
            for (int i = 0; i < sayidizisi.Length; i++)
            {
                if(sayidizisi[i]== 0)
                {
                    sayidizisi[i] = hesap;
                    break;
                }
            }
            listBox1.Items.Add(metin);
            temizle();

        }
        public void temizle()
        {
            comboBox1.SelectedIndex = 0;
            radioButton1.Checked = true;
            numericUpDown1.Value = 1;
            foreach (Control item in groupBox1.Controls)
            {
                 if(item is CheckBox)
                {
                    CheckBox cb = new CheckBox();
                    cb = (CheckBox)item;
                    cb.Checked = false;
                }

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (double item in sayidizisi)
            {
                toplamTutar += item;
            }
            MessageBox.Show("Tutar:" + toplamTutar, "Hesap",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            toplamTutar = 0;

            listBox1.Items.Clear();
            for (int i = 0; i < sayidizisi.Length; i++)
            {
                sayidizisi[i] = 0;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sayidizisi[listBox1.SelectedIndex]=0;
            listBox1.Items.Remove(listBox1.SelectedItem);
            for (int i = 0; i < sayidizisi.Length-1; i++)
            {
                if(sayidizisi[i]==0 && sayidizisi[i + 1] != 0)
                {
                    sayidizisi[i] = sayidizisi[i + 1];
                    sayidizisi[i + 1] = 0;
                }
            }

        }
    }
}
