﻿using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using Java.Util;
using Android.App.Job;
using Android.Annotation;
using Firebase.JobDispatcher;
using System;

namespace ScheduleTest
{
    [Activity(Label = "ScheduleTest", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            //startTask();
            startJob();
        }

        private void startJob()
        {
            IDriver driver = new GooglePlayDriver(this);
            FirebaseJobDispatcher dispatcher = new FirebaseJobDispatcher(driver);

            JobTrigger myTrigger = Trigger.ExecutionWindow(30, 60);
            Job myJob = dispatcher.NewJobBuilder()
                  .SetService<DemoJob>("demo-job-tag")
                  .SetLifetime(Lifetime.Forever)
                  .SetRecurring(true)
                  .SetTrigger(myTrigger)
                  .Build();

            dispatcher.MustSchedule(myJob);
        }

        public void startTask()
        {
            if (Build.VERSION.SdkInt <= BuildVersionCodes.Kitkat)
            {
                AlarmManager alarmManager = (AlarmManager)GetSystemService(Context.AlarmService);
                Intent intent = new Intent(this, typeof(RepeatingAlarm));
                PendingIntent sender = PendingIntent.GetBroadcast(this, 0, intent, 0);
                // Schedule the alarm!
                alarmManager.SetRepeating(AlarmType.RtcWakeup, SystemClock.ElapsedRealtime(), 5 * 1000, sender);

            }
            else
            {
                JobScheduler scheduler = (JobScheduler)GetSystemService(Context.JobSchedulerService);

                if (isJobPollServiceOn())
                {

                }
                else
                {
                    JobInfo jobInfo = new JobInfo.Builder(1,
                        new ComponentName(this, Java.Lang.Class.FromType(typeof(JobSchedulerService))))
                            .SetPeriodic(JobInfo.MinPeriodMillis)
                            .Build();
                    scheduler.Schedule(jobInfo);
                }
                
            }

        }
        [TargetApi(Value = 20)]
        public bool isJobPollServiceOn()
        {
            JobScheduler scheduler = (JobScheduler)GetSystemService(Context.JobSchedulerService);

            bool hasBeenScheduled = false;
            var jobInfos = scheduler.AllPendingJobs;

            for (int i = 0; i < jobInfos.Count; i++)
            {
                if (jobInfos[i].Id == 1)
                {
                    hasBeenScheduled = true;
                    break;
                }

            }
            
            return hasBeenScheduled;
        }

    }

}