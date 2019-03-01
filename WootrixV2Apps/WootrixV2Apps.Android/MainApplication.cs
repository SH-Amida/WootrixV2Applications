using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;


using Android.Gms.Common;
using Firebase.Messaging;
using Firebase.Iid;
using Android.Util;
using Plugin.PushNotification;

namespace WootrixV2Apps.Droid
{
    [Application]
    public class MainApplication : Application
    {
        public MainApplication(IntPtr handle, JniHandleOwnership transer) : base(handle, transer)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();

            //If debug you should reset the token each time.
#if DEBUG
            PushNotificationManager.Initialize(this, true);
#else
            PushNotificationManager.Initialize(this, false);
#endif

            //Set the default notification channel for your app when running Android Oreo
            if (Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.O)
            {
                //Change for your default notification channel id here
                PushNotificationManager.DefaultNotificationChannelId = "WootrixV2ChannelID";

                //Change for your default notification channel name here
                PushNotificationManager.DefaultNotificationChannelName = "WootrixV2ChannelName";

            }
            //FirebaseMessaging.Instance.SubscribeToTopic("all");
            //Log.Debug("all", "Subscribed to remote notifications");
            Console.WriteLine($"Firebase.Current.Token from MainApplication.cs: {CrossPushNotification.Current.Token}");
            //Console.WriteLine($"FirebaseInstanceId.Instance.Token from from MainApplication.cs: {FirebaseInstanceId.Instance.Token}");
            //Handle notification when app is closed here
            CrossPushNotification.Current.OnNotificationReceived += (s, p) =>
            {


            };


        }
    }
}