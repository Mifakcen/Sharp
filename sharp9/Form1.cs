using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace sharp9
{
    public partial class Form1 : Form
    {
        BinaryFormatter formatter = new BinaryFormatter();
        public Form1()
        {
            InitializeComponent();
        }

        Avto[] MD = new Avto[1000];
        int amountel;
        static List<Mashin> list = new List<Mashin>();
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

            using (FileStream fs = new FileStream("C:\\Users\\Mifa\\Desktop\\people.dat", FileMode.OpenOrCreate))
            {
                List<Mashin> deserilizeMashin = (List<Mashin>)formatter.Deserialize(fs);

                foreach(Mashin mashin in deserilizeMashin)
                {
                    list.Add(mashin);
                    comboBox1.Items.Add(mashin.Num);
                }
            };

        }

        public enum Numbers
        {

        }
        public enum Color
        {
            Неопределенный, Белый, Красный, Фиолетовый, Серый, Зелёный, Синий, Оранжевый, Желтый, Голубой

        }                       
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
        [Serializable]
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
      //  [Serializable]
       
        private Mashin поиск(String str)
        {
            foreach (Mashin mashin in list)
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
                    string str = comboBox1.Text;
                    button3_Click(sender, e);
                    textBox1.Text = str;
                }
                groupBox1.Visible = true;
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
            Mashin mashin = поиск(textBox1.Text);
            if (mashin == null)
            {
                MD[amountel].Update(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);

                amountel++;
                comboBox1.Items.Add(textBox1.Text);

               

                using (FileStream fs = new FileStream("C:\\Users\\Mifa\\Desktop\\people.dat", FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, list);
                };
            }
            else
            {
                mashin.Num = textBox1.Text;
                mashin.Model = textBox2.Text;

                mashin.Color = textBox3.Text;
                mashin.FIO = textBox4.Text;
            }
            button3_Click(sender, e);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = comboBox1.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Mashin mashin = поиск(textBox1.Text);
            if (mashin != null)
            {
                list.Remove(mashin);
                comboBox1.Items.Remove(textBox1.Text);
                button3_Click(sender, e);
            }
        }

    }
}
