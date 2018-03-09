using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRunScript : MonoBehaviour {
	Vector3 preVelocity;
	Rigidbody rb;
	float force;
	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Rigidbody> ().AddForce (10*Vector3.right);
		Debug.Log ("force is adde to the vector ");
		rb = gameObject.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
	
			Time.timeScale = 0;
		
		}

		if (Input.GetKeyUp (KeyCode.Space)) {


			Time.timeScale = 50;
		
		}

	}
}
