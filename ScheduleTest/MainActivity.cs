using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using Java.Util;
using Android.App.Job;
using Android.Annotation;
using Firebase.JobDispatcher;

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

            startTask();
        }

        public void startTask()
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
  
    }

}