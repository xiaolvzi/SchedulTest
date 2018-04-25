package com.example;


public class DemoJob
	extends com.firebase.jobdispatcher.JobService
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onStartJob:(Lcom/firebase/jobdispatcher/JobParameters;)Z:GetOnStartJob_Lcom_firebase_jobdispatcher_JobParameters_Handler\n" +
			"n_onStopJob:(Lcom/firebase/jobdispatcher/JobParameters;)Z:GetOnStopJob_Lcom_firebase_jobdispatcher_JobParameters_Handler\n" +
			"";
		mono.android.Runtime.register ("ScheduleTest.DemoJob, ScheduleTest, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", DemoJob.class, __md_methods);
	}


	public DemoJob ()
	{
		super ();
		if (getClass () == DemoJob.class)
			mono.android.TypeManager.Activate ("ScheduleTest.DemoJob, ScheduleTest, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public boolean onStartJob (com.firebase.jobdispatcher.JobParameters p0)
	{
		return n_onStartJob (p0);
	}

	private native boolean n_onStartJob (com.firebase.jobdispatcher.JobParameters p0);


	public boolean onStopJob (com.firebase.jobdispatcher.JobParameters p0)
	{
		return n_onStopJob (p0);
	}

	private native boolean n_onStopJob (com.firebase.jobdispatcher.JobParameters p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
