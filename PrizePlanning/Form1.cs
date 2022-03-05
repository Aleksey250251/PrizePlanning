using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace PrizePlanning
{
    public partial class PrizePlanning : Form
    {
        //SQLiteConnection sQLiteConnection;
        //SQLiteCommand command;
        //SQLiteDataAdapter adapter;
        //DataTable dataTable;
        //public string strCommand;
        //List<Question> questions;

        AddData addData;
        BaseData baseData;

        const int MaxPanels = 100;
        static List<MyFlowPanel> panels = new List<MyFlowPanel>();
        public PrizePlanning()
        {
            InitializeComponent(); 
            //questions = new List<Question>();
            //openBD();
            baseData = new BaseData();
        }

        public void Add(Record record)
        {
            //MyFlowPanel myFlowPanel = new MyFlowPanel();
            
        }
        //private void openBD()
        //{
        //    strCommand = "SELECT * FROM Questions";
        //    sQLiteConnection = new SQLiteConnection("Data Source=Test.db;Version=3;");
        //    if(sQLiteConnection.State==ConnectionState.Open)
        //        sQLiteConnection.Close();
        //    sQLiteConnection.Open();
        //    command = new SQLiteCommand(strCommand, sQLiteConnection);
        //    adapter = new SQLiteDataAdapter(command);
        //    dataTable = new DataTable();
        //    adapter.Fill(dataTable);
        //    Question question;
        //    if(dataTable.Rows.Count>0)
        //    {
        //        for (int i = 1; i < dataTable.Rows.Count; i++)
        //        {
        //            question = new Question();
        //            //question.id = int.Parse(dataTable.Columns[0].ToString());
        //            question.Ans1=dataTable.Columns[1].ToString();
        //            question.Ans2=dataTable.Columns[2].ToString();
        //            question.Ans3=dataTable.Columns[3].ToString();
        //            question.Ans4=dataTable.Columns[4].ToString();
        //            question.question=dataTable.Columns[5].ToString();
        //            questions.Add(question);
        //        }
        //    }
        //}
        private void button1_Click(object sender, EventArgs e)
        {
            #region Panels  
            Random random = new Random();
            MyFlowPanel panel = new MyFlowPanel();
            panel.BackColor = System.Drawing.Color.FromArgb(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256), random.Next(0, 256)); ;
            panel.Size = new System.Drawing.Size(960, 100);
            panel.Location = new System.Drawing.Point(3, 3 + 106 * panels.Count);
            panel.TabIndex = panels.Count;
            flowLayoutPanel1.Controls.Add(panel);
            panels.Add(panel);
            #endregion
            //this.Hide();
            //addData = new AddData();
            //addData.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (panels.Count >= 1 && flowLayoutPanel1.Controls.Count >= 1)
            {
                panels.RemoveAt(panels.Count - 1);
                flowLayoutPanel1.Controls.RemoveAt(flowLayoutPanel1.Controls.Count - 1);
            }
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            this.label1.ForeColor = System.Drawing.Color.LightSalmon;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            this.label1. ForeColor = System.Drawing.Color.Black;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PrizePlanning_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "prizePlanningBDDataSet.People". При необходимости она может быть перемещена или удалена.
            this.peopleTableAdapter.Fill(this.prizePlanningBDDataSet.People);

        }
    }
}
