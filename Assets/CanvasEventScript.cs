using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CanvasEventScript : MonoBehaviour {

	public static CanvasEventScript Instance {
		private set;
		get;
	}
	public event EventHandler mouseEvent;

	private void Awake()
	{
		Instance = this;
	}


	public void OnMouseDown()
	{
		if (mouseEvent != null) {
			mouseEvent (this, new DragEvent (Action.MSG_MOUSE_DOWN_CANVAS));
		}
	}

	public void OnMouseUp()
	{
		if (mouseEvent != null) {
			mouseEvent (this, new DragEvent (Action.MSG_MOUSE_UP_CANVAS));
		}
	}
}
