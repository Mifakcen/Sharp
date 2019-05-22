using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sharp9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Avto[] MD = new Avto[1000];
        int amountel;

        private void Form1_Load(object sender, EventArgs e)
        {
            groupBox1.Visible = false;

            amountel = 0;

            for (int i = 0; i < 10; i++)
                comboBox2.Items.Add((Color)i);

            for (int i = 0; i < 1000; i++) 
            {
                MD[i] = new Avto();
            }
            for (int i = 0; i < amountel; i++)
                comboBox1.Items.Add((Numbers)i);
        }
        public enum Numbers
        {

        }
        public enum Color
        {
            Неопределенный, Белый, Красный, Фиолетовый, Серый, Зелёный, Синий, Оранжевый, Желтый, Голубой

        }

       
        public class Mashin 
        {
            public string Num;
            public string Model;
            public string Color;
            public string FIO;
            public Mashin(string num, string model, string color, string fio)
            {
                this.Num = num;
                this.Model = model;
                this.Color = color;
                this.FIO = fio;
            }

           
        }
        static List<Mashin> list = new List<Mashin>();

        public class Avto
        {
            string Num;
            string Model;
            string Color;
            string FIO;

            
            public Avto()
            {
                Num = "";
                Model = "";
                Color = "";
                FIO = "";
            }
            public void Update(string g, string m, string c, string fio)
            {
                Num = g;
                Model = m;
                Color = c;
                FIO = fio;
                list.Add(new Mashin(g, m, c, fio));
            }
            public void transmit(Avto a, int amountel)
            {
                for (int i = 0; i < 1000; i++)
                {
                  
                }
            }
        }

        private Mashin поиск(String str)
        {
            foreach(Mashin mashin in list)
            {
                if (mashin.Num == str)
                {
                    return mashin;
                }
            }
            return null;
        }


        private void ComboBox1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Mashin mashin = поиск(comboBox1.Text);
                if (mashin != null)
                {
                    groupBox1.Visible = true;
                    textBox1.Text = mashin.Num;
                    textBox2.Text = mashin.Model;
                    textBox3.Text = mashin.Color;
                    textBox4.Text = mashin.FIO;

                }
                else
                {
                    MessageBox.Show("Элемент не найден в базе");
                    button3_Click(sender, e);
                }
                groupBox1.Visible = true;
                textBox1.Text = comboBox1.Text;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox3.Text = comboBox2.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboBox1.Text = "";
            groupBox1.Visible = false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MD[amountel].Update(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
       
            amountel++;

            comboBox1.Items.Add(textBox1.Text);

         //   MD[amountel];
         
            button3_Click(sender, e);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = comboBox1.Text;
        }

    }
}
