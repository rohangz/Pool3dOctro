using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CueballPlacingRegionEventScript : MonoBehaviour {

	public static CueballPlacingRegionEventScript Instance;
	public event EventHandler mouseEvent;


	public void Awake()
	{
		Instance = this;
	}




	public void OnMouseDown()
	{
		Debug.Log ("MOUSE IS DOWN ON REGION YO");

	}
	public void OnMouseUp()
	{
		Debug.Log ("MOUSE IS UP ON REGION YO");
	}
	public void OnMouseEnter()
	{
		Debug.Log ("mouse is inside the region ");
		if (mouseEvent != null) {
			mouseEvent (this,new DragEvent( Action.MSG_MOUSE_INSIDE_REGION));
		}
	}
	public void OnMouseExit()
	{
		Debug.Log ("mouse is outside the region ");
		if (mouseEvent != null) {
			mouseEvent (this, new DragEvent(Action.MSG_MOUSE_OUTSIDE_REGION));
		}
	}
}
