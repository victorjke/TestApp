using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Support.V7.Widget;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using MvvmCross.Platforms.Android.Binding.Views;
using TestApp.Adapters;
using TestApp.Core.ViewModels;


namespace TestApp.Views
{
    [Activity(MainLauncher = true, ScreenOrientation = ScreenOrientation.Portrait)]
    public class OffersListView : MvxAppCompatActivity
    {
        MvxListView _offersListView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.OffersListView);
            SetUI();
            SetBindings();
        }


        void SetUI()
        {
            var toolbar = FindViewById<Toolbar>(Resource.Id.OffersListView_Toolbar);
            toolbar.Title = "Offer ids";

            _offersListView = FindViewById<MvxListView>(Resource.Id.OffersListView_OffersListView);
            var offersListAdapter = new SimpleMvxAdapter<OffersListItemView>(this, (IMvxAndroidBindingContext)BindingContext);
            _offersListView.ItemTemplateId = Resource.Layout.OffersListItemView;
            _offersListView.Adapter = offersListAdapter;
        }


        void SetBindings()
        {
            var bindingSet = this.CreateBindingSet<OffersListView, OffersListViewModel>();
            bindingSet.Bind(_offersListView).For(v => v.ItemsSource).To(vm => vm.Offers);
            bindingSet.Apply();
        }
    }
}