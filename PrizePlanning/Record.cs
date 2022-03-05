using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrizePlanning
{
    public class Record
    {
        public int Id { get; set; }
        public string Fam { get; set; }
        public string Name { get; set; }
        public string Otch { get; set; }
        public int Age { get; set; }
        public string Prize { get; set; }
        public DateTime DatePrize { get; set; }
    }
}