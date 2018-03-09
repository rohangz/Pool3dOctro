using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class DragEvent:EventArgs{
	public Action action;
	public DragEvent(Action action)
	{
		this.action = action;
	}

}

public class EventScript : MonoBehaviour {


	private RectTransform initialPosition;
	private float initialY;
	private RectTransform finalPosition;
	private float finalY;
	public event EventHandler mouseEvent;
	public static EventScript Instance;



	public void Awake()
	{
		Instance = this;
		//Debug.Log ("called ");

	}
	#region DragEventsRegion

		public void OnDragBegin()
		{
			if (mouseEvent != null) {
			mouseEvent (this,new DragEvent(Action.MSG_DRAG_BEGIN_IMAGE));
			}
		}
		public void OnDrag()
		{
			if (mouseEvent != null) {
			mouseEvent (this, new DragEvent(Action.MSG_DRAGGING_IMAGE));

			}
		}

		public void OnDragEnd()
		{
			if (mouseEvent != null) {
			mouseEvent (this,new DragEvent(Action.MSG_DRAG_END_IMAGE));
			}	
		}
	#endregion

	#region mouseDownAndUpEvents 

	public void OnMouseDown()
	{
		if (mouseEvent != null) {
			mouseEvent (this,new DragEvent(Action.MSG_MOUSE_DOWN_IMAGE));
		}
	}
	public void OnMouseUp()
	{
		if (mouseEvent != null) {
			mouseEvent (this, new DragEvent (Action.MSG_MOUSE_UP_IMAGE));
		}
	}
	public void OnMouseExit()
	{
		if (mouseEvent != null) {
			mouseEvent (this, new DragEvent (Action.MSG_MOUSE_LEAVES_IMAGE));
		}
	}

	#endregion
	public void OnDisable()
	{
	}

}






