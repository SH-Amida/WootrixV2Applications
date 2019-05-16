
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WootrixV2Apps.Helpers;
using Xamarin.Forms;



namespace WootrixV2Apps
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            backButton.IsVisible = false;
        }

        protected override void OnAppearing ( ) {
            base.OnAppearing ( );
            
            webView.Navigating += WebView_Navigating;
        }

        async void OnBackButtonClicked(object sender, EventArgs e)
        {
            if (webView.CanGoBack)
            {
                webView.GoBack();
            }
            else
            {
                await Navigation.PopAsync();
            }
        }

        void WebView_Navigating ( object sender, WebNavigatingEventArgs e ) {
            if (!e.Url.StartsWith(ConstantsHelper.BaseUrl)) {
                backButton.IsVisible = true;
            } else {
                backButton.IsVisible = false;
            }
        }

        void OnForwardButtonClicked (object sender, EventArgs e)
        {
            if (webView.CanGoForward)
            {
                webView.GoForward();
            }
        }

    }
}
