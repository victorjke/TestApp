using Android.Content;
using Android.Views;
using Android.Widget;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Android.Binding;
using MvvmCross.Platforms.Android.Binding.Views;
using TestApp.Core.Models;


namespace TestApp.Views
{
    public class OffersListItemView : MvxListItemView
    {
        TextView _titleTextView;


        public OffersListItemView(Context context, IMvxLayoutInflaterHolder layoutInflaterHolder, object dataContext, ViewGroup parent, int templateId) : 
            base(context, layoutInflaterHolder, dataContext, parent, templateId)
        {
            SetUI();
            SetBindings();
        }

        void SetUI()
        {
            _titleTextView = Content.FindViewById<TextView>(Resource.Id.OffersListItemView_TitleTextView);
        }


        void SetBindings()
        {
            var bindingSet = this.CreateBindingSet<OffersListItemView, Offer>();
            bindingSet.Bind(_titleTextView).To(m => m.Id);
            bindingSet.Bind(Content).For(v => v.BindClick()).To(m => m.SelectCommand);
            bindingSet.Apply();
        }
    }
}