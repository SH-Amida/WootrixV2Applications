using Android.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WootrixV2Apps
{

    public partial class MainPage : ContentPage
    {
        

        public MainPage()
        {
            InitializeComponent();
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

        void OnForwardButtonClicked(object sender, EventArgs e)
        {
            if (webView.CanGoForward)
            {
                webView.GoForward();
            }
        }

        //protected override bool OnBackButtonPressed()
        //{
        //    Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 1]);            
        //    return false;
        //    //return base.OnBackButtonPressed();
        //}

        //protected override bool OnBackButtonPressed()
        //{

        //    return true;
        //}

        //public override void OnBackPressed()
        //{
        //    if (App.IsRootPage || App.AuthenticationContext == null) return;
        //    base.OnBackPressed();
        //}
    }

}
