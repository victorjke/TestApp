using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System.Threading.Tasks;
using TestApp.Core.ViewModels;


namespace TestApp.Core
{
    public class CustomAppStart : MvxAppStart
    {
        public CustomAppStart(IMvxApplication application, IMvxNavigationService navigationService) : base(application, navigationService)
        {
        }

        protected override async Task NavigateToFirstViewModel(object hint = null)
        {
            await NavigationService.Navigate<OffersListViewModel>();
        }
    }
}