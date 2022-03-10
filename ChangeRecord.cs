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
    public partial class ChangeRecord : UserControl
    {
        ChooseRecordDelegate choose;
        public static int IDforChange;
        public ChangeRecord()
        {
            InitializeComponent();
        }

        public void Load(ChooseRecordDelegate choose)
        {
            this.choose = choose;
        }
        public void LoadData(string fam, string name, string otch, int age, string gender)
        {
            textBox1.Text = fam;
            textBox2.Text = name;
            textBox3.Text = otch;
            numericUpDown1.Value = age;
            if (gender == "М")
                radioButton1.Checked = true;
            else radioButton2.Checked = true;
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && numericUpDown1.Value != 0)
            {
                if (radioButton1.Checked)
                {
                    choose(ChangeRecord.IDforChange, textBox1.Text, textBox2.Text, textBox3.Text, numericUpDown1.Value.ToString(),
                        radioButton1.Text);
                    this.SendToBack();

                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    numericUpDown1.Value = 0;
                    radioButton1.Checked = radioButton2.Checked = false;
                }
                else
                if (radioButton2.Checked)
                {
                    choose(ChangeRecord.IDforChange, textBox1.Text, textBox2.Text, textBox3.Text, numericUpDown1.Value.ToString(),
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

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.SendToBack();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            numericUpDown1.Value = 0;
            radioButton1.Checked = radioButton2.Checked = false;
        }

        private void button1_MouseEnter_1(object sender, EventArgs e)
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
