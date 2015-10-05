using Android.App;
using Android.Content.PM;
using Android.OS;

namespace PutMeDown.Droid
{
    [Activity(Label = "PutMeDown", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            Container.Instance.Register<IAccelerometer>(new Accelerometer(this));
            Container.Instance.Register<IWarning>(new TextToSpeech(this));
            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }
    }
}

