using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;

namespace ScheduleTest
{
    [BroadcastReceiver]
    public class RepeatingAlarm : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            Toast.MakeText(context, "Received intent!", ToastLength.Short).Show();

            Intent notIntent = new Intent(context, typeof(MainActivity));
            PendingIntent contentIntent = PendingIntent.GetActivity(context, 0, notIntent, PendingIntentFlags.CancelCurrent);
            NotificationManagerCompat manager = NotificationManagerCompat.From(context);

            var wearableExtender = new NotificationCompat.WearableExtender().SetBackground(BitmapFactory.DecodeResource(context.Resources, Resource.Drawable.pause));

            NotificationCompat.Builder builder = new NotificationCompat.Builder(context)
             .SetContentIntent(contentIntent)
             .SetSmallIcon(Resource.Drawable.play).SetContentTitle("title")
             .SetContentText("message")
             .SetWhen(Java.Lang.JavaSystem.CurrentTimeMillis())
             .SetSound(RingtoneManager.GetDefaultUri(RingtoneType.Notification))
             .Extend(wearableExtender);

            Notification notification = builder.Build();
            notification.Flags = NotificationFlags.AutoCancel;
            manager.Notify(0, notification);
        }
    }
}