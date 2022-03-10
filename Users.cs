using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Data.Common;

namespace PrizePlanning
{
    public partial class Users : UserControl
    {
        public InputRecord inputRecord;
        public DeleteRecord deleteRecord;
        public ChangeRecord changeRecord;
        AddRecord addRecord;
        Record curRecord=null;

        List<Record> records;
        SQLiteConnection sqliteConnection;
        SQLiteCommand command;
        SQLiteDataReader dataReader;

        public Users()
        {
            InitializeComponent();
        }

        public void Load(AddRecord addRecord,DeleteRecord deleteRecord, InputRecord inputRecord,ChangeRecord changeRecord)
        {
            this.inputRecord = inputRecord;
            this.deleteRecord = deleteRecord;
            this.changeRecord = changeRecord;
            records = new List<Record>();
        }

        //public void LoadBD(SQLiteConnection sQLiteConnection)
        //{
        //    this.sqliteConnection = sQLiteConnection;
        //    command = sqliteConnection.CreateCommand();
        //    command.CommandText = "SELECT ID FROM Users;";
        //    dataReader = command.ExecuteReader();
        //}

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
            record.Click += new System.EventHandler(ClickRecord);
            myFlowPanel1.Controls.Add(record);
        }

        public void DeleteRecordOnFlowPanel(int ID)
        {
            myFlowPanel1.Controls.RemoveAt(ID - 1);
            deleteRecord(ID);
            for (int i = 0; i < myFlowPanel1.Controls.Count; i++)
            {
                ((Record)myFlowPanel1.Controls[i]).Id = i + 1;
            }
        }
        public void ChooseRecordOnFlowPanel(int ID, string fam, string name, string otch, string age, string gender)
        {
            ((Record)myFlowPanel1.Controls[ID - 1]).Fam = fam;
            ((Record)myFlowPanel1.Controls[ID - 1]).Name = name;
            ((Record)myFlowPanel1.Controls[ID - 1]).Otch = otch;
            ((Record)myFlowPanel1.Controls[ID - 1]).Age = age;
            ((Record)myFlowPanel1.Controls[ID - 1]).Gender = gender;
        }

        private void ClickRecord(object sender, EventArgs e)
        {
            if(curRecord!=null)
            {
                curRecord.BackColor = Color.DarkOrchid;
                curRecord = (Record)sender;
                curRecord.BackColor = Color.Gold;
                Record.OnClick = true;
            }
            else
            {
                ((Record)sender).BackColor = Color.Gold;
                curRecord= (Record)sender;
                Record.OnClick = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MainPrizeForm.countRecords <= 100)
            {
                inputRecord.BringToFront();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(curRecord!=null)
            {
                changeRecord.LoadData(curRecord.Fam, curRecord.Name, curRecord.Otch, int.Parse(curRecord.Age), curRecord.Gender);
                ChangeRecord.IDforChange=curRecord.Id;
                changeRecord.BringToFront();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MainPrizeForm.countRecords >= 1 && curRecord!=null)
            {
                this.DeleteRecordOnFlowPanel(curRecord.Id);
                curRecord.BackColor = Color.Indigo;
                curRecord = null;
                Record.OnClick = false;

            }
        }
    }
}
