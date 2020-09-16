using MvvmCross.ViewModels;

namespace TestApp.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            base.Initialize();
            RegisterCustomAppStart<CustomAppStart>();
        }
    }
}