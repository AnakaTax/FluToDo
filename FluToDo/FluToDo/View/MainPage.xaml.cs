using Xamarin.Forms;

namespace FluToDo
{
    public partial class MainPage : ContentPage
    {
        MainPageViewModel _vm;
        public MainPage()
        {
            _vm = new MainPageViewModel();
            BindingContext = _vm;
            InitializeComponent();
        }

    }
}
