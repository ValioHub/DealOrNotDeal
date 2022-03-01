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
        int selectedBox = 0;
        public static string SetValueForText1 = "";
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
                textBox1.BackColor = Color.Red;
            }
            if (textBox2.Text.ToString() == tempLabel)
            {
                textBox2.BackColor = Color.Red;
            }
            if (textBox3.Text.ToString() == tempLabel)
            {
                textBox3.BackColor = Color.Red;
            }
            if (textBox4.Text.ToString() == tempLabel)
            {
                textBox4.BackColor = Color.Red;
            }
            if (textBox5.Text.ToString() == tempLabel)
            {
                textBox5.BackColor = Color.Red;
            }
            if (textBox6.Text.ToString() == tempLabel)
            {
                textBox6.BackColor = Color.Red;
            }
            if (textBox7.Text.ToString() == tempLabel)
            {
                textBox7.BackColor = Color.Red;
            }
            if (textBox8.Text.ToString() == tempLabel)
            {
                textBox8.BackColor = Color.Red;
            }
            if (textBox9.Text.ToString() == tempLabel)
            {
                textBox9.BackColor = Color.Red;
            }
            if (textBox10.Text.ToString() == tempLabel)
            {
                textBox10.BackColor = Color.Red;
            }
            if (textBox11.Text.ToString() == tempLabel)
            {
                textBox11.BackColor = Color.Red;
            }
            if (textBox12.Text.ToString() == tempLabel)
            {
                textBox12.BackColor = Color.Red;
            }
            if (textBox13.Text.ToString() == tempLabel)
            {
                textBox13.BackColor = Color.Red;
            }
            if (textBox14.Text.ToString() == tempLabel)
            {
                textBox14.BackColor = Color.Red;
            }
            if (textBox15.Text.ToString() == tempLabel)
            {
                textBox15.BackColor = Color.Red;
            }
            if (textBox16.Text.ToString() == tempLabel)
            {
                textBox16.BackColor = Color.Red;
            }
            if (textBox17.Text.ToString() == tempLabel)
            {
                textBox17.BackColor = Color.Red;
            }
            if (textBox18.Text.ToString() == tempLabel)
            {
                textBox18.BackColor = Color.Red;
            }
            if (textBox19.Text.ToString() == tempLabel)
            {
                textBox19.BackColor = Color.Red;
            }
            if (textBox20.Text.ToString() == tempLabel)
            {
                textBox20.BackColor = Color.Red;
            }
            if (textBox21.Text.ToString() == tempLabel)
            {
                textBox21.BackColor = Color.Red;
            }
            if (textBox22.Text.ToString() == tempLabel)
            {
                textBox22.BackColor = Color.Red;
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
        private void OffertGenerate() // Обаждането на банкера
        {
            if (offerCounter == 22) // Край на играта
            {
                finalValue = GetFinalValue();
                label2.Text = finalValue.ToString();
                Boxes.Visible = false;
                sumi1.Visible = false;
                sumi2.Visible = false;
            }
            if (offerCounter == 21) // Последен избор
            {
                var indexes = buttonFlag.Select((value, index) => new { value, index }).Where(b => b.value==false).Select(x => x.index).ToList();
                var lastBox = indexes.First(i => i != selectedBox);
                DialogResult dialogResult=MessageBox.Show($"Искате ли да смените кутия {selectedBox +1} с кутия {lastBox +1}", "Последен избор", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    finalValue = GetFinalValue();
                    label2.Text = finalValue.ToString();
                    Boxes.Visible = false;
                    sumi1.Visible = false;
                    sumi2.Visible = false;
                    buttonFlag[selectedBox] = true;
                    selectedBox = lastBox;
                    panel1.Visible = true;
                }
                if (dialogResult == DialogResult.No)
                {
                    finalValue = GetFinalValue();
                    label2.Text = finalValue.ToString();
                    Boxes.Visible = false;
                    sumi1.Visible = false;
                    sumi2.Visible = false;
                    buttonFlag[lastBox] = true;
                    panel1.Visible = true;
                }
            }
            if (offerCounter <= 18)
            {
                if ((offerCounter % 3) == 0)
                {
                    GenerateNewOffer();
                    DialogResult dialogResult = MessageBox.Show($"Имате нова оферта и тя е {string.Format("{0:0.00}", newOffer)} лв !", "Банкера предлага", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        finalValue = newOffer;
                        label2.Text = string.Format("{0:0.00}", finalValue) + "лв";
                        Boxes.Visible = false;
                        sumi1.Visible = false;
                        sumi2.Visible = false;
                        panel1.Visible = true;
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
        } 
        private void Generator() // Генериране на кутийте и техните суми
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
        }
        public Form1()
        {
            Generator();
            InitializeComponent();
            panel1.Visible = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            tempLabel = buttonList[0].ToString();
            if (offerCounter == 0)
            {
                button1.BackColor = Color.Green;
                button1.Enabled = false;
                selectedBox = 0;
                buttonFlag[0] = false;
            }
            else
            {
                button1.BackColor = Color.Red;
                button1.Enabled = false;
                LostValues(tempLabel);
                all -= buttonList[0];
                allBoxex--;
                buttonFlag[0] = true;
                MessageBox.Show($"Отворихте {tempLabel} лв! ", "Кутия номер 1 съдържа:", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            offerCounter++;
            OffertGenerate();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            tempLabel = buttonList[1].ToString();
            if (offerCounter == 0)
            {
                button2.BackColor = Color.Green;
                button2.Enabled = false;
                selectedBox = 1;
                buttonFlag[1] = false;
            }
            else
            {
                button2.BackColor = Color.Red;
                button2.Enabled = false;
                LostValues(tempLabel);
                all -= buttonList[1];
                allBoxex--;
                buttonFlag[1] = true;
                MessageBox.Show($"Отворихте {tempLabel} лв! ", "Кутия номер 2 съдържа:", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            offerCounter++;
            OffertGenerate();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            tempLabel = buttonList[2].ToString();
            if (offerCounter == 0)
            {
                button3.BackColor = Color.Green;
                button3.Enabled = false;
                selectedBox = 2;
                buttonFlag[2] = false;
            }
            else
            {
                button3.BackColor = Color.Red;
                button3.Enabled = false;
                LostValues(tempLabel);
                all -= buttonList[2];
                allBoxex--;
                buttonFlag[2] = true;
                MessageBox.Show($"Отворихте {tempLabel} лв! ", "Кутия номер 3 съдържа:", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            offerCounter++;
            OffertGenerate();

        }
        private void button4_Click(object sender, EventArgs e)
        {
            tempLabel = buttonList[3].ToString();
            if (offerCounter == 0)
            {
                button4.BackColor = Color.Green;
                button4.Enabled = false;
                selectedBox = 3;
                buttonFlag[3] = false;
            }
            else
            {
                button4.BackColor = Color.Red;
                button4.Enabled = false;
                LostValues(tempLabel);
                all -= buttonList[3];
                allBoxex--;
                buttonFlag[3] = true;
                MessageBox.Show($"Отворихте {tempLabel} лв! ", "Кутия номер 4 съдържа:", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            offerCounter++;
            OffertGenerate();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            tempLabel = buttonList[4].ToString();
            if (offerCounter == 0)
            {
                button5.BackColor = Color.Green;
                button5.Enabled = false;
                selectedBox = 4;
                buttonFlag[4] = false;
            }
            else
            {
                button5.BackColor = Color.Red;
                button5.Enabled = false;
                LostValues(tempLabel);
                all -= buttonList[4];
                allBoxex--;
                buttonFlag[4] = true;
                MessageBox.Show($"Отворихте {tempLabel} лв! ", "Кутия номер 5 съдържа:", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            offerCounter++;
            OffertGenerate();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            tempLabel = buttonList[5].ToString();
            if (offerCounter == 0)
            {
                button6.BackColor = Color.Green;
                button6.Enabled = false;
                selectedBox = 5;
                buttonFlag[5] = false;
            }
            else
            {
                button6.BackColor = Color.Red;
                button6.Enabled = false;
                LostValues(tempLabel);
                all -= buttonList[5];
                allBoxex--;
                buttonFlag[5] = true;
                MessageBox.Show($"Отворихте {tempLabel} лв! ", "Кутия номер 6 съдържа:", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            offerCounter++;
            OffertGenerate();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            tempLabel = buttonList[6].ToString();
            if (offerCounter == 0)
            {
                button7.BackColor = Color.Green;
                button7.Enabled = false;
                selectedBox = 6;
                buttonFlag[6] = false;
            }
            else
            {
                button7.BackColor = Color.Red;
                button7.Enabled = false;
                LostValues(tempLabel);
                all -= buttonList[6];
                allBoxex--;
                buttonFlag[6] = true;
                MessageBox.Show($"Отворихте {tempLabel} лв! ", "Кутия номер 7 съдържа:", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            offerCounter++;
            OffertGenerate();
        }
        private void button8_Click(object sender, EventArgs e)
        {
            tempLabel = buttonList[7].ToString();
            if (offerCounter == 0)
            {
                button8.BackColor = Color.Green;
                button8.Enabled = false;
                selectedBox = 7;
                buttonFlag[7] = false;
            }
            else
            {
                button8.BackColor = Color.Red;
                button8.Enabled = false;
                LostValues(tempLabel);
                all -= buttonList[7];
                allBoxex--;
                buttonFlag[7] = true;
                MessageBox.Show($"Отворихте {tempLabel} лв! ", "Кутия номер 8 съдържа:", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            offerCounter++;
            OffertGenerate();
        }
        private void button9_Click(object sender, EventArgs e)
        {
            tempLabel = buttonList[8].ToString();
            if (offerCounter == 0)
            {
                button9.BackColor = Color.Green;
                button9.Enabled = false;
                selectedBox = 8;
                buttonFlag[8] = false;
            }
            else
            {
                button9.BackColor = Color.Red;
                button9.Enabled = false;
                LostValues(tempLabel);
                all -= buttonList[8];
                allBoxex--;
                buttonFlag[8] = true;
                MessageBox.Show($"Отворихте {tempLabel} лв! ", "Кутия номер 9 съдържа:", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            offerCounter++;
            OffertGenerate();
        }
        private void button10_Click(object sender, EventArgs e)
        {
            tempLabel = buttonList[9].ToString();
            if (offerCounter == 0)
            {
                button10.BackColor = Color.Green;
                button10.Enabled = false;
                selectedBox = 9;
                buttonFlag[9] = false;
            }
            else
            {
                button10.BackColor = Color.Red;
                button10.Enabled = false;
                LostValues(tempLabel);
                all -= buttonList[9];
                allBoxex--;
                buttonFlag[9] = true;
                MessageBox.Show($"Отворихте {tempLabel} лв! ", "Кутия номер 10 съдържа:", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            offerCounter++;
            OffertGenerate();
        }
        private void button11_Click(object sender, EventArgs e)
        {
            tempLabel = buttonList[10].ToString();
            if (offerCounter == 0)
            {
                button11.BackColor = Color.Green;
                button11.Enabled = false;
                selectedBox = 10;
                buttonFlag[10] = false;
            }
            else
            {
                button11.BackColor = Color.Red;
                button11.Enabled = false;
                LostValues(tempLabel);
                all -= buttonList[10];
                allBoxex--;
                buttonFlag[10] = true;
                MessageBox.Show($"Отворихте {tempLabel} лв! ", "Кутия номер 11 съдържа:", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            offerCounter++;
            OffertGenerate();
        }
        private void button12_Click(object sender, EventArgs e)
        {
            tempLabel = buttonList[11].ToString();
            if (offerCounter == 0)
            {
                button12.BackColor = Color.Green;
                button12.Enabled = false;
                selectedBox = 11;
                buttonFlag[11] = false;
            }
            else
            {
                button12.BackColor = Color.Red;
                button12.Enabled = false;
                LostValues(tempLabel);
                all -= buttonList[11];
                allBoxex--;
                buttonFlag[11] = true;
                MessageBox.Show($"Отворихте {tempLabel} лв! ", "Кутия номер 12 съдържа:", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            offerCounter++;
            OffertGenerate();
        }
        private void button13_Click(object sender, EventArgs e)
        {
            tempLabel = buttonList[12].ToString();
            if (offerCounter == 0)
            {
                button13.BackColor = Color.Green;
                button13.Enabled = false;
                selectedBox = 12;
                buttonFlag[12] = false;
            }
            else
            {
                button13.BackColor = Color.Red;
                button13.Enabled = false;
                LostValues(tempLabel);
                all -= buttonList[12];
                allBoxex--;
                buttonFlag[12] = true;
                MessageBox.Show($"Отворихте {tempLabel} лв! ", "Кутия номер 13 съдържа:", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            offerCounter++;
            OffertGenerate();
        }
        private void button14_Click(object sender, EventArgs e)
        {
            tempLabel = buttonList[13].ToString();
            if (offerCounter == 0)
            {
                button14.BackColor = Color.Green;
                button14.Enabled = false;
                selectedBox = 13;
                buttonFlag[13] = false;
            }
            else
            {
                button14.BackColor = Color.Red;
                button14.Enabled = false;
                LostValues(tempLabel);
                all -= buttonList[13];
                allBoxex--;
                buttonFlag[13] = true;
                MessageBox.Show($"Отворихте {tempLabel} лв! ", "Кутия номер 14 съдържа:", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            offerCounter++;
            OffertGenerate();
        }
        private void button15_Click(object sender, EventArgs e)
        {
            tempLabel = buttonList[14].ToString();
            if (offerCounter == 0)
            {
                button15.BackColor = Color.Green;
                button15.Enabled = false;
                selectedBox = 14;
                buttonFlag[14] = false;
            }
            else
            {
                button15.BackColor = Color.Red;
                button15.Enabled = false;
                LostValues(tempLabel);
                all -= buttonList[14];
                allBoxex--;
                buttonFlag[14] = true;
                MessageBox.Show($"Отворихте {tempLabel} лв! ", "Кутия номер 15 съдържа:", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            offerCounter++;
            OffertGenerate();
        }
        private void button16_Click(object sender, EventArgs e)
        {
            tempLabel = buttonList[15].ToString();
            if (offerCounter == 0)
            {
                button16.BackColor = Color.Green;
                button16.Enabled = false;
                selectedBox = 15;
                buttonFlag[15] = false;
            }
            else
            {
                button16.BackColor = Color.Red;
                button16.Enabled = false;
                LostValues(tempLabel);
                all -= buttonList[15];
                allBoxex--;
                buttonFlag[15] = true;
                MessageBox.Show($"Отворихте {tempLabel} лв! ", "Кутия номер 16 съдържа:", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            offerCounter++;
            OffertGenerate();
        }
        private void button17_Click(object sender, EventArgs e)
        {
            tempLabel = buttonList[16].ToString();
            if (offerCounter == 0)
            {
                button17.BackColor = Color.Green;
                button17.Enabled = false;
                selectedBox = 16;
                buttonFlag[16] = false;
            }
            else
            {
                button17.BackColor = Color.Red;
                button17.Enabled = false;
                LostValues(tempLabel);
                all -= buttonList[16];
                allBoxex--;
                buttonFlag[16] = true;
                MessageBox.Show($"Отворихте {tempLabel} лв! ", "Кутия номер 17 съдържа:", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            offerCounter++;
            OffertGenerate();
        }
        private void button18_Click(object sender, EventArgs e)
        {
            tempLabel = buttonList[17].ToString();
            if (offerCounter == 0)
            {
                button18.BackColor = Color.Green;
                button18.Enabled = false;
                selectedBox = 17;
                buttonFlag[17] = false;
            }
            else
            {
                button18.BackColor = Color.Red;
                button18.Enabled = false;
                LostValues(tempLabel);
                all -= buttonList[17];
                allBoxex--;
                buttonFlag[17] = true;
                MessageBox.Show($"Отворихте {tempLabel} лв! ", "Кутия номер 18 съдържа:", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            offerCounter++;
            OffertGenerate();
        }
        private void button19_Click(object sender, EventArgs e)
        {
            tempLabel = buttonList[18].ToString();
            if (offerCounter == 0)
            {
                button19.BackColor = Color.Green;
                button19.Enabled = false;
                selectedBox = 18;
                buttonFlag[18] = false;
            }
            else
            {
                button19.BackColor = Color.Red;
                button19.Enabled = false;
                LostValues(tempLabel);
                all -= buttonList[18];
                allBoxex--;
                buttonFlag[18] = true;
                MessageBox.Show($"Отворихте {tempLabel} лв! ", "Кутия номер 19 съдържа:", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            offerCounter++;
            OffertGenerate();
        }
        private void button20_Click(object sender, EventArgs e)
        {
            tempLabel = buttonList[19].ToString();
            if (offerCounter == 0)
            {
                button20.BackColor = Color.Green;
                button20.Enabled = false;
                selectedBox = 19;
                buttonFlag[19] = false;
            }
            else
            {
                button20.BackColor = Color.Red;
                button20.Enabled = false;
                LostValues(tempLabel);
                all -= buttonList[19];
                allBoxex--;
                buttonFlag[19] = true;
                MessageBox.Show($"Отворихте {tempLabel} лв! ", "Кутия номер 20 съдържа:", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            offerCounter++;
            OffertGenerate();
        }
        private void button21_Click(object sender, EventArgs e)
        {
            tempLabel = buttonList[20].ToString();
            if (offerCounter == 0)
            {
                button21.BackColor = Color.Green;
                button21.Enabled = false;
                selectedBox = 20;
                buttonFlag[20] = false;
            }
            else
            {
                button21.BackColor = Color.Red;
                button21.Enabled = false;
                LostValues(tempLabel);
                all -= buttonList[20];
                allBoxex--;
                buttonFlag[20] = true;
                MessageBox.Show($"Отворихте {tempLabel} лв! ", "Кутия номер 21 съдържа:", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            offerCounter++;
            OffertGenerate();
        }
        private void button22_Click(object sender, EventArgs e)
        {
            tempLabel = buttonList[21].ToString();
            if (offerCounter == 0)
            {
                button22.BackColor = Color.Green;
                button22.Enabled = false;
                selectedBox = 21;
                buttonFlag[21] = false;
            }
            else
            {
                button22.BackColor = Color.Red;
                button22.Enabled = false;
                LostValues(tempLabel);
                all -= buttonList[21];
                allBoxex--;
                buttonFlag[21] = true;
                MessageBox.Show($"Отворихте {tempLabel} лв! ", "Кутия номер 22 съдържа:", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            offerCounter++;
            OffertGenerate();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void button24_Click(object sender, EventArgs e) // Рестартиране
        {
            Application.Restart();
        }
        private void button23_Click(object sender, EventArgs e) // Отиване към highscore form
        {
            SetValueForText1 = string.Format("{0:0.00}", finalValue);
            Form2 Save = new Form2();
            Save.ShowDialog();
        }
        private void button25_Click(object sender, EventArgs e) // Затваряне
        {
            Application.Exit();
        }
        private void Info_Click(object sender, EventArgs e) // Отиване към information form
        {
            Form3 Information = new Form3();
            Information.ShowDialog();
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}
