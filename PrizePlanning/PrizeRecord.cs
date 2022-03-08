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
    public partial class PrizeRecord : UserControl
    {
        private ChoosePrize choosePrize;
        public int Id { get { return int.Parse(label6.Text); } set { label6.Text = value.ToString(); } }
        public string Fam { get { return label1.Text; } set { label1.Text = value; } }
        public string Name { get { return label2.Text; } set { label2.Text = value; } }
        public string Otch { get { return label3.Text; } set { label3.Text = value; } }
        public string Date { get { return label4.Text; } set { label4.Text = value; } }
        public string Prize { get{ return label5.Text; } set { label5.Text = value; } }

        public PrizeRecord()
        {
            InitializeComponent();
            this.SetStyle(
                System.Windows.Forms.ControlStyles.UserPaint |
                System.Windows.Forms.ControlStyles.AllPaintingInWmPaint |
                System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer,
                true);
        }

        public void Load(ChoosePrize choosePrize)
        {
            this.choosePrize = choosePrize;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            choosePrize.BringToFront();
        }
    }
}
