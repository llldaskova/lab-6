using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Text;
using lab_6.Models;
using ReactiveUI;
namespace lab_6.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            Items = new ObservableCollection<Note>(BuildNote());
            AddNoteButton = ReactiveCommand.Create(()=>
            {

                Items.Add(new Note("Заметка 3", "Вот в этой заметочке что то лежит", DateTime.Today.ToString()));
            });
            Date = DateTime.Today.ToString();
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
        public  ReactiveCommand<Unit, Unit> AddNoteButton { get; }
        
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
        
    }
}
