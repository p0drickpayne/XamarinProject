using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Essentials;
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
            
            VibrateOn = new Command(() =>
            {
                if (_sliderTime != 0)
                {
                    Vibration.Vibrate(TimeSpan.FromMilliseconds(_sliderTime));
                }
            });
            VibrateOff = new Command(() =>
            {
                Vibration.Cancel();
            });
        }
        
        public ObservableCollection<string> AllNotes { get; set; }
        
        public event PropertyChangedEventHandler PropertyChanged;
        
        string _theNote;

        public string TheNote
        {
            get => _theNote;
            set
            {
                _theNote = value;
                
                var args = new PropertyChangedEventArgs(nameof(TheNote));
                
                PropertyChanged?.Invoke(this, args);
            }
        }

        int _sliderTime;

        public int SliderTime
        {
            get => _sliderTime;
            set
            {
                _sliderTime = value;
                
                var args = new PropertyChangedEventArgs(nameof(SliderTime));
                
                PropertyChanged?.Invoke(this, args);
            }
        }

        public Command SaveCommand { get; }
        public Command EraseCommand { get; }
        
        public Command VibrateOn { get; }
        
        public Command VibrateOff { get; }

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