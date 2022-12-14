using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace lab_6.Models
{
    public class ObservableNote: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public ObservableCollection<Note> ResultNote { get; set; }
        
        private string date;
        NoteDictionary dictionary;
        public ObservableNote(string date, NoteDictionary dictionary)
        {
            this.date = date;
            this.dictionary = dictionary;
            ResultNote = new ObservableCollection<Note>();
            CreateNote();
            //OnPropertyChanged();
        }
       
        public void Update()
        {
            dictionary.noteDateDictionary[date].Clear();
            foreach(var n in ResultNote)
            {
                dictionary.noteDateDictionary[date].Add(n);
            }
            dictionary.saveInFail();

        }
        public void CreateNote()
        {
            if (dictionary.noteDateDictionary.ContainsKey(date))
            {
                foreach (var n in dictionary.noteDateDictionary[date])
                {
                    ResultNote.Add(n);
                }
            }
            
        }
        public void AddObservableNote( Note note)
        {
            ResultNote.Add(note);
            dictionary.AddInDictionary(date, note);

        }
        public void DeleteObservableNote( Note note)
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
