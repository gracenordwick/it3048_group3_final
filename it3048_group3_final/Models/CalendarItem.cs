﻿using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace it3048_group3_final.Models
{
    public class CalendarItem
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public TimeSpan Time { get; set; }

    }
}
