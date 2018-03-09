using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputEventScript : MonoBehaviour {
	public static InputEventScript Instance;
	public event EventHandler mouseEvent;
	public void Awake()
	{
		Instance = this;
	}
	public void OnPointerClick()
	{
		Debug.LogError ("Recieveing the push ");
	}



	public void OnMouseDown()
	{
	/*	Debug.LogError ("Mouse pressed on the table ");
		if (mouseEvent != null) {
		//	mouseEvent (this,new DragEvent(Action.MSG_MOUSE_DOWN_TABLE));
		}*/
	}



	public void OnMouseUp()
	{
		/*Debug.LogError ("Mouse Pressed up on the table");
		if (mouseEvent != null) {
		//	mouseEvent (this, new DragEvent (Action.MSG_MOUSE_UP_TABLE));
		}*/
	}
}
