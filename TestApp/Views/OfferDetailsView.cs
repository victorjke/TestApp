using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Widget;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Droid.Support.V7.AppCompat;
using TestApp.Core.ViewModels;
using Toolbar = Android.Support.V7.Widget.Toolbar;


namespace TestApp.Views
{
    [Activity(ScreenOrientation = ScreenOrientation.Portrait)]
    public class OfferDetailsView : MvxAppCompatActivity
    {
        TextView _offerJsonTextView;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.OfferDetailsView);
            SetUI();
            SetBindings();
        }


        void SetUI()
        {
            var toolbar = FindViewById<Toolbar>(Resource.Id.OfferDetailsView_Toolbar);
            toolbar.Title = "Offer details";

            SetSupportActionBar(toolbar);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetDisplayShowHomeEnabled(true);

            _offerJsonTextView = FindViewById<TextView>(Resource.Id.OfferDetailsView_OfferJsonTextView);
        }


        void SetBindings()
        {
            var bindingSet = this.CreateBindingSet<OfferDetailsView, OfferDetailsViewModel>();
            bindingSet.Bind(_offerJsonTextView).To(vm => vm.OfferJson);
            bindingSet.Apply();
        }


        public override bool OnSupportNavigateUp()
        {
            ((OfferDetailsViewModel)ViewModel).BackCommand.Execute();
            return true;
        }
    }
}