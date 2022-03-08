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
        ChoosePrize choosePrize;
        public Prizes()
        {
            InitializeComponent();
        }

        public void Load(AddRecord addRecord,ChoosePrize choosePrize)
        {
            this.addRecord = addRecord;
            this.choosePrize = choosePrize;
        }

        public void AddRecordOnFlowLayoutPanel(int ID, string fam, string name, string otch, string age, string gender)
        {
            PrizeRecord prizeRecord = new PrizeRecord();
            prizeRecord.Id = ID;
            prizeRecord.Fam = fam;
            prizeRecord.Name = name;
            prizeRecord.Otch = otch;
            prizeRecord.Date = "";
            prizeRecord.Prize = "";
            prizeRecord.Load(choosePrize);
            myFlowPanel1.Controls.Add(prizeRecord);
            
        }
        public void DeleteRecord(int ID)
        {
            myFlowPanel1.Controls.RemoveAt(ID - 1);

            for (int i = 0; i < myFlowPanel1.Controls.Count; i++)
            {
                ((PrizeRecord)myFlowPanel1.Controls[i]).Id = i + 1;
            }
        }
        public void ChooseRecord(int ID, string fam, string name, string otch, string age, string gender)
        {
            ((PrizeRecord)myFlowPanel1.Controls[ID - 1]).Fam = fam;
            ((PrizeRecord)myFlowPanel1.Controls[ID - 1]).Name = name;
            ((PrizeRecord)myFlowPanel1.Controls[ID - 1]).Otch = otch;
            //((PrizeRecord)myFlowPanel1.Controls[ID - 1]).Age = age;
            //((PrizeRecord)myFlowPanel1.Controls[ID - 1]).Gender = gender;
        }
    }
}
