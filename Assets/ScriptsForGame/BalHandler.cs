using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalHandler : MonoBehaviour {
	private Rigidbody rigidBody;
	// Use this for initialization
	void Start () {
		rigidBody = gameObject.GetComponent<Rigidbody> ();
		rigidBody.sleepThreshold = 0.15f;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
