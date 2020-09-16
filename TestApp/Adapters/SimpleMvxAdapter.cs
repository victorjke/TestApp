using Android.Content;
using Android.Views;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using MvvmCross.Platforms.Android.Binding.Views;
using System;


namespace TestApp.Adapters
{
    public class SimpleMvxAdapter<TView> : MvxAdapter<TView> where TView : MvxListItemView
    {
        public SimpleMvxAdapter(Context context, IMvxAndroidBindingContext bindingContext) : base(context, bindingContext)
        {
        }


        protected override IMvxListItemView CreateBindableView(object dataContext, ViewGroup parent, int templateId)
        {
            return (TView)Activator.CreateInstance(typeof(TView), Context, BindingContext.LayoutInflaterHolder, dataContext, parent, templateId);
        }
    }
}