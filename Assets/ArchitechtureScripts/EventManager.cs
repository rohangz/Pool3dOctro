using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour {

	private static EventManager instance;
	private Dictionary<string,UnityEvent> eventDictionary;

	public static EventManager Instance
	{
		get
		{
			if (!instance)
			{
			//	instance = FindObjectOfType (EventManager);
				if (!instance) 
				{
					Debug.LogError ("Object is not present");
				}
				else 
				{
					instance.Init ();			
				}
			}
			return instance;
		}

	}
	void Init()
	{
		eventDictionary = new Dictionary<string,UnityEvent> ();

	}
	public void starListening(string eventName,UnityAction listener)
	{
		UnityEvent thisEvent = null;
		if (Instance.eventDictionary.TryGetValue (eventName, out thisEvent)) {
			thisEvent.AddListener (listener);
		}
		else
		{
		}

	}
}
