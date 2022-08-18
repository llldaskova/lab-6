using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace lab_6.Models
{
    public class NoteDictionary
    {
        private string failName = "NoteBase.txt";
        public NoteDictionary()
        {
            try
            {
                loadOfFail();
            }
            catch
            {
                noteDateDictionary = new Dictionary<string, List<Note>>();
            }
        }
        public Dictionary<string, List<Note>> noteDateDictionary{ get;  private set; }

        public void saveInFail()
        {
            if(noteDateDictionary.Count!=0)
                File.WriteAllText(failName, JsonConvert.SerializeObject(noteDateDictionary));
        }
        private void loadOfFail()
        {
            var str = File.ReadAllText(failName);
            if (str!=null)
            noteDateDictionary = JsonConvert.DeserializeObject<Dictionary<string, List<Note>>>
            (str);
        }

        public void AddInDictionary(string date, Note note)
        {
            if(noteDateDictionary.ContainsKey(date))
            {
                noteDateDictionary[date].Add(note);
            }
            else
            {
                List<Note> notes = new List<Note>();
                notes.Add(note);
                noteDateDictionary.Add(date, notes);
            }
            saveInFail();
        }

        public void DeletOfDictionary(string date, Note note)
        {
            if (noteDateDictionary.ContainsKey(date))
            {
                var notes=noteDateDictionary[date];
                for (int i= 0;i < notes.Count;i++)
                {
                    if (notes[i].Search(note) == true)
                    {
                        notes.RemoveAt(i);
                        break;
                    }
                }
               
                noteDateDictionary[date] = notes;
            }
            else
            {
                throw new Exception();
            }
            saveInFail();
        }

        public void Print()
        {
            foreach (KeyValuePair<string, List<Note>> entry in noteDateDictionary)
            {
                Console.WriteLine(entry.Key + " : " );
                foreach (var i in entry.Value)
                {
                    Console.WriteLine(i.Name+"\n"+i.Text);
                }
            }
        }
        
    }
}
