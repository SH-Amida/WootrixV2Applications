using System;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Plugin.PushNotification;
using Android.Content;
using Android.Gms.Common;
using Firebase.Messaging;
using Firebase.Iid;
using Android.Util;


namespace WootrixV2Apps.Droid
{
    [Activity(Label = "WootrixV2Apps", Icon = "@drawable/icon", Theme = "@style/MainTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        ///Toolbar toolbar;

        protected override void OnCreate(Bundle bundle)
        {



            //ToolbarResource toolbar = Resource.Layout.Toolbar;
            base.OnCreate(bundle);
            //CreateNotificationChannel();
            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
            PushNotificationManager.ProcessIntent(this, Intent);
            Console.WriteLine($"FirebaseInstanceId.Instance.Token from MainActivity.cs: {FirebaseInstanceId.Instance.Token}");

        }

        protected override void OnNewIntent(Intent intent)
        {
            base.OnNewIntent(intent);
            PushNotificationManager.ProcessIntent(this, intent);
        }

        //public bool IsPlayServicesAvailable()
        //{
        //    int resultCode = GoogleApiAvailability.Instance.IsGooglePlayServicesAvailable(this);
        //    if (resultCode != ConnectionResult.Success)
        //    {
        //        if (GoogleApiAvailability.Instance.IsUserResolvableError(resultCode))
        //            msgText.Text = GoogleApiAvailability.Instance.GetErrorString(resultCode);
        //        else
        //        {
        //            msgText.Text = "This device is not supported";
        //            Finish();
        //        }
        //        return false;
        //    }
        //    else
        //    {
        //        msgText.Text = "Google Play Services is available.";
        //        return true;
        //    }
        //}

        void CreateNotificationChannel()
        {
            if (Build.VERSION.SdkInt < BuildVersionCodes.O)
            {
                // Notification channels are new in API 26 (and not a part of the
                // support library). There is no need to create a notification
                // channel on older versions of Android.
                return;
            }

            var channel = new NotificationChannel("WootrixV2Channel",
                                                  "FCM Notifications",
                                                  NotificationImportance.Default)
            {

                Description = "Firebase Cloud Messages appear in this channel"
            };

            var notificationManager = (NotificationManager)GetSystemService(Android.Content.Context.NotificationService);
            notificationManager.CreateNotificationChannel(channel);
        }

    }
}