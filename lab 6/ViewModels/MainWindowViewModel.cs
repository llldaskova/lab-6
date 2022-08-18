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
            Items = new ObservableCollection<Note>(BuildNote());
           /* AddNoteButton = ReactiveCommand.Create(() =>
            {

                Items.Add(new Note("Заметка 3", "Вот в этой заметочке что то лежит", DateTime.Today.ToString()));
            });*/
            Date = DateTime.Today.ToString();
            //SubWindow = new SubWindowViewModel();
        }
        public ObservableCollection<Note> Items { get; set; }
        private Note[] BuildNote()
        {
            return new Note[]
            {
                new Note ("Заметка 1", "Вот в этой заметочке что то лежит",new DateTime(2022,7,1).ToString()),
                new Note ("Заметка 2", "Вот в этой заметочке что то лежит",new DateTime(2022,5,1).ToString())
            };
        }
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
            }
        }
        private string bodyNote;
       /* public string NN
        {
            get
            {
                return bodyNote;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref bodyNote, value);
            }
        }*/

        private string nameNote;
        public string NameNote
        {
            get
            {
                return nameNote;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref nameNote, value);
            }
        }


        public NoteWindowViewModel NoteWindow { get;  }

        private void OpenSubwindow(SubWindowViewModel sub)
        {
            Observable.Merge(sub.OkButton, sub.CancelButton.Select(_ => (string)null)).Take(1).Subscribe(msg =>
            {
                if (msg != null)
                {
                    bodyNote = sub.BodyNote;
                    NameNote = msg;
                }
                Content = NoteWindow;
            });
            Content = sub;
        }

        public void AddNoteButton()
        {
            var sub = new SubWindowViewModel();
            Observable.Merge(sub.OkButton, sub.CancelButton.Select(_ => (string)null)).Take(1).Subscribe(msg =>
            {
                if (msg != null)
                {
                    bodyNote = sub.BodyNote;
                    NameNote = msg;
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
                }
                Content = NoteWindow;
            });
            Content = sub;

        }


    }
}
