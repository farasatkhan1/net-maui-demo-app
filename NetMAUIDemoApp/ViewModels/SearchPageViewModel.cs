using NetMAUIDemoApp.Models;
using NetMAUIDemoApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using Microsoft.Maui;

namespace NetMAUIDemoApp.ViewModels
{
    public class SearchPageViewModel: INotifyPropertyChanged
    {
        public ObservableCollection<Note> Notes { get; set; }
        public ICommand AddNewNoteCommand { get; }
        public ICommand DeleteNoteCommand { get; }

        public SearchPageViewModel()
        {
            Notes = new ObservableCollection<Note>();
            LoadNotes();
            AddNewNoteCommand = new Command(onAddNewNoteButtonClicked);
            DeleteNoteCommand = new Command<Note>(onDeleteButtonClicked);
        }

        private string _description;

        public string Description
        {
            get => _description;
            set
            {
                if (_description != value)
                {
                    _description = value;
                    OnPropertyChanged(nameof(Description));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private async void onAddNewNoteButtonClicked()
        {
            await NoteService.AddNote(Description);
            Description = string.Empty;
            LoadNotes();
        }

        private async void onDeleteButtonClicked(Note note)
        {
            await NoteService.RemoveNote(note.Id);
            LoadNotes();
        }

        private async void LoadNotes()
        {
            var notes = await NoteService.GetNote();
            Notes.Clear();
            foreach (var note in notes)
            {
                Notes.Add(note);
            }
        }
    }
}
