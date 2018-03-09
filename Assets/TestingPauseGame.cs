using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingPauseGame : MonoBehaviour {
	private GameObject obj;
	TestRunScript script;
	Rigidbody rb;
	// Use this for initialization
	void Start () {
		obj = GameObject.FindGameObjectWithTag ("Slider");
		if (obj == null) {
			Debug.LogError ("Error ");
		}
		script = obj.GetComponent<TestRunScript> ();
		rb = obj.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {

			
	}
}
