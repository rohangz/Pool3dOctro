using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInputScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.touches.Length>0){
			for (int i = 0; i < Input.touches.Length; i++) {
				if (Input.GetTouch (0).phase == TouchPhase.Moved) {
					Vector2 deltaPostion = Input.GetTouch (0).deltaPosition;
					transform.Translate (deltaPostion.x*Time.deltaTime,deltaPostion.y*Time.deltaTime,0);
				}
			}
		}
	}
}
