namespace MyCLIWpfApp.Wpf.ViewModels
{
    public class BaseViewModel
    {
        public string Title
        {
            get =>
#if RELEASE
    "Main Window";
#else
    "Main Window QA";
#endif
        }

    }
}
