using System;
using Android.App;
using Firebase.Iid;
//using Plugin.PushNotification;
using Android.Util;

namespace FCMClient
{
    [Service]
    [IntentFilter(new[] { "com.google.firebase.INSTANCE_ID_EVENT" })]
    public class FirebaseIIDService : FirebaseInstanceIdService
    {
        const string TAG = "FirebaseIIDService";
        public override void OnTokenRefresh()
        {
            Android.Util.Log.Debug(TAG, "Location: OnTokenRefresh*************");
            var refreshedToken = FirebaseInstanceId.Instance.Token;
            Log.Debug(TAG, "Refreshed token: " + refreshedToken);
           // System.Diagnostics.Debug.WriteLine($"TOKEN: FirebaseIIDService: {CrossPushNotification.Current.Token}");
            System.Diagnostics.Debug.WriteLine($"TOKEN: FirebaseIIDService: {FirebaseInstanceId.Instance.Token}");
            SendRegistrationToServer(refreshedToken);

        }
        void SendRegistrationToServer(string token)
        {
            // Add custom implementation, as needed.
        }
    }
}

