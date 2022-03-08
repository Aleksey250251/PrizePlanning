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
    public partial class Reminder : UserControl
    {
        AddRecord addRecord;
        public Reminder()
        {
            InitializeComponent();
        }
        public void Load(AddRecord addRecord)
        {
            this.addRecord = addRecord;
        }
    }
}
