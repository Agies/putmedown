using Microsoft.Phone.Controls;

namespace PutMeDown.WinPhone
{
    public partial class MainPage : global::Xamarin.Forms.Platform.WinPhone.FormsApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
            SupportedOrientations = SupportedPageOrientation.PortraitOrLandscape;

            Container.Instance.Register<IAccelerometer>(new Accelerometer());
            Container.Instance.Register<IWarning>(new TextToSpeech());
            
            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new PutMeDown.App());
        }
    }
}
