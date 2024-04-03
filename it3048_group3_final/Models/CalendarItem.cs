using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace it3048_group3_final.Models
{
    internal class CalendarItem
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public bool Done { get; set; }
        public DateTime Date { get; set; }
        
    }
}
