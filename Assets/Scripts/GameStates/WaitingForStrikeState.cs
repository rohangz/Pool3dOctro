	
using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

namespace GameStates
{
	public class WaitingForStrikeState  :AbstractGameObjectState
	{
		private GameObject cue;
		private GameObject cueBall;
		private GameObject mainCamera;
			
		public static int i = 0;
		private GameObject image;

		private const float X = 8;
		private const float Z = 18;
		#region Constants

		private const float firstX = 8f;
		private const float firstZMIN = -18f;
		private const float firstZMAX = -12f;
		private const float cuePositionY=9f;
		private const float cueBallPositionY=4.573f;
			
		#endregion
		private Vector3 preDirection = Vector3.zero;
		private RaycastHit hit;
		private RaycastHit hit2;
		private Ray ray;
		private Vector3 firstInputPosition;

		private PoolGameController gameController;

		private GameObject imagePanel;
		private LineRenderer line;
		private LineRenderer line2;
		private int k = 0;
		private Text text;


		private Vector3 cameraOffset;
		private Vector3 cameraRotation;

		#region booleans

		private bool isCanvasTouched = false;
		private bool isImageTouched = false;
		private bool isCueBallCanvasTouched = false;
		private bool isCueBallInRegion = false;
		private bool found = false;
		private bool isDragEnded = true;
		private bool shouldCueRotate = false;
		public  bool isFirstTouch = false;

		#endregion


		private float timer = 30.0f;

		private IEnumerator initialize ()
		{
			while (MoveImageScript.Instance == null) {	
				yield return null;
			}

			MoveImageScript.Instance.handler += OnDragEvent;
			Debug.LogError ("succesfull Initialization ");
			yield return null;
		}



		public WaitingForStrikeState (MonoBehaviour parent) : base (parent)
		{ 
			gameController = (PoolGameController)parent;
			PlayerPrefs.SetFloat ("factor", 0.0f);
			gameController.gameState = StatesOfGame.WAITING_FOR_STRIKE_STATE;
			cue = gameController.cue;
			cueBall = gameController.cueBall;
			PoolGameController.GameInstance.gameState = StatesOfGame.WAITING_FOR_STRIKE_STATE;

			line = cueBall.GetComponent<LineRenderer> ();
			line2 = gameController.GetComponent<LineRenderer> ();
			text = GameObject.FindGameObjectWithTag ("Timer").GetComponent<Text> ();
			mainCamera = gameController.mainCamera;
			cue.GetComponent<Renderer> ().enabled = true;
			image = gameController.image;
			if (MoveImageScript.Instance != null) {
				MoveImageScript.Instance.handler += OnDragEvent;

			} else
			{

			}
			imagePanel = gameController.imagePanel;
			imagePanel.SetActive (true);
			cue.transform.position = cueBall.transform.position + gameController.strikeDirection * (-1) * PoolGameController.MIN_DISTANCE;
			cue.transform.position = new Vector3 (cue.transform.position.x,9f,cue.transform.position.z);
			cue.transform.RotateAround (cueBall.transform.position, Vector3.down, 0);

			//cue.transform.RotateAround (cueBall.transform.position, Vector3.up, 0);




		}


		public bool castMyRayAndDetectTable ()
		{

			if (Input.GetMouseButton (0)) {
				RaycastHit hit;
				Ray ray = new Ray ();
				ray.origin = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				ray.direction = Vector3.down;

				if (Physics.Raycast (ray, out hit)) {
					if (hit.collider.gameObject.name == "Table")
						return true;
					else
						return false;

				} else
					return false;
			} else
				return false;

		}


