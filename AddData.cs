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
    public partial class AddData : Form
    {
        public AddData()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            PrizePlanning prizePlanning = new PrizePlanning();
            prizePlanning.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            PrizePlanning prizePlanning = new PrizePlanning();
            Record record = new Record();
            record.Fam = maskedTextBox2.Text;
            record.Name = maskedTextBox2.Text;
            record.Otch = maskedTextBox2.Text;
            record.Age = Convert.ToInt32(maskedTextBox2.Text);
            record.Prize = maskedTextBox2.Text;
            record.DatePrize =Convert.ToDateTime(maskedTextBox2.Text);
            record.Fam = maskedTextBox2.Text;
            prizePlanning.Add(record);
            prizePlanning.Show();
        }
    }
}
