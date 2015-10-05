using Foundation;
using UIKit;

namespace PutMeDown.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            //Container.Instance.Register<IAccelerometer>(new Accelerometer());
            Container.Instance.Register<IWarning>(new TextToSpeech());

            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}