		private void OnDragEvent (object sender, EventArgs arguments)
		{
			//Debug.LogError ("Entered the efvent");
			DragEnded drag = (DragEnded)arguments;
			isDragEnded = drag.value;
			switch (drag.action) {
			case Action.NONE:
				{
					shouldCueRotate = false;
					break;
				}
			case Action.MSG_MOUSE_DOWN_TABLE:
				{
					Debug.LogError (" MOUSE IS DOWN ON THE TABLE ");
					shouldCueRotate = true;
					break;
				}
			case Action.MSG_MOUSE_UP_TABLE:
				{
					Debug.LogError ("MOUSE IS UP FROM THE TABLE ");
					shouldCueRotate = false;
					break;
				}

			//Canvas Events......


			case Action.MSG_MOUSE_CANVAS_DOWN:
				{
					isCanvasTouched = true;
					break;
				}
			case Action.MSG_MOUSE_CANVAS_STAY:
				{
					isCanvasTouched = true;
					break;
				}
			case Action.MSG_MOUSE_CANVAS_UP:
				{
					isCanvasTouched = false;
					break;
				}

			//Image Events

			case Action.MSG_MOUSE_UP_IMAGE:
				{
					isImageTouched = false;
					break;
				}
			case Action.MSG_MOUSE_DOWN_IMAGE:
				{
					isImageTouched = true;
					break;
				}
			// Cue Ball Canvas Events
			case Action.MSG_MOUSE_CUE_BALL_CANVAS_DOWN:
				{
					isCueBallCanvasTouched = true;
					break;
				}
			case Action.MSG_MOUSE_CUE_BALL_CANVAS_UP:
				{
					isCueBallCanvasTouched = false;
					break;
				}
			// Region Script Events
			case Action.MSG_MOUSE_INSIDE_REGION:
				{
					isCueBallInRegion = true;
					break;
				}
			case Action.MSG_MOUSE_OUTSIDE_REGION:
				{
					isCueBallInRegion = false;
					break;
				}
			case Action.MSG_MOUSE_DOWN_CANVAS:
				{
					Debug.LogError ("event happened MOUSE IS DOWN ON CANVAS");
					break;
				}
			case Action.MSG_MOUSE_UP_CANVAS:
				{
					Debug.LogError ("event happened MOUSE IS UP ON CANVAS");
					break;
				}

			}


			if (isImageTouched == false && isCueBallCanvasTouched == false)
			{

				cueBall.GetComponent<Rigidbody> ().WakeUp ();
				float factor = PlayerPrefs.GetFloat ("factor");
				Vector3 __rotationDirection = Vector3.zero;
				var x = 0.0f;
				var __prevAngle = 0.0;
				#if UNITY_EDITOR
				if (Input.GetMouseButton (0)) 
				{
				#else
				if (Input.touches.Length > 0) {
				#endif
					if (isFirstTouch == false) 
					{
						isFirstTouch = true;
						#if UNITY_EDITOR
						firstInputPosition = Input.mousePosition;

						#else
						firstInputPosition = (Vector3)Input.GetTouch (0).position;
						#endif

					}

					Vector3 currentInputPosition;
					#if UNITY_EDITOR
					currentInputPosition = Input.mousePosition;
					#else
					currentInputPosition = (Vector3)Input.GetTouch (0).position;
					#endif

					Vector3 cuePosition = Camera.main.WorldToScreenPoint (cueBall.transform.position);
					float __angle = Vector3.Angle ((firstInputPosition - cuePosition), (currentInputPosition - cuePosition));
					Vector3 __cross = Vector3.Cross ((firstInputPosition - cuePosition), (currentInputPosition - cuePosition));
					Vector3 __direction = __cross.z > 0 ? Vector3.down : Vector3.up;

					x = __angle;
					__rotationDirection = __direction;
					#if UNITY_EDITOR
					firstInputPosition = Input.mousePosition;
					#else
					firstInputPosition = (Vector3)Input.GetTouch (0).position;
					#endif
					__prevAngle = __angle;


					if (x != 0 && isDragEnded == true) {
						var angle = x;//x=2 for touch and 75 for pc 
						gameController.strikeDirection = Quaternion.AngleAxis (angle, __rotationDirection) * gameController.strikeDirection;

						//						/cue.transform.position = cueBall.transform.position + gameController.strikeDirection * (-1) * PoolGameController.MIN_DISTANCE;
						//	cue.transform.position = new Vector3 (cue.transform.position.x, 9f, cue.transform.position.z);

						cue.transform.RotateAround (cueBall.transform.position, __rotationDirection, angle);
					}

					Debug.DrawLine (cueBall.transform.position, cueBall.transform.position + gameController.strikeDirection * 10);
					if (isDragEnded == true && factor != 0) {

					}
					if (Input.GetMouseButtonUp (0)) {
						isFirstTouch = false;
					}


				}
			}
			if (Input.GetMouseButtonUp (0)) {
				isFirstTouch = false;
			}

		}

		public override void Update ()
		{
			if (MoveImageScript.Instance != null && found == false) {
				MoveImageScript.Instance.handler += OnDragEvent;
				found = true;
			}
			if (Time.timeScale != 0) {
				if (gameController.cueBallWasPotted == true || gameController.check2 == 1) {


					gameController.cueBallCanvas.SetActive (true);
					gameController.cueBallCanvas.transform.position = Camera.main.WorldToScreenPoint (cueBall.transform.position);
			
				} else {
					gameController.cueBallCanvas.SetActive (false);
				}



				if (isCueBallCanvasTouched == true) {


					gameController.cueBallCanvas.transform.position = Input.mousePosition;
					Vector3 position = Camera.main.ScreenToWorldPoint (gameController.cueBallCanvas.transform.position);
					position = new Vector3 (position.x, cueBallPositionY, position.z);


					if (PoolGameController.GameInstance.isFirstTime == true) {
						if (position.x >= firstX) {
							position.x = firstX;
						}
						if (position.x <= (-1) * firstX) {
							position.x = (-1) * firstX;
						}
						if (position.z >= firstZMAX) {
							position.z = firstZMAX;
						}
						if (position.z <= firstZMIN) {
							position.z = firstZMIN;
						}
					} else {

						if (position.x >= X) {
							position.x = X;
						}
						if (position.z >= Z) {
							position.z = Z;
						}
						if (position.x <= (-1) * X) {
							position.x = (-1) * X;
						}
						if (position.z <= (-1) * Z) {
							position.z = (-1) * Z;
						}
					}
					cueBall.transform.position = position;

					cueBall.GetComponent<Rigidbody> ().Sleep ();
					cue.transform.position = cueBall.transform.position + gameController.strikeDirection * (-1) * PoolGameController.MIN_DISTANCE;
					cue.transform.position = new Vector3 (cue.transform.position.x, cuePositionY, cue.transform.position.z);
					cue.transform.RotateAround (cueBall.transform.position, Vector3.down, 0);

					if (cue.GetComponent<Renderer> ().enabled == false)
						cue.GetComponent<Renderer> ().enabled = true;
					

			
			
				}

			
				//		int timer2 = Mathf.FloorToInt (timer);
				//	if (timer <= 0)
				//		timer = 0;
				//	if (k == 0) {
				//			ScoreController.Instance.player1.text = PoolGameController.GameInstance.t.Minutes.ToString()+":"+PoolGameController.GameInstance.t.Seconds.ToString ();
				//	} else if (k == 1) {
				//			ScoreController.Instance.player2.text= PoolGameController.GameInstance.t.Minutes.ToString()+":"+PoolGameController.GameInstance.t.Seconds.ToString ();
				//	}

				//	if (timer > 0) {
				//		timer -= Time.deltaTime;
				//int tu;
				//		text.text = "Timer:" + PoolGameController.GameInstance.t.Minutes.ToString()+":"+PoolGameController.GameInstance.t.Seconds.ToString ();
				//	}
				////	if (timer <= 0) {
				//		timer = 30.0f;
				//		text.text="Timer:0.0";
				//		var temp = PoolGameController.GameInstance.CurrentPlayer;
				//	PoolGameController.GameInstance.CurrentPlayer = PoolGameController.GameInstance.OtherPlayer;
				//		PoolGameController.GameInstance.OtherPlayer = temp;
				//	}




				if (isImageTouched == false && isCueBallCanvasTouched == false) 
				{
					cueBall.GetComponent<Rigidbody> ().WakeUp ();
					float factor = PlayerPrefs.GetFloat ("factor");
					Vector3 __rotationDirection = Vector3.zero;
					var x = 0.0f;
					var __prevAngle = 0.0;

					#if UNITY_EDITOR
					if (Input.GetMouseButton (0)) 
					{
						#else
				if (Input.touches.Length > 0) {
						#endif
						if (isFirstTouch == false) 
						{
							isFirstTouch = true;
							#if UNITY_EDITOR
							firstInputPosition = Input.mousePosition;
				
							#else
						firstInputPosition = (Vector3)Input.GetTouch (0).position;
							#endif

						}

						Vector3 currentInputPosition;
						#if UNITY_EDITOR
						currentInputPosition = Input.mousePosition;
						#else
					currentInputPosition = (Vector3)Input.GetTouch (0).position;
						#endif

						Vector3 cuePosition = Camera.main.WorldToScreenPoint (cueBall.transform.position);
						float __angle = Vector3.Angle ((firstInputPosition - cuePosition), (currentInputPosition - cuePosition));
						Vector3 __cross = Vector3.Cross ((firstInputPosition - cuePosition), (currentInputPosition - cuePosition));
						Vector3 __direction = __cross.z > 0 ? Vector3.down : Vector3.up;
			
						x = __angle;
						__rotationDirection = __direction;
						#if UNITY_EDITOR
						firstInputPosition = Input.mousePosition;
						#else
					firstInputPosition = (Vector3)Input.GetTouch (0).position;
						#endif
						__prevAngle = __angle;
						
					}
	







					if (x != 0 && isDragEnded == true) {
						var angle = x;//x=2 for touch and 75 for pc 
						gameController.strikeDirection = Quaternion.AngleAxis (angle, __rotationDirection) * gameController.strikeDirection;

//						/cue.transform.position = cueBall.transform.position + gameController.strikeDirection * (-1) * PoolGameController.MIN_DISTANCE;
					//	cue.transform.position = new Vector3 (cue.transform.position.x, 9f, cue.transform.position.z);
					
						cue.transform.RotateAround (cueBall.transform.position, __rotationDirection, angle);
					}	
					x=0;
					Debug.DrawLine (cueBall.transform.position, cueBall.transform.position + gameController.strikeDirection * 10);
					if (isDragEnded == true && factor != 0) {
	
					}
					if (Input.GetMouseButtonUp (0)) {
						isFirstTouch = false;
					}


				}
				if (Input.GetMouseButtonUp (0)) {
					isFirstTouch = false;
				}
			}
		}





	}
}
