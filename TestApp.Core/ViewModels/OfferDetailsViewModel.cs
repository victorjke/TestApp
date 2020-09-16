using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;


namespace TestApp.Core.ViewModels
{
    public class OfferDetailsViewModel : MvxViewModel<string>
    {
        readonly IMvxNavigationService _navigationService;
        string _offerJson;


        public OfferDetailsViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }


        public IMvxCommand BackCommand => new MvxCommand(() => _navigationService.Close(this));


        public override void Prepare(string offerJson)
        {
            _offerJson = offerJson;
        }


        public string OfferJson
        {
            get => _offerJson;
            private set => SetProperty(ref _offerJson, value);
        }
    }
}
