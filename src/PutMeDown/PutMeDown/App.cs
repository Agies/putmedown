using Xamarin.Forms;

namespace PutMeDown
{
    public class App : Application
    {
        public App()
        {
            // The root page of your application
            var vm = new ShellPageViewModel(
                Container.Instance.GetInstance<IAccelerometer>(),
                Container.Instance.GetInstance<IWarning>()
                );
            vm.RestoreState(Current.Properties);
            MainPage = new ShellPage(vm);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
