using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_6.Models
{
    public class ObservableNote
    {
        
        public ObservableCollection<Note> ResultNote { get; private set; }
        private string date;
        public ObservableNote(string date, NoteDictionary dictionary)
        {
            this.date = date;
            dictionary = new NoteDictionary();
            ResultNote = new ObservableCollection<Note>();
            CreateNote(dictionary);

        }
        private void CreateNote( NoteDictionary dictionary)
        {
            foreach(var n in dictionary.noteDateDictionary[date])
            {
                ResultNote.Add(n);
            }
        }
        public void AddObservableNote( Note note, NoteDictionary dictionary)
        {
            ResultNote.Add(note);
            dictionary.AddInDictionary(date, note);

        }
        public void DeleteObservableNote( Note note, NoteDictionary dictionary)
        {
            for (int i = 0; i < ResultNote.Count; i++)
            {
                if (ResultNote[i].Search(note) == true)
                {
                    ResultNote.RemoveAt(i);
                    break;
                }
            }

            
            dictionary.DeletOfDictionary(date, note);

        }

    }
}
