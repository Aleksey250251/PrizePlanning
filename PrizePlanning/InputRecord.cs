using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrizePlanning
{
    public partial class InputRecord : UserControl
    {
        AddRecord add;
        public InputRecord()
        {
            InitializeComponent();
        }

        public void Load(AddRecord add)
        {
            this.add = add;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.SendToBack();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            numericUpDown1.Value = 0;
            radioButton1.Checked = radioButton2.Checked = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && numericUpDown1.Value != 0)
            {
                if (radioButton1.Checked)
                {
                    MainPrizeForm.countRecords++;
                    add(MainPrizeForm.countRecords, textBox1.Text, textBox2.Text, textBox3.Text, numericUpDown1.Value.ToString(),
                        radioButton1.Text);
                    this.SendToBack();

                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    numericUpDown1.Value = 0;
                    radioButton1.Checked = radioButton2.Checked = false;
                }
                else 
                if(radioButton2.Checked)
                {
                    MainPrizeForm.countRecords++;
                    add(MainPrizeForm.countRecords, textBox1.Text, textBox2.Text, textBox3.Text, numericUpDown1.Value.ToString(),
                        radioButton2.Text);
                    this.SendToBack();

                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    numericUpDown1.Value = 0;
                    radioButton1.Checked = radioButton2.Checked = false;
                }

            }
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && numericUpDown1.Value > 0)
            {
                toolTip1.Active = false;
}
            else
            {
                toolTip1.Active = true;
            }
        }
    }
}
