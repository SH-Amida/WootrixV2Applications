using Android.Util;
using Plugin.PushNotification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;



namespace WootrixV2Apps
{
    public partial class MainPage : ContentPage
    {

        public string Message
        {
            get
            {
                return textLabel.Text;
            }
            set
            {
                textLabel.Text = value;
            }
        }

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

        void OnLogTokenButtonClicked(object sender, EventArgs e)
        {
            Console.WriteLine($"Firebase.Current.Token from MainPage.cs: {CrossPushNotification.Current.Token}");
            //Log.Debug("Firebase", "InstanceID token: " + FirebaseInstanceId.Instance.Token);

        }


    }
}
