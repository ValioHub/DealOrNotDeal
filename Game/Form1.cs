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
        double[] money = new double[22] {0, 0.10, 0.20, 0.50, 1, 10, 20, 50, 100, 200, 300, 750, 1000, 2500, 5000, 7500, 10000, 12500, 15000, 25000, 50000, 100000};
        double[] buttonList = new double[22];
        int[] tempList = new int[22];
        Random random = new Random();
        bool[] buttonFlag = new bool[22];
        double newOffer;
        int offerCounter = 0;
        int offerRemainder;
        string tempLabel;
        double finalValue;
        double all = 229931.8;
        int allBoxex = 22;
        private bool IsUsed(int temp)
        {
            bool flag = false;

            for (int i = 0; i < 22; i++)
            {
                if (tempList[i] == temp)
                {
                    flag = true;
                }
            }
            return flag;
        } // Премахване на button-ите
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
        } // Премахване на label-лите след като се отвори кутия с нейната сума
        private void GenerateNewOffer()
        {
            newOffer = all / allBoxex;
        } // Създаване на офертата на Банкера
        private double GetFinalValue() // Създаване на крайния резултат
        {
            for (int i = 0; i < 22; i++)
            {
                if (buttonFlag[i] == false)
                {
                    finalValue = buttonList[i];
                }
            }
            return finalValue;
        }
        private void OffertGenerate()
        {
            if (offerCounter == 21)
            {
                finalValue = GetFinalValue();
                MessageBox.Show($"Играта приключи. Ти спечели {finalValue} лв");
                Boxes.Visible = false;
                sumi1.Visible = false;
                sumi2.Visible = false;
            }
            if (offerCounter <= 19)
            {
                if ((offerCounter % 3) == 0)
                {
                    GenerateNewOffer();
                    DialogResult dialogResult = MessageBox.Show($"Имате нова оферта и тя е {string.Format("{0:0.00}", newOffer)} лв !", "Банкера предлага", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dialogResult == DialogResult.Yes)
                    {
                        finalValue = newOffer;
                        MessageBox.Show($"Играта приключи. Ти спечели {string.Format("{0:0.00}", newOffer)} лв ");
                        Boxes.Visible = false;
                        sumi1.Visible = false;
                        sumi2.Visible = false;
                    }
                }
                else
                {
                    offerRemainder = 3 - (offerCounter % 3);
                    if (offerRemainder == 1)
                    {
                        MessageBox.Show($"Отворете още {offerRemainder} кутия", "Банкера предлага", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"Отворете още {offerRemainder} кутии", "Банкера предлага", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        } // Обаждането на банкера
        public Form1()
        {
            int temp;
            for (int i = 0; i < 22; i++)
            {
                buttonFlag[i] = false;
            }
            for (int i = 0; i < 22; i++)
            {
                tempList[i] = 30;
            }
            for (int i = 0; i < 22; i++)
            {
                temp = random.Next(22);
                while (IsUsed(temp))
                {
                    temp = random.Next(22);
                }
                buttonList[i] = money[temp];
                tempList[i] = temp;
            }
            InitializeComponent();
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            buttonFlag[0] = true;
            offerCounter++;
            allBoxex--;
            tempLabel = buttonList[0].ToString();
            all -= buttonList[0];
            LostValues(tempLabel);
            MessageBox.Show($"Отворихте {tempLabel} лв! ", "Кутия номер 1 съдържа:", MessageBoxButtons.OK, MessageBoxIcon.Information);
            button1.Visible = false;
            OffertGenerate();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            buttonFlag[1] = true;
            offerCounter++;
            allBoxex--;
            tempLabel = buttonList[1].ToString();
            all -= buttonList[1];
            LostValues(tempLabel);
            MessageBox.Show($"Отворихте {tempLabel} лв", "Кутия номер 2 съдържа:", MessageBoxButtons.OK, MessageBoxIcon.Information);
            button2.Visible = false;
            OffertGenerate();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            buttonFlag[2] = true;
            offerCounter++;
            allBoxex--;
            tempLabel = buttonList[2].ToString();
            all -= buttonList[2];
            LostValues(tempLabel);
            MessageBox.Show($"Отворихте {tempLabel} лв", "Кутия номер 3 съдържа:", MessageBoxButtons.OK, MessageBoxIcon.Information);
            button3.Visible = false;
            OffertGenerate();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            buttonFlag[3] = true;
            offerCounter++;
            allBoxex--;
            tempLabel = buttonList[3].ToString();
            all -= buttonList[3];
            LostValues(tempLabel);
            MessageBox.Show($"Отворихте {tempLabel} лв", "Кутия номер 4 съдържа:", MessageBoxButtons.OK, MessageBoxIcon.Information);
            button4.Visible = false;
            OffertGenerate();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            buttonFlag[4] = true;
            offerCounter++;
            allBoxex--;
            tempLabel = buttonList[4].ToString();
            all -= buttonList[4];
            LostValues(tempLabel);
            MessageBox.Show($"Отворихте {tempLabel} лв", "Кутия номер 5 съдържа:", MessageBoxButtons.OK, MessageBoxIcon.Information);
            button5.Visible = false;
            OffertGenerate();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            buttonFlag[5] = true;
            offerCounter++;
            allBoxex--;
            tempLabel = buttonList[5].ToString();
            all -= buttonList[5];
            LostValues(tempLabel);
            MessageBox.Show($"Отворихте {tempLabel} лв", "Кутия номер 6 съдържа:", MessageBoxButtons.OK, MessageBoxIcon.Information);
            button6.Visible = false;
            OffertGenerate();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            buttonFlag[6] = true;
            offerCounter++;
            allBoxex--;
            tempLabel = buttonList[6].ToString();
            all -= buttonList[6];
            LostValues(tempLabel);
            MessageBox.Show($"Отворихте {tempLabel} лв", "Кутия номер 7 съдържа:", MessageBoxButtons.OK, MessageBoxIcon.Information);
            button7.Visible = false;
            OffertGenerate();
        }
        private void button8_Click(object sender, EventArgs e)
        {
            buttonFlag[7] = true;
            offerCounter++;
            allBoxex--;
            tempLabel = buttonList[7].ToString();
            all -= buttonList[7];
            LostValues(tempLabel);
            MessageBox.Show($"Отворихте {tempLabel} лв", "Кутия номер 8 съдържа:", MessageBoxButtons.OK, MessageBoxIcon.Information);
            button8.Visible = false;
            OffertGenerate();
        }
        private void button9_Click(object sender, EventArgs e)
        {
            buttonFlag[8] = true;
            offerCounter++;
            allBoxex--;
            tempLabel = buttonList[8].ToString();
            all -= buttonList[8];
            LostValues(tempLabel);
            MessageBox.Show($"Отворихте {tempLabel} лв", "Кутия номер 9 съдържа:", MessageBoxButtons.OK, MessageBoxIcon.Information);
            button9.Visible = false;
            OffertGenerate();
        }
        private void button10_Click(object sender, EventArgs e)
        {
            buttonFlag[9] = true;
            offerCounter++;
            allBoxex--;
            tempLabel = buttonList[9].ToString();
            all -= buttonList[9];
            LostValues(tempLabel);
            MessageBox.Show($"Отворихте {tempLabel} лв", "Кутия номер 10 съдържа:", MessageBoxButtons.OK, MessageBoxIcon.Information);
            button10.Visible = false;
            OffertGenerate();
        }
        private void button11_Click(object sender, EventArgs e)
        {
            buttonFlag[10] = true;
            offerCounter++;
            allBoxex--;
            tempLabel = buttonList[10].ToString();
            all -= buttonList[10];
            LostValues(tempLabel);
            MessageBox.Show($"Отворихте {tempLabel} лв", "Кутия номер 11 съдържа:", MessageBoxButtons.OK, MessageBoxIcon.Information);
            button11.Visible = false;
            OffertGenerate();
        }
        private void button12_Click(object sender, EventArgs e)
        {
            buttonFlag[11] = true;
            offerCounter++;
            allBoxex--;
            tempLabel = buttonList[11].ToString();
            all -= buttonList[11];
            LostValues(tempLabel);
            MessageBox.Show($"Отворихте {tempLabel} лв", "Кутия номер 12 съдържа:", MessageBoxButtons.OK, MessageBoxIcon.Information);
            button12.Visible = false;
            OffertGenerate();
        }
        private void button13_Click(object sender, EventArgs e)
        {
            buttonFlag[12] = true;
            offerCounter++;
            allBoxex--;
            tempLabel = buttonList[12].ToString();
            all -= buttonList[12];
            LostValues(tempLabel);
            MessageBox.Show($"Отворихте {tempLabel} лв", "Кутия номер 13 съдържа:", MessageBoxButtons.OK, MessageBoxIcon.Information);
            button13.Visible = false;
            OffertGenerate();
        }
        private void button14_Click(object sender, EventArgs e)
        {
            buttonFlag[13] = true;
            offerCounter++;
            allBoxex--;
            tempLabel = buttonList[13].ToString();
            all -= buttonList[13];
            LostValues(tempLabel);
            MessageBox.Show($"Отворихте {tempLabel} лв", "Кутия номер 14 съдържа:", MessageBoxButtons.OK, MessageBoxIcon.Information);
            button14.Visible = false;
            OffertGenerate();
        }
        private void button15_Click(object sender, EventArgs e)
        {
            buttonFlag[14] = true;
            offerCounter++;
            allBoxex--;
            tempLabel = buttonList[14].ToString();
            all -= buttonList[14];
            LostValues(tempLabel);
            MessageBox.Show($"Отворихте {tempLabel} лв", "Кутия номер 15 съдържа:", MessageBoxButtons.OK, MessageBoxIcon.Information);
            button15.Visible = false;
            OffertGenerate();
        }
        private void button16_Click(object sender, EventArgs e)
        {
            buttonFlag[15] = true;
            offerCounter++;
            allBoxex--;
            tempLabel = buttonList[15].ToString();
            all -= buttonList[15];
            LostValues(tempLabel);
            MessageBox.Show($"Отворихте {tempLabel} лв", "Кутия номер 16 съдържа:", MessageBoxButtons.OK, MessageBoxIcon.Information);
            button16.Visible = false;
            OffertGenerate();
        }
        private void button17_Click(object sender, EventArgs e)
        {
            buttonFlag[16] = true;
            offerCounter++;
            allBoxex--;
            tempLabel = buttonList[16].ToString();
            all -= buttonList[16];
            LostValues(tempLabel);
            MessageBox.Show($"Отворихте {tempLabel} лв", "Кутия номер 17 съдържа:", MessageBoxButtons.OK, MessageBoxIcon.Information);
            button17.Visible = false;
            OffertGenerate();
        }
        private void button18_Click(object sender, EventArgs e)
        {
            buttonFlag[17] = true;
            offerCounter++;
            allBoxex--;
            tempLabel = buttonList[17].ToString();
            all -= buttonList[17];
            LostValues(tempLabel);
            MessageBox.Show($"Отворихте {tempLabel} лв", "Кутия номер 18 съдържа:", MessageBoxButtons.OK, MessageBoxIcon.Information);
            button18.Visible = false;
            OffertGenerate();
        }
        private void button19_Click(object sender, EventArgs e)
        {
            buttonFlag[18] = true;
            offerCounter++;
            allBoxex--;
            tempLabel = buttonList[18].ToString();
            all -= buttonList[18];
            LostValues(tempLabel);
            MessageBox.Show($"Отворихте {tempLabel} лв", "Кутия номер 19 съдържа:", MessageBoxButtons.OK, MessageBoxIcon.Information);
            button19.Visible = false;
            OffertGenerate();
        }
        private void button20_Click(object sender, EventArgs e)
        {
            buttonFlag[19] = true;
            offerCounter++;
            allBoxex--;
            tempLabel = buttonList[19].ToString();
            all -= buttonList[19];
            LostValues(tempLabel);
            MessageBox.Show($"Отворихте {tempLabel} лв", "Кутия номер 20 съдържа:", MessageBoxButtons.OK, MessageBoxIcon.Information);
            button20.Visible = false;
            OffertGenerate();
        }
        private void button21_Click(object sender, EventArgs e)
        {
            buttonFlag[20] = true;
            offerCounter++;
            allBoxex--;
            tempLabel = buttonList[20].ToString();
            all -= buttonList[20];
            LostValues(tempLabel);
            MessageBox.Show($"Отворихте {tempLabel} лв", "Кутия номер 21 съдържа:", MessageBoxButtons.OK, MessageBoxIcon.Information);
            button21.Visible = false;
            OffertGenerate();
        }
        private void button22_Click(object sender, EventArgs e)
        {
            buttonFlag[21] = true;
            offerCounter++;
            allBoxex--;
            tempLabel = buttonList[21].ToString();
            all -= buttonList[21];
            LostValues(tempLabel);
            MessageBox.Show($"Отворихте {tempLabel} лв", "Кутия номер 22 съдържа:", MessageBoxButtons.OK, MessageBoxIcon.Information);
            button22.Visible = false;
            OffertGenerate();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
