using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerbar : MonoBehaviour {
	private float MIN_SCALE = 0.01f;
	private float MAX_SCALE = 1.0f;
	private bool isGrowing = true;
	private float rectX;
	private float rectZ;
	// Use this for initialization
	void Start () {
		rectX = gameObject.GetComponent<RectTransform> ().localScale.x;
		rectZ = gameObject.GetComponent<RectTransform> ().localScale.z;
		
	}
	
	// Update is called once per frame
	void Update () {
		if (gameObject.GetComponent<RectTransform> ().localScale.y <= MIN_SCALE)
			isGrowing = true;
		else if (gameObject.GetComponent<RectTransform> ().localScale.y >= MAX_SCALE)
			isGrowing = false;	


		float yScale = gameObject.GetComponent<RectTransform> ().localScale.y;


		if (isGrowing) {
			yScale = yScale + 0.077f * yScale;
			gameObject.GetComponent<RectTransform> ().localScale = new Vector3 (rectX,yScale,rectZ);
		} else {
			yScale = yScale - 0.077f * yScale;
			gameObject.GetComponent<RectTransform> ().localScale = new Vector3 (rectX,yScale,rectZ);
		}
	}
}
