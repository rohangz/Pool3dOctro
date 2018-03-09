using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SliderScript : MonoBehaviour {

	private bool isGettingDragged;
	void Start()
	{
		isGettingDragged = false;
		
	}
	void Update()
	{
		if (isGettingDragged) {
			Debug.LogError ("take action ");
			}

	}

	public void OnBeginDrag(PointerEventData data )
	{
		Debug.LogError ("Getting dragged ");
		isGettingDragged = true;


	}
	void OnMouseOver(){
		if(Input.GetMouseButtonDown(0)){
			//displayRotation.isRotating = false;
			Debug.LogError("Mouse is down");}
		
			}

}
