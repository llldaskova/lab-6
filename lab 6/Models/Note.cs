﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_6.Models
{
    public class Note
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public Note(string name, string text)
        {
            Name = name;
            Text = text;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
