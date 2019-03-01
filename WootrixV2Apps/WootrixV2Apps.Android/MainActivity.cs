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

using Android.Support.V7.App;
using System.Threading.Tasks;


namespace WootrixV2Apps.Droid
{
    [Activity(Label = "WootrixV2Apps", Icon = "@drawable/icon", Theme = "@style/MainTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        ///Toolbar toolbar;
        WootrixV2Apps.MainPage mPage;
        const string TAG = "MainActivity.cs";

        protected override void OnCreate(Bundle bundle)
        {
            Android.Util.Log.Debug(TAG, "Location: OnCreate*************");


            //TabLayoutResource = Resource.Layout.Tabbar;
            //ToolbarResource = Resource.Layout.Toolbar;
            
            base.OnCreate(bundle);
            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
            System.Diagnostics.Debug.WriteLine($"Check GPS*****************");
            IsPlayServicesAvailable();
            System.Diagnostics.Debug.WriteLine($"Creat Channel*****************");
            CreateNotificationChannel();
            
            //System.Diagnostics.Debug.WriteLine($"Subscribed To TOPIC: all*****************");
            //FirebaseMessaging.Instance.SubscribeToTopic("all");
            // PushNotificationManager.ProcessIntent(this, Intent);
            //
            //if (Intent.Extras != null)
            //{
            //    foreach (var key in Intent.Extras.KeySet())
            //    {
            //        var value = Intent.Extras.GetString(key);
            //        Android.Util.Log.Debug(TAG, "Key: {0} Value: {1}", key, value);
            //    }
            //}
        }

        //protected override void OnNewIntent(Intent intent)
        //{
        //    Android.Util.Log.Debug(TAG, "Location: OnNewIntent*************");
        //    base.OnNewIntent(intent);
        //    PushNotificationManager.ProcessIntent(this, intent);
        //}

        public bool IsPlayServicesAvailable()
        {
            Android.Util.Log.Debug(TAG, "Location: IsPlayServicesAvailable*************");
            int resultCode = GoogleApiAvailability.Instance.IsGooglePlayServicesAvailable(this);
            if (resultCode != ConnectionResult.Success)
            {
                if (GoogleApiAvailability.Instance.IsUserResolvableError(resultCode))
                    Android.Util.Log.Debug(TAG, "GooglePlayServices Connection Error: " + GoogleApiAvailability.Instance.GetErrorString(resultCode));

                
                else
                {
                    
                    Android.Util.Log.Debug(TAG, "This device is not supported");

                    Finish();
                }
                return false;
            }
            else
            {
                
                Android.Util.Log.Debug(TAG, "Google Play Services is available.");
                return true;
            }
        }

        void CreateNotificationChannel()
        {
            Android.Util.Log.Debug(TAG, "Location: CreateNotificationChannel*************");
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