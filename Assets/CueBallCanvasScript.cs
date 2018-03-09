using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CueBallCanvasScript: MonoBehaviour {

	private PoolGameController gameController;
	private GameObject cueBall;
	public static CueBallCanvasScript Instance;
	public event EventHandler mouseEvent;

	void Awake()
	{
		Instance = this;

	}
	void Start()
	{
		if (PoolGameController.GameInstance != null) {
			gameController = PoolGameController.GameInstance;
			cueBall = gameController.cueBall;
		} else {
			cueBall = null;
		}
	}
	void Update()
	{
		if (cueBall != null) {
			Vector3 position = Camera.main.WorldToScreenPoint (cueBall.transform.position);
			gameObject.transform.position = position;
		}
	}
	public void OnMouseDown()
	{
		if (mouseEvent != null) {
			mouseEvent (this,new DragEvent(Action.MSG_MOUSE_CUE_BALL_CANVAS_DOWN));
		}
		Debug.Log ("Mouse is down on the image ");
	}
	public void OnMouseUp()
	{
		if (mouseEvent != null) {
			mouseEvent (this, new DragEvent (Action.MSG_MOUSE_CUE_BALL_CANVAS_UP));
		}
		Debug.Log ("Mouse is up from yhe image");
	}
}
