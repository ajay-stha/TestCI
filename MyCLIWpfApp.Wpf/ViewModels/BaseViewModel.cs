using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MyCLIWpfApp.Wpf.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public string? _Title =
#if RELEASE
    "Main Window";
#else
    "Main Window QA";
#endif


        public string? Title
        {
            get => _Title;
            set => SetProperty(ref _Title, value);
        }

        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;

            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
        #endregion
    }
}
