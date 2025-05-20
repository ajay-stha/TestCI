using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MyCLIWpfApp.Wpf.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
#if RELEASE
        public string _Title = "Main Window";
#else
        public string _Title = "Main Window QA";
#endif

        public string? Title
        {
            get => _Title;
            set => SetProperty(ref _Title, value);
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = "")
        {
            if (Equals(storage, value))
                return false;

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
