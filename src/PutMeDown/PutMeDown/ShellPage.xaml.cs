using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PutMeDown
{
    public partial class ShellPage : ContentPage
    {
        public ShellPage(ShellPageViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }
    }
}
