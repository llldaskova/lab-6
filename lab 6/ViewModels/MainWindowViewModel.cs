using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Text;
using lab_6.Models;
using ReactiveUI;
using System.Reactive.Linq;
namespace lab_6.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        ViewModelBase content;
        public ViewModelBase Content
        {
            get
            {
                return content;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref content, value);
            }
        }
        public MainWindowViewModel()
        {
            Content= NoteWindow = new NoteWindowViewModel();
            Dictionary = new NoteDictionary();
            Date = DateTime.Today.ToString();
            
            //Items = new ObservableNote(Date,Dictionary);
           /* AddNoteButton = ReactiveCommand.Create(() =>
            {

                Items.Add(new Note("Заметка 3", "Вот в этой заметочке что то лежит", DateTime.Today.ToString()));
            });*/
           
            //SubWindow = new SubWindowViewModel();
        }
       // public ObservableCollection<Note> Items { get; set; }
        public NoteDictionary Dictionary;
        public ObservableNote Items { get; set; }
       // public ReactiveCommand<Unit, Unit> AddNoteButton { get; }

        private string date;
        public string Date
        {
            get
            {
                return date;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref date, value);
                //if(Items!=null)
                // Items.Clear();
                //Items = new ObservableNote(date, Dictionary);
                this.DatePickerView();
            }
        }
        private void DatePickerView()
        {
            if (Items != null)
            {
                Items.ResultNote.Clear();
                
            }
            Items = new ObservableNote(Date, Dictionary);
        }
        public NoteWindowViewModel NoteWindow { get;  }
        public void AddNoteButton()
        {
            var sub = new SubWindowViewModel();
            Observable.Merge(sub.OkButton, sub.CancelButton.Select(_ => (string)null)).Take(1).Subscribe(msg =>
            {
                if (msg != null)
                {
                    Items.AddObservableNote(new Note(msg, sub.BodyNote));
                }
                Content = NoteWindow;
            });
            Content = sub;

        }

        public void ItemClickButton(Note item)
        {
            var sub = new SubWindowViewModel();
            sub.BodyNote = item.Text;
            sub.Text = item.Name;


            Observable.Merge(sub.OkButton, sub.CancelButton.Select(_ => (string)null)).Take(1).Subscribe(msg =>
            {
                if (msg != null)
                {
                    item.Text = sub.BodyNote;
                    item.Name = msg;
                    Items.Update();
                }
                Content = NoteWindow;
            });
            Content = sub;

        }
        public void DeleteClickButton(Note item)
        {
            Items.DeleteObservableNote(item);
        }

    }
}
