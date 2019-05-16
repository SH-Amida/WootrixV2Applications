using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Linq;
using System.Text;


[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace WootrixV2Apps
{
    public partial class App : Application
    {
        const string TAG = "App.xaml.cs";
        WootrixV2Apps.MainPage mPage;
        public App()
        {
            InitializeComponent();

            mPage = new WootrixV2Apps.MainPage()
            {
                //Message = "Hello Push Notifications!"
            };
           
            MainPage = new NavigationPage(mPage);            
        }

    }
}
