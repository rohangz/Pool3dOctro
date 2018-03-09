using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchTesting : MonoBehaviour {
	public Text text;
	private void Start()
	{
		text.text = "";
	}
	private void Update()
	{
		if (Input.touches.Length > 0) {
			for (int i = 0; i < Input.touches.Length; i++) {
				text.text=text.text+Input.GetTouch(0).phase.ToString();
			}
		}
	}
}
