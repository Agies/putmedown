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
    }
}
