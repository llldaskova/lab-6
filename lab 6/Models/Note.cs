using System;
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
        public string Date { get; set; }
        public Note(string name, string text, string date)
        {
            Name = name;
            Text = text;
            Date = date;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
