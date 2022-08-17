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

                Items.Add(new Note("Заметка 3", "Вот в этой заметочке что то лежит"));
            });
        }
        public ObservableCollection<Note> Items { get; set; }
        private Note[] BuildNote()
        {
            return new Note[]
            {
                new Note ("Заметка 1", "Вот в этой заметочке что то лежит"),
                new Note ("Заметка 2", "Вот в этой заметочке что то лежит")
            };
        }
        public  ReactiveCommand<Unit, Unit> AddNoteButton { get; }
        
        private  void AddNoteButtonMethod()
        {
            Items.Add(new Note("Заметка 3", "Вот в этой заметочке что то лежит"));
           
        }
        
    }
}
