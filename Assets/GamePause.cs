using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GamePause : MonoBehaviour {

	private bool pause = false;
	void Start()
	{
		gameObject.GetComponentInChildren<Text>().text="Pause";
	}

	public void Pause()
	{
		if (pause == true) {
			Time.timeScale = 1;
			gameObject.GetComponentInChildren<Text> ().text = "Pause";
			pause = false;
		}
		else if (pause == false) {
			Time.timeScale = 0;
			gameObject.GetComponentInChildren<Text>().text="Resume";
			pause = true;
		}
			
	}

	public void Resume()
	{
		Time.timeScale = 1;
		gameObject.GetComponentInChildren<Text>().text="Resume";
	}
}
