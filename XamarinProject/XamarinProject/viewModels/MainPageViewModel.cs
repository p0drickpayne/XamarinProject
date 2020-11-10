using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using Xamarin.Essentials;
using Xamarin.Forms;
using XamarinProject.helpers;

namespace XamarinProject
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        
        
        public MainPageViewModel()
        {
            FirebaseHelper firebaseHelper = new FirebaseHelper();
            AllNotes = new ObservableCollection<string>(); 
            EraseCommand = new Command(() =>
            {
                TheNote = string.Empty;
            });

            SaveCommand = new Command(async () =>
            {
                Console.WriteLine("Hello" + _theNote);
                await firebaseHelper.AddNote(_theNote);
                var allNotes = await firebaseHelper.GetAllNotes();
                Console.WriteLine("Hello" + allNotes);
                // AllNotes.Add(allNotes.ToString());
                Console.WriteLine(allNotes.Capacity);
                for (int i = 0; i < allNotes.Count; i++)
                {
                    
                    if (i == allNotes.Capacity -1)
                    {
                        AllNotes.Add(allNotes[i].TheNote);
                        Console.WriteLine("Hello " + allNotes[i].TheNote);
                    }

                }
                TheNote = string.Empty;
            });
            GetAll = new Command(async () =>
            {
                var allNotes = await firebaseHelper.GetAllNotes();
                for (int i = 0; i < allNotes.Count; i++)
                {
                    
                    if (AllNotes.Count < allNotes.Count)
                    {
                        AllNotes.Add(allNotes[i].TheNote);
                        Console.WriteLine("Hello " + allNotes[i].TheNote);
                    }
                        
                    
                    
                }
            });
            
            

                /*
                AllNotes.Add(TheNote);

                TheNote = string.Empty;

            

            async void saveCommand(object sender, EventArgs e)
            {
                await _firebaseHelper.AddNote(_theNote);
                _theNote = string.Empty;
                var allNotes = await _firebaseHelper.GetAllNotes();
                AllNotes.Add(allNotes.ToString());
            }*/
            
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
        
        public Command GetAll { get; }
        
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