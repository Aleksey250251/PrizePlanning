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
    public partial class ChoosePrize : UserControl
    {
        DelegateSavePrize savePrize;
        List<PictureBox> pictureBoxesM;
        List<PictureBox> pictureBoxesW;
        List<PictureBox> useBoxes;

        string[] textsM = { "Носки", "Костюм", "Духи","Пиво" };
        string[] textsW = { "Цветы", "Айфон", "Ожерелье","Туфли" };
        string[] useTexts;
        int index=0;

        
        public ChoosePrize()
        {
            InitializeComponent();
            pictureBoxesM = new List<PictureBox>();
            pictureBoxesM.Add(pictureBox1);
            pictureBoxesM.Add(pictureBox2);
            pictureBoxesM.Add(pictureBox3);
            pictureBoxesM.Add(pictureBox4);
            pictureBoxesW = new List<PictureBox>();
            pictureBoxesW.Add(pictureBox5);
            pictureBoxesW.Add(pictureBox6);
            pictureBoxesW.Add(pictureBox7);
            pictureBoxesW.Add(pictureBox8);

        }
        public void Load(string gender,int ID,DelegateSavePrize savePrize)
        {
            this.savePrize = savePrize;
            if(gender=="М")
            {
                useBoxes = pictureBoxesM;
                useTexts = textsM;
            }
            else
            if(gender=="Ж")
            {
                useBoxes = pictureBoxesW;
                useTexts = textsW;
            }

            useBoxes[0].BringToFront();
            label2.Text = useTexts[0];
            index = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            index=(index+1)%4;
            useBoxes[index].BringToFront();
            label2.Text = useTexts[index];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (index == 0)
            {
                index = 3;
            }
            else index--;
            useBoxes[index].BringToFront();
            label2.Text = useTexts[index];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            savePrize(label2.Text, monthCalendar1.SelectionRange.Start.ToShortDateString());
        }
    }
}
