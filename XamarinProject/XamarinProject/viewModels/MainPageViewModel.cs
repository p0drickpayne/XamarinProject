using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Forms;

namespace XamarinProject
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        
        
        public MainPageViewModel()
        {
            AllNotes = new ObservableCollection<string>(); 
            EraseCommand = new Command(() =>
            {
                TheNote = string.Empty;
            });
            
            SaveCommand = new Command(() =>
            {
                AllNotes.Add(TheNote);
                
                TheNote = string.Empty;
            });
        }
        
        public ObservableCollection<string> AllNotes { get; set; }
        
        public event PropertyChangedEventHandler PropertyChanged;
        
        string theNote;

        public string TheNote
        {
            get => theNote;
            set
            {
                theNote = value;
                
                var args = new PropertyChangedEventArgs(nameof(TheNote));
                
                PropertyChanged?.Invoke(this, args);
            }
        }

        public Command SaveCommand { get; }
        public Command EraseCommand { get; }

        // public string TheNote
        // {
        //     get => _theNote;
        //     set
        //     {
        //         if (_theNote.Equals(value)) return;
        //         
        //             _theNote = value;
        //             
        //             OnPropertyChanged();
        //     }
        // }
        
        
    }
}