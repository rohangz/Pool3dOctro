using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CueRotation : MonoBehaviour {
	public GameObject cueBall;
	public GameObject cue;
	private bool isFirstTouch;
	private float angle;
	private Vector3 firstTouchPosition;
	void Start(){
		isFirstTouch = false;
		cueBall = GameObject.FindGameObjectWithTag ("Finish");
	//	cue = GameObject.FindGameObjectWithTag ("cue");
	}
	void Update(){
		rotateGameObject ();	
	}
	public void rotateGameObject()
	{
		
	/*	#if UNITY_EDITOR
		if(Input.GetMouseButton(0)){
		#else 
		if(Input.touches.Length>0){
		#endif

			if(isFirstTouch==false)
			{
				isFirstTouch=true;
				#if UNITY_EDITOR
				firstTouchPosition=Input.mousePosition;
				#else
				firstTouchPositionPosition=Input.GetTouch(0).position;
				#endif
				
			}
			Vector3 currentInputPostion;

			#if UNITY_EDITOR
			currentInputPostion=Input.mousePosition;
			#else
			currentInputPosition=Input.GetTouch(0).position;
			#endif 


			Debug.Log("cuePositionWorld =="+cue.transform.position);
			Vector3 cuePosition =Camera.main.WorldToScreenPoint(cueBall.transform.position);
			Debug.Log("cuePositionOnScreen =="+cuePosition);
			angle = Vector3.Angle ((firstTouchPosition-cuePosition),(currentInputPostion-cuePosition));
			Vector3 __cross = Vector3.Cross ((firstTouchPosition-cuePosition),(currentInputPostion-cuePosition));
			Vector3 __direction = __cross.z > 0 ? Vector3.down : Vector3.up;


			#if UNITY_EDITOR
			firstTouchPosition=Input.mousePosition;
			#else 
			firstTouchPosition=Input.GetTouch(0).position;
			#endif
			cue.transform.RotateAround (cueBall.transform.position,__direction,20.0f*angle*Time.deltaTime);

	
		}
		if (Input.GetMouseButtonUp (0)){
			isFirstTouch = false;
			angle=0;
		}*/
		
	}


}
