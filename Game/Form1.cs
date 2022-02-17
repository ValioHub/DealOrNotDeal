using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public partial class Form1 : Form
    {
        double[] money = new double[21] { 0.10, 0.20, 0.50, 1, 10, 20, 50, 100, 200, 300, 750, 1000, 2500, 5000, 7500, 10000, 12500, 15000, 25000, 50000, 100000 };
        double[] offerGen = new double[21] { 0.10, 0.20, 0.50, 1, 10, 20, 50, 100, 200, 300, 750, 1000, 2500, 5000, 7500, 10000, 12500, 15000, 25000, 50000, 100000 };
        double[] buttonList = new double[21];
        int[] tempList = new int[21];
        Random random = new Random();
        bool[] buttonFlag = new bool[21];
        double newOffer;
        bool accept = false;
        int offerCounter = 0;
        int offerRemainder;
        string tempLabel;
        double finalValue;
        private bool IsUsed(int temp)
        {
            bool flag = false;

            for (int i = 0; i < 21; i++)
            {
                if (tempList[i] == temp)
                {
                    flag = true;
                }

            }
            return flag;
        }
        private void LostValues(string tempLabel)
        {
            if (textBox1.Text.ToString() == tempLabel)
            {
                textBox1.Visible = false;
            }
            if (textBox2.Text.ToString() == tempLabel)
            {
                textBox2.Visible = false;
            }
            if (textBox3.Text.ToString() == tempLabel)
            {
                textBox3.Visible = false;
            }
            if (textBox4.Text.ToString() == tempLabel)
            {
                textBox4.Visible = false;
            }
            if (textBox5.Text.ToString() == tempLabel)
            {
                textBox5.Visible = false;
            }
            if (textBox6.Text.ToString() == tempLabel)
            {
                textBox6.Visible = false;
            }
            if (textBox7.Text.ToString() == tempLabel)
            {
                textBox7.Visible = false;
            }
            if (textBox8.Text.ToString() == tempLabel)
            {
                textBox8.Visible = false;
            }
            if (textBox9.Text.ToString() == tempLabel)
            {
                textBox9.Visible = false;
            }
            if (textBox10.Text.ToString() == tempLabel)
            {
                textBox10.Visible = false;
            }
            if (textBox11.Text.ToString() == tempLabel)
            {
                textBox11.Visible = false;
            }
            if (textBox12.Text.ToString() == tempLabel)
            {
                textBox12.Visible = false;
            }
            if (textBox13.Text.ToString() == tempLabel)
            {
                textBox13.Visible = false;
            }
            if (textBox14.Text.ToString() == tempLabel)
            {
                textBox14.Visible = false;
            }
            if (textBox15.Text.ToString() == tempLabel)
            {
                textBox15.Visible = false;
            }
            if (textBox16.Text.ToString() == tempLabel)
            {
                textBox16.Visible = false;
            }
            if (textBox17.Text.ToString() == tempLabel)
            {
                textBox17.Visible = false;
            }
            if (textBox18.Text.ToString() == tempLabel)
            {
                textBox18.Visible = false;
            }
            if (textBox19.Text.ToString() == tempLabel)
            {
                textBox19.Visible = false;
            }
            if (textBox20.Text.ToString() == tempLabel)
            {
                textBox20.Visible = false;
            }
            if (textBox21.Text.ToString() == tempLabel)
            {
                textBox21.Visible = false;
            }
            if (textBox22.Text.ToString() == tempLabel)
            {
                textBox22.Visible = false;
            }
        }
        private void GenerateNewOffer()
        {
            double sum = 0;
            double avg;

            for (int i = 0; i < 21; i++)
            {
                sum += offerGen[i];

            }
            avg = sum / (21 - offerCounter);
            newOffer = avg;

        }
        //private void CallZero(string tempLabel)
        //{
        //    long val = Convert.ToInt64(tempLabel);
        //    for (int i = 0; i < 21; i++)
        //    {
        //        if (offerGen[i] == val)
        //        {
        //            offerGen[i] = 0;
        //        }
        //    }
        //}
        private double GetFinalValue()
        {
            for (int i = 0; i < 21; i++)
            {
                if (offerGen[i] != 0)
                {
                    finalValue = offerGen[i];
                }
            }

            return finalValue;
        }

        public Form1()
        {
            int temp;
            for (int i = 0; i < 21; i++)
            {
                buttonFlag[i] = false;
            }
            for (int i = 0; i < 21; i++)
            {
                tempList[i] = 30;
            }
            for (int i = 0; i < 21; i++)
            {
                temp = random.Next(21);
                while (IsUsed(temp))
                {
                    temp = random.Next(21);
                }
                buttonList[i] = money[temp];
                tempList[i] = temp;
            }
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (buttonFlag[0])
            {
                return;
            }
            buttonFlag[0] = true;
            if (accept)
            {
                return;
            }
            offerCounter++;
            tempLabel = buttonList[0].ToString();
            LostValues(tempLabel);
            MessageBox.Show($"Отворихте {tempLabel}", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            button1.Visible = false;
            if (offerCounter == 20)
            {
                finalValue = GetFinalValue();
                MessageBox.Show("Game is over.You won " + finalValue.ToString());
                accept = true;
            }

            if (offerCounter <= 18)
            {
                if ((offerCounter % 3) == 0)
                {
                    GenerateNewOffer();
                    DialogResult dialogResult = MessageBox.Show($"Имате нова оферта и тя е {newOffer}!","Банкера предлага", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (dialogResult == DialogResult.Yes)
                    {
                        MessageBox.Show("Game is over.You won " + finalValue.ToString());
                    }
                }
                else
                {
                    offerRemainder = 3 - (offerCounter % 3);
                    MessageBox.Show($"Отворете още {offerRemainder}");
                }
            }
            else textBox2.Text = "";
        }
        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {

        }

       
    }
}
