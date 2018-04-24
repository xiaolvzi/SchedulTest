package md537e33daf55a1b3e57e3b9dbd9218568d;


public class RepeatingAlarm
	extends android.content.BroadcastReceiver
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onReceive:(Landroid/content/Context;Landroid/content/Intent;)V:GetOnReceive_Landroid_content_Context_Landroid_content_Intent_Handler\n" +
			"";
		mono.android.Runtime.register ("ScheduleTest.RepeatingAlarm, ScheduleTest, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", RepeatingAlarm.class, __md_methods);
	}


	public RepeatingAlarm ()
	{
		super ();
		if (getClass () == RepeatingAlarm.class)
			mono.android.TypeManager.Activate ("ScheduleTest.RepeatingAlarm, ScheduleTest, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onReceive (android.content.Context p0, android.content.Intent p1)
	{
		n_onReceive (p0, p1);
	}

	private native void n_onReceive (android.content.Context p0, android.content.Intent p1);

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
