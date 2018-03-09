using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class MoveImageScript : MonoBehaviour {

	private RectTransform orignal;
	private bool found=false ;
	private Vector3 oldPositon;
	private Vector3 orignalPosition;
	public event EventHandler handler;

	public static MoveImageScript Instance;


	private bool toLerp=false;

	private GameObject debugger;

	private GameObject cue;
	private GameObject cueBall;
	private bool isFirstTouch = false;


	//Required Rays
	private Ray ray;



	//Position Vectors 
	private Vector3 mousePosition;
	private Vector3 currentMousePosition;




	void Awake()
	{
		Instance = this;
	}
	public void Start()
	{

		if (PoolGameController.GameInstance != null) {
			cue = PoolGameController.GameInstance.cue;
			cueBall = PoolGameController.GameInstance.cueBall;

		}
		PlayerPrefs.SetFloat ("factor",0);
		orignal = gameObject.GetComponent<RectTransform> ();

		orignalPosition = orignal.position;

		if (EventScript.Instance != null) {
			EventScript.Instance.mouseEvent += dragMe;
			found = true;
		} else {
			Debug.Log ("Done ");

		}
		if (InputEventScript.Instance != null) {
			InputEventScript.Instance.mouseEvent += dragMe;
		}


		if (InputEventCanvasScript.Instance != null) {
			InputEventCanvasScript.Instance.mouseEvent += dragMe;
//			Debug.LogError ("DONE )))))))))))))))))");
		
		}



		if (CueBallCanvasScript.Instance != null) {
			Debug.Log ("Not null this is good ");
			CueBallCanvasScript.Instance.mouseEvent += dragMe;

		}

		if (CueballPlacingRegionEventScript.Instance != null) {
			CueballPlacingRegionEventScript.Instance.mouseEvent += dragMe;
		}

		if (CanvasEventScript.Instance != null) {
			CanvasEventScript.Instance.mouseEvent += dragMe;
		}
	}


	
	private void dragMe(object sender,EventArgs arguments){
		
		if (Time.timeScale != 0) {
			//gameObject.GetComponent<RectTransform> ().position = new Vector3 (gameObject.GetComponent<RectTransform>().position.x,Input.mousePosition.y,gameObject.GetComponent<RectTransform>().position.z);
			DragEvent drag = (DragEvent)arguments;
			switch (drag.action) {
			case Action.MSG_DRAG_BEGIN_IMAGE://DragBegan 
				{
					if (handler != null) {
						handler (this, new DragEnded (false, Action.NONE));
					}
					//	Debug.Log ("Drag Began ");
					cue = PoolGameController.GameInstance.cue;
					cueBall = PoolGameController.GameInstance.cueBall;


					break;
				}
			case Action.MSG_DRAGGING_IMAGE:
				{
					//	Debug.LogError ("Dragging Image Constlantly ");

					#if UNITY_EDITOR
					orignal.position = new Vector3 (orignal.position.x, Input.mousePosition.y, orignal.position.z);
					#else
					#endif
					if (orignal.localPosition.y > 0)
						orignal.localPosition = Vector3.zero;
					//	Debug.Log (gameObject.GetComponent<RectTransform> ().localPosition);
					///	Debug.Log (orignal.localPosition);
					//	Debug.Log (orignal.position);
					//	debugger.GetComponent<Text>().text=Input.touches.Length.ToString();









					if (Input.touches.Length > 0) {







						if (Input.GetTouch (0).phase == TouchPhase.Moved) {
							//			debugger.GetComponent<Text>().text += Input.GetTouch (0).deltaPosition.ToString();
							float deltaY = Input.GetTouch (0).deltaPosition.y;
							float factor = deltaY;
							if (factor < 0) {
								factor = (-1) * factor;
							}
							factor = factor / 1000.0f;
							Debug.LogError (factor);
							PlayerPrefs.SetFloat ("factor", factor);
							orignal.position = new Vector3 (orignal.position.x, orignal.position.y + deltaY, orignal.position.z);
//						Vector3 direction=(cueBall.transform.position-cue.transform.position).normalized;
//						float factor2 = (PoolGameController.MAX_DISTANCE - PoolGameController.MIN_DISTANCE)*factor
//							+ PoolGameController.MIN_DISTANCE;
//						Debug.LogError (factor2);
//						cue.transform.position = cueBall.transform.position - factor2 * direction;


							
						
					
					
					
			
						}

					}
					//	else 
					{
						float deltaY = orignal.localPosition.y;
						float factor = deltaY;
						if (factor < 0) {
							factor = factor * (-1);
						}
						factor = factor / 1000.0f;
						//	Debug.LogError (factor);
						Vector3 direction = (cueBall.transform.position - cue.transform.position).normalized;
						float factor2 = (PoolGameController.MAX_DISTANCE - PoolGameController.MIN_DISTANCE) * factor
						                + PoolGameController.MIN_DISTANCE;
						//				Debug.LogError (factor2);
						cue.transform.position = cueBall.transform.position - factor2 * direction;




			




					}
					if (handler != null) {
						handler (this, new DragEnded (false, Action.NONE));
					}
					//	Debug.Log ("Constantly dragging ");
				
					break;
				
				}
			case Action.MSG_DRAG_END_IMAGE:
				{

					break;
				}
			case Action.MSG_MOUSE_DOWN_IMAGE:
				{
				
					//Store initial mouse position
					#if UNITY_EDITOR
					mousePosition = Input.mousePosition;
					#else
				mousePosition=Input.GetTouch(0).position;
					#endif
					if (handler != null) {
						handler (this, new DragEnded (false, Action.MSG_MOUSE_DOWN_IMAGE));
					}


					break;	
				}
			case Action.MSG_MOUSE_UP_IMAGE:
				{
					Debug.LogError ("orignal.position "+orignal.position.x+" "+orignal.position.y+" "+orignal.position.z);
					Debug.LogError ("orignalPosition "+orignalPosition.x+" "+orignalPosition.y+" "+orignalPosition.z);
					float factor = orignal.localPosition.y;
					if (factor < 0)
						factor = (-1) * factor;
					factor = factor / 1000.0f;

					PlayerPrefs.SetFloat ("factor", factor);
					Debug.LogError ("Factor : "+factor);
					isFirstTouch = false;

			
					if (handler != null) {
						handler (this, new DragEnded (true, Action.MSG_MOUSE_UP_IMAGE));
					}
					if (factor >= 0.002f) {
						PoolGameController.GameInstance.factor = factor;
						StayInBound.factor = factor;
						PoolGameController.GameInstance.cueBallWasPotted = false;
						PoolGameController.GameInstance.check2 = 1;
						PoolGameController.GameInstance.cueBallCanvas.SetActive (false);
						if (PoolGameController.GameInstance.isFirstTime == true)
							PoolGameController.GameInstance.isFirstTime = false;

						PoolGameController.GameInstance.currentState = new GameStates.StrikingState (PoolGameController.GameInstance);

					}
				//	orignal.position = orignalPosition;
					orignal.localPosition = new Vector3 (0,0,0);
					break;
				}
			case Action.MSG_MOUSE_LEAVES_IMAGE:
				{
					//Debug.Log ("Mouse exits ");
					//orignal.position = orignalPosition;
					break;
				}
			case Action.MSG_MOUSE_DOWN_TABLE:
				{
					handler (this, new DragEnded (true, Action.MSG_MOUSE_DOWN_TABLE));
					break;
				}
			case Action.MSG_MOUSE_UP_TABLE:
				{
					handler (this, new DragEnded (true, Action.MSG_MOUSE_UP_TABLE));
					break;
				}

			//Canvas Events......

		
			case Action.MSG_MOUSE_CANVAS_DOWN:
				{
					if (handler != null) {
					
						handler (this, new DragEnded (false, Action.MSG_MOUSE_CANVAS_DOWN));
						Debug.LogError ("CANVAS IS IN PLACEEE");
					}
					break;
				}
			case Action.MSG_MOUSE_CANVAS_STAY:
				{
					if (handler != null) {
						handler (this, new DragEnded (false, Action.MSG_MOUSE_CANVAS_STAY));
					}
					break;
				}
			case Action.MSG_MOUSE_CANVAS_UP:
				{
					if (handler != null) {
						handler (this, new DragEnded (true, Action.MSG_MOUSE_CANVAS_UP));
					}
					break;
				}

			// Cue Ball Canvas Events
			case Action.MSG_MOUSE_CUE_BALL_CANVAS_DOWN:
				{
					if (handler != null) {
						handler (this, new DragEnded (false, Action.MSG_MOUSE_CUE_BALL_CANVAS_DOWN));
					}
					break;
				}
			case Action.MSG_MOUSE_CUE_BALL_CANVAS_UP:
				{
					if (handler != null) {
						handler (this, new DragEnded (true, Action.MSG_MOUSE_CUE_BALL_CANVAS_UP));
					}
					break;
				}
			//Region tracker

			case Action.MSG_MOUSE_INSIDE_REGION:
				{
					if (handler != null) {
						handler (this, new DragEnded (true, Action.MSG_MOUSE_INSIDE_REGION));
					}
					break;
				}
			case Action.MSG_MOUSE_OUTSIDE_REGION:
				{
					if (handler != null) {
						handler (this, new DragEnded (true, Action.MSG_MOUSE_OUTSIDE_REGION));
					}
					break;
				}
			case Action.MSG_MOUSE_DOWN_CANVAS:
				{
					if (handler != null) {
						handler (this, new DragEnded (false, Action.MSG_MOUSE_DOWN_CANVAS));
					}
					break;
				}
			case Action.MSG_MOUSE_UP_CANVAS:
				{

					if (handler != null) {
						handler (this, new DragEnded (true, Action.MSG_MOUSE_UP_CANVAS));
					}


					break;
				}

	
			}
		}
	}


	public void Update()
	{
		if (toLerp == true) {
			
			Vector3 newPosition = gameObject.GetComponent<RectTransform> ().position;
			newPosition.y = Mathf.Lerp (orignal.position.y,mousePosition.y,0.5f);
			gameObject.GetComponent<RectTransform> ().position = newPosition;
			if (newPosition.y <= mousePosition.y)
				toLerp = false;
		}
//		Debug.Log ("Image Position == " + orignal.localPosition);
	//	if (EventScript.Instance != null && found == false) {
	//		EventScript.Instance.mouseEvent += dragMe;
	//		found = true;
	//	}
	
	}


}
