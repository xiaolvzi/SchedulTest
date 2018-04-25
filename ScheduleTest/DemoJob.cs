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
using Android.Util;
using Android.Views;
using Android.Widget;
using Firebase.JobDispatcher;

namespace ScheduleTest
{
    [Service(Name = "com.example.DemoJob")]
    [IntentFilter(new[] { FirebaseJobServiceIntent.Action })]
    class DemoJob : JobService
    {
        public override bool OnStartJob(IJobParameters jobParameters)
        {
            Log.Error("lv", "11111111111111111111111");
            Intent notIntent = new Intent(this, typeof(MainActivity));
            PendingIntent contentIntent = PendingIntent.GetActivity(this, 0, notIntent, PendingIntentFlags.UpdateCurrent);
            NotificationManagerCompat manager = NotificationManagerCompat.From(this);

            var wearableExtender = new NotificationCompat.WearableExtender().SetBackground(BitmapFactory.DecodeResource(this.Resources, Resource.Drawable.pause));

            NotificationCompat.Builder builder = new NotificationCompat.Builder(this)
             .SetContentIntent(contentIntent)
             .SetSmallIcon(Resource.Drawable.play)
             .SetContentTitle("title")
             .SetContentText("message")
             .SetWhen(Java.Lang.JavaSystem.CurrentTimeMillis())
             .SetSound(RingtoneManager.GetDefaultUri(RingtoneType.Notification))
             .Extend(wearableExtender);

            Notification notification = builder.Build();
            notification.Flags = NotificationFlags.AutoCancel;
            manager.Notify(0, notification);
            JobFinished(jobParameters, false);
            return true;
        }

        public override bool OnStopJob(IJobParameters jobParameters)
        {
            return false;
        }
    }
}