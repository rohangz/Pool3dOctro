using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideCue : MonoBehaviour {
	private bool dragCue;
	private RectTransform myRectTransform;

	void Start()
	{
		dragCue = false;
		myRectTransform = gameObject.GetComponent<RectTransform> ();
	}

	// Update is called once per frame
	void Update () {



		if (Input.GetButtonDown("Fire1"))
		{
			Debug.Log ("is drag set to true ");
			dragCue = true;
		}
	//	Debug.Log ("position == "+myRectTransform.localPosition);
	////	if (Input.GetButtonUp ("Fire1")) {
		//	Debug.Log ("mouse pressed up ");
//		}
		if (dragCue && myRectTransform.localPosition.y > 0 && Input.GetButtonUp("Fire1")) {
			myRectTransform.localPosition = new Vector3 (myRectTransform.localPosition.x,0,myRectTransform.localPosition.z);
			dragCue = false;
		}
	//	if (myRectTransform.localPosition.y == 0)
	//		dragCue = false;
	/*	if (dragCue==true && myRectTransform.localPosition.y>0)
		{
			myRectTransform.localPosition = new Vector3 (myRectTransform.localPosition.x,0,myRectTransform.localPosition.z);
			if (Input.GetMouseButtonUp (0))
				dragCue = false;
			
		}
		if (myRectTransform.localPosition.y <= 0)
			myRectTransform.localPosition = new Vector3 (myRectTransform.localPosition.x,0,myRectTransform.localPosition.z);
		if (Input.GetMouseButtonUp (0))
			dragCue = false;
*/
	}
}
