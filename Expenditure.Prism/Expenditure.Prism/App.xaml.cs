using Prism;
using Prism.Ioc;
using Expenditure.Prism.ViewModels;
using Expenditure.Prism.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Expenditure.Common.Services;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Expenditure.Prism
{
    public partial class App
    {

        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/TravelsPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IApiService, ApiService>();
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<TravelsPage, TravelsPageViewModel>();
            containerRegistry.RegisterForNavigation<ExpensesPage, ExpensesPageViewModel>();
            containerRegistry.RegisterForNavigation<PrismContentPage1, PrismContentPage1ViewModel>();
        }
    }
}
