using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrizePlanning
{
    public partial class Reminder : UserControl
    {
        SQLiteConnection connection;
        SQLiteDataReader reader;
        SQLiteCommand command;
        AddRecord addRecord;
        public Reminder()
        {
            InitializeComponent();
        }
        public void Load(AddRecord addRecord)
        {
            this.addRecord = addRecord;
        }
        public void LoadBD(SQLiteConnection connection)
        {
            this.connection = connection;

        }
        public void UpdateData()
        {
            List<Record> list = new List<Record>();
            command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Users";
            reader = command.ExecuteReader();
            foreach (DbDataRecord r in reader)
            {
                if (r["Date"].ToString() != "")
                {
                    Record record = new Record();
                    record.DatePrize = DateTime.Parse(r["Date"].ToString());

                    record.Id = int.Parse(r["ID"].ToString());
                    record.Fam = r["FirstName"].ToString();
                    record.Name = r["Name"].ToString();
                    record.Otch = r["LastName"].ToString();
                    record.Age = r["Age"].ToString();
                    record.Gender = r["Gender"].ToString();
                    record.Prize = r["Prize"].ToString();

                    list.Add(record);
                }
            }
            var sortList = from i in list orderby i.DatePrize select i;
            List<Record> list2 = new List<Record>();
            foreach (Record item in sortList)
            {
                list2.Add(item);
            }
            if (list2.Count >= 1)
            {
                this.label1.Text = list2[0].Fam.ToString();
                this.label2.Text = list2[0].Name.ToString();
                this.label3.Text = list2[0].Otch.ToString();
                this.label4.Text = list2[0].Prize.ToString();
                this.label5.Text = list2[0].DatePrize.ToShortDateString();
                if (list2.Count >= 2)
                {
                    this.label6.Text = list2[1].Fam.ToString();
                    this.label7.Text = list2[1].Name.ToString();
                    this.label8.Text = list2[1].Otch.ToString();
                    this.label9.Text = list2[1].Prize.ToString();
                    this.label10.Text = list2[1].DatePrize.ToShortDateString();
                    if (list2.Count >= 3)
                    {
                        this.label11.Text = list2[2].Fam.ToString();
                        this.label12.Text = list2[2].Name.ToString();
                        this.label13.Text = list2[2].Otch.ToString();
                        this.label14.Text = list2[2].Prize.ToString();
                        this.label15.Text = list2[2].DatePrize.ToShortDateString();
                    }
                }
            }
            list.Clear();
            list2.Clear();
        }
    }
}
