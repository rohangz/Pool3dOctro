using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnClickButtonEventsScript : MonoBehaviour {

	private AsyncOperation asynC;

	public void PressToPlayAsync()
	{
		StartCoroutine (loadLevel());	
	}

	IEnumerator loadLevel()
	{
		asynC = Application.LoadLevelAsync (1);
		while (!asynC.isDone) {
			yield return null;
		}
	}
	void Update()
	{
	}
}
