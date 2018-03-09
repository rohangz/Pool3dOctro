using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class CanvasEvents : EventArgs{
}
public class InputEventCanvasScript : MonoBehaviour {


	public event EventHandler mouseEvent;
	public static InputEventCanvasScript Instance {
		private set;
		 get;
	}
	void Awake()
	{
		Instance = this;
	}
	void Start()
	{
	}

	public void OnMouseDown()
	{
		Debug.Log ("canvas was touched mouse is down ");
		if (mouseEvent != null) {
			mouseEvent (this, new DragEvent(Action.MSG_MOUSE_CANVAS_DOWN));
		}	
	}

	public void OnMouseUp()
	{
		if (mouseEvent != null) {
			mouseEvent (this,new DragEvent(Action.MSG_MOUSE_CANVAS_UP));
		}
	}

	public void OnMouseInside()
	{
		if (mouseEvent != null) {
			mouseEvent (this,new DragEvent(Action.MSG_MOUSE_CANVAS_STAY));
		}
	}

}
