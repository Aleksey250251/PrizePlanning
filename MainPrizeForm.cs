using System;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data.SQLite;
using System.Data.Common;
using System.Runtime.InteropServices;

namespace PrizePlanning
{
    public delegate void AddRecord(int ID, string fam, string name, string otch, string age, string gender);
    public delegate void DeleteRecord(int ID);
    public delegate void ChooseRecordDelegate(int ID, string fam, string name, string otch, string age, string gender);

    public partial class MainPrizeForm : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        SQLiteConnection connection;
        SQLiteDataReader dataReader;
        SQLiteCommand commandInsert,commandGet;
        AddRecord addRecord;
        DeleteRecord deleteRecord;
        ChooseRecordDelegate choose;
        public static int countRecords=0;
        //const int MaxRecords = 100;
        public static string strConnect { get; } = @"Data Source=..\users.db;Version=3;";

        public MainPrizeForm()
        {
            InitializeComponent();
            panel1.MouseDown += MainPrizeForm_MouseDown;
            panel2.MouseDown += MainPrizeForm_MouseDown;
            panel3.MouseDown += MainPrizeForm_MouseDown;
            addRecord += AddRecordBDMain;
            deleteRecord += DeleteRecord;
            choose += ChooseRecord;
            users1.Load(addRecord,deleteRecord,this.inputRecord1,this.changeRecord1);
            prizes1.Load(addRecord,choosePrize1);
            reminder1.Load(addRecord);
            inputRecord1.Load(addRecord);
            changeRecord1.Load(choose);
        }

        public void AddRecordBDMain(int ID, string fam, string name, string otch, string age,string gender)
        {
            users1.AddRecordOnFlowLayoutPanel(ID, fam, name, otch, age,gender);
            string str1="", str2="";
            prizes1.AddRecordOnFlowLayoutPanel(ID, fam, name, otch, age,gender,str1,str2);
            commandInsert = connection.CreateCommand();
            commandInsert.CommandText = $"INSERT INTO Users (ID,FirstName,Name,LastName,Age,Gender,Date,Prize) VALUES ({ID},'{fam}','{name}','{otch}','{age}','{gender}','','');";
            commandInsert.ExecuteNonQuery();
            inputRecord1.SendToBack();
        }
        public void DeleteRecord(int ID)
        {
            this.prizes1.DeleteRecord(ID);
            commandInsert = connection.CreateCommand();
            commandInsert.CommandText = $"DELETE FROM Users WHERE ID={ID};UPDATE Users SET ID = ID-1 where ID>{ID};";
            commandInsert.ExecuteNonQuery();
            countRecords--;
        }
        public void ChooseRecord(int ID, string fam, string name, string otch, string age, string gender)
        {
            users1.ChooseRecordOnFlowPanel(ID, fam, name, otch, age, gender);
            prizes1.ChooseRecord(ID, fam, name, otch, age, gender);
            commandInsert = connection.CreateCommand();
            commandInsert.CommandText = $"UPDATE Users SET FirstName ='{fam}',name='{name}',LastName='{otch}',Age='{age}',Gender='{gender}' WHERE ID={ID};";
            commandInsert.ExecuteNonQuery();
        }

        private void MainPrizeForm_Load(object sender, EventArgs e)
        {

            connection = new SQLiteConnection(strConnect);
            try
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
                connection.Open();
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка подключения","Error");
            }
            commandGet = connection.CreateCommand();
            commandGet.CommandText = "SELECT * FROM Users;";
            dataReader = commandGet.ExecuteReader();

            prizes1.LoadBD(connection);
            reminder1.LoadBD(connection);

            foreach (DbDataRecord r in dataReader)
            {
                countRecords++;
                users1.AddRecordOnFlowLayoutPanel(int.Parse(r["ID"].ToString()),r["FirstName"].ToString(),
                    r["Name"].ToString(), r["LastName"].ToString(), r["Age"].ToString(),r["Gender"].ToString());
                prizes1.AddRecordOnFlowLayoutPanel(int.Parse(r["ID"].ToString()), r["FirstName"].ToString(),
                    r["Name"].ToString(), r["LastName"].ToString(), r["Age"].ToString(), r["Gender"].ToString(), r["Prize"].ToString(),
                    r["Date"].ToString());
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            label1.Height = button1.Height;
            label1.Top = button1.Top;
            home1.BringToFront();
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            label1.Height = button2.Height;
            label1.Top = button2.Top;
            users1.BringToFront();
        }
        private void button3_Click_1(object sender, EventArgs e)
        {
            label1.Height = button3.Height;
            label1.Top = button3.Top;
            prizes1.BringToFront();
        }

        private void MainPrizeForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            reminder1.UpdateData();
            label1.Height = button4.Height;
            label1.Top = button4.Top;
            reminder1.BringToFront();
        }
    }
}
