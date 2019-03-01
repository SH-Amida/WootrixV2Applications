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

using Android.Media;
using Android.Support.V4.App;
using Firebase.Messaging;
using Firebase.Iid;

namespace WootrixV2Apps.Droid
{
    [Service]
    [IntentFilter(new[] { "com.google.firebase.MESSAGING_EVENT" })]
    public class FireBaseMessagingService : FirebaseMessagingService
    {
        const string TAG = "MyFirebaseMsgService";

        /**
         * Called when message is received.
         */

        // [START receive_message]
        public override void OnMessageReceived(RemoteMessage message)
        {
            Android.Util.Log.Debug(TAG, "Location: OnMessageReceived*************");
            // TODO(developer): Handle FCM messages here.
            // If the application is in the foreground handle both data and notification messages here.
            // Also if you intend on generating your own notifications as a result of a received FCM
            // message, here is where that should be initiated. See sendNotification method below.

            //Android.Util.Log.Debug(TAG, "Location: OnTokenRefresh*************");
            var refreshedToken = FirebaseInstanceId.Instance.Token;
            Android.Util.Log.Debug(TAG, "Token: " + refreshedToken);
            Android.Util.Log.Debug(TAG, "From: " + message.From);
            Android.Util.Log.Debug(TAG, "Notification Message Body: " + message.GetNotification().Body);

            SendNotification(message.GetNotification().Body);
        }
        // [END receive_message]
        private static readonly int NOTIFICATION_ID = 1;
        private static readonly String NOTIFICATION_CHANNEL_ID = "WootrixV2Channel";
        private static readonly String NOTIFICATION_CHANNEL_DESCRIPTION = "Default Channel";
        /**
         * Create and show a simple notification containing the received FCM message.
         */
        void SendNotification(string messageBody)
        {
            Android.Util.Log.Debug(TAG, "Location: SendNotification*************");
            var notificationManager = NotificationManager.FromContext(this);   
            
            //Check if notification channel exists and if not create one
            if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
            {
                var defaultSoundUri = RingtoneManager.GetDefaultUri(RingtoneType.Notification);
                NotificationChannel notificationChannel = notificationManager.GetNotificationChannel(NOTIFICATION_CHANNEL_ID);
                if (notificationChannel == null)
                {                    
                    notificationChannel = new NotificationChannel(NOTIFICATION_CHANNEL_ID, NOTIFICATION_CHANNEL_DESCRIPTION, NotificationImportance.Default);
                    notificationChannel.LightColor = (int)ConsoleColor.Green; //Set if it is necesssary
                    notificationChannel.EnableVibration(true); //Set if it is necesssary
                    //notificationChannel.SetSound(defaultSoundUri, AudioAttributes.);
                    notificationManager.CreateNotificationChannel(notificationChannel);
                }
            }

            var intent = new Intent(this, typeof(MainActivity));
            intent.AddFlags(ActivityFlags.ClearTop);
            var pendingIntent = PendingIntent.GetActivity(this, 0 /* Request code */, intent, PendingIntentFlags.OneShot);

            //builder.setContentTitle() // required
            //        .setSmallIcon() // required
            //        .setContentText() // required
            //        .setChannelId(id) // required for deprecated in API level >= 26 constructor .Builder(this)


            var notificationBuilder = new NotificationCompat.Builder(this)
                .SetSmallIcon(Resource.Drawable.icon)
                .SetContentTitle("Wootrix Message")
                .SetContentText(messageBody)
                .SetAutoCancel(true)
                .SetContentIntent(pendingIntent)
                .SetChannelId(NOTIFICATION_CHANNEL_ID);
                
            notificationManager.Notify(NOTIFICATION_ID /* ID of notification */, notificationBuilder.Build());
        }
    }
}