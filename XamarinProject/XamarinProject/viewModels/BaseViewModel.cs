using System.ComponentModel;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace XamarinProject
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        
        private bool _busy;
        
        public bool IsBusy
        {
            get => _busy;
            set
            {
                if (_busy == value) return;
                _busy = value;
                OnPropertyChanged();
            }
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}