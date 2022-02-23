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

namespace Game
{
    struct users
    {
        public string name;
        public double winMoney;
    }
    public partial class Form2 : Form
    {
        private void Save()
        {
            string users = textBox1.Text + " - " + textBox2.Text;
            TextWriter tsw = new StreamWriter(@"..\Highscores.txt", true);
            try
            {
                tsw.WriteLine(users);
                MessageBox.Show($"Играча {textBox1.Text} , е добавен", "Успешно", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                MessageBox.Show($"Yes", "Внимание", MessageBoxButtons.OK);
                tsw.Close();
            }
        } // Запазване на елементи
        private void Sort() // Сортиране на елементи
        {
            listBox1.Items.Clear();
            string[] scores = File.ReadAllLines(@"..\Highscores.txt");
            var orderedScores = scores.OrderByDescending(x => double.Parse(x.Split('-')[1]));
            foreach (var entry in orderedScores)
            {
                Console.WriteLine(entry);
                if (entry != null)
                {
                    listBox1.Items.Add(entry);
                }
            }
        }
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox2.Text = Form1.SetValueForText1;
            Sort();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e) // Добавяне на елемент
        {
            var user = new users();
            if (textBox1.Text == "")
            {
                MessageBox.Show("Моля въведете името на играча", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Да се добави ли?", "Потвърждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    user.name = textBox1.Text;
                    user.winMoney = double.Parse(textBox2.Text);
                    Save();
                    Sort();
                }
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e) // Изтриване на всички елементи
        {
            File.WriteAllText(@"..\Highscores.txt", "");
            listBox1.Items.Clear();
        }

        private void button3_Click(object sender, EventArgs e) // Изтриване на избран елемент
        {
            if (listBox1.SelectedIndex > -1)
            {
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                using (FileStream fs = new FileStream(@"..\Highscores.txt", FileMode.Create, FileAccess.Write))
                {
                    using (TextWriter tw = new StreamWriter(fs))
                        foreach (string item in listBox1.Items)
                            tw.WriteLine(item);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
