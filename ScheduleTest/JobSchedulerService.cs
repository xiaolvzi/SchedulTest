using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.App.Job;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace ScheduleTest
{
    [Service(Name = "com.example.JobSchedulerService",
             Permission = "android.permission.BIND_JOB_SERVICE")]
    public class JobSchedulerService : JobService
    {
        public override bool OnStartJob(JobParameters @params)
        {
            Log.Error("lv","222222222222222");
            JobFinished(@params, false);
            return true;
        }

        public override bool OnStopJob(JobParameters @params)
        {
            return true;
        }
    }
}