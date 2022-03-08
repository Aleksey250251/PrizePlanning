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
    public partial class Prizes : UserControl
    {
        AddRecord addRecord;

        public Prizes()
        {
            InitializeComponent();
        }

        public void Load(AddRecord addRecord)
        {
            this.addRecord = addRecord;
        }

        public void AddRecordOnFlowLayoutPanel(int ID, string fam, string name, string otch, string age, string gender)
        {
            Record record = new Record();
            record.Id = ID;
            record.Fam = fam;
            record.Name = name;
            record.Otch = otch;
            record.Age = age;
            record.Gender = gender;
            record.Location = new System.Drawing.Point(0, 106 * (MainPrizeForm.countRecords - 1));
            myFlowPanel1.Controls.Add(record);
        }
        public void DeleteRecord(int ID)
        {
            myFlowPanel1.Controls.RemoveAt(ID - 1);

            for (int i = 0; i < myFlowPanel1.Controls.Count; i++)
            {
                ((Record)myFlowPanel1.Controls[i]).Id = i + 1;
            }
        }
        public void ChooseRecord(int ID, string fam, string name, string otch, string age, string gender)
        {
            ((Record)myFlowPanel1.Controls[ID - 1]).Fam = fam;
            ((Record)myFlowPanel1.Controls[ID - 1]).Name = name;
            ((Record)myFlowPanel1.Controls[ID - 1]).Otch = otch;
            ((Record)myFlowPanel1.Controls[ID - 1]).Age = age;
            ((Record)myFlowPanel1.Controls[ID - 1]).Gender = gender;
        }
    }
}
