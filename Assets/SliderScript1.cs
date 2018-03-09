using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SliderScript1 : MonoBehaviour {
	float Speed;
	public SliderFinal slider;
	public SliderScript1()
	{
		slider = new SliderFinal ();
	}
	public void onDragStarting()
	{
		Debug.Log ("drag started ");
	}
	public void dragged()
	{
		Debug.Log ("slider is getting dragged ");
	}
	public void dragHasEnded()
	{
		Debug.Log ("dragged ended ");
		slider.hasDragEnded = true;
	}
	public void OnVlueChanged()
	{
		//Debug.Log ("value of slider is changed ");
	}
	public void speed(float newSpeed)
	{
		Speed = newSpeed;
	}
}
