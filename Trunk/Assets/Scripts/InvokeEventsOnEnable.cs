using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using GameAnalyticsSDK;
public class InvokeEventsOnEnable : MonoBehaviour {

	public bool invokeOnEnable = true;

	public UnityEvent eventsOnEnable;

	public UnityEvent eventsOnDisable;
	void OnEnable () {
		if (invokeOnEnable)
			eventsOnEnable.Invoke ();
	}
	
	public void InvokeEventsManually()
	{
		eventsOnEnable.Invoke ();
	}

	void OnDisable()
	{
		eventsOnDisable.Invoke ();
	}

	public void ReportDesignEvent(string eventSyntax)
	{
		GameAnalytics.NewDesignEvent (eventSyntax);
	}
}
