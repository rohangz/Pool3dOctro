using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundTesting : MonoBehaviour {
	public GameObject target;
public float angle=1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		angle =1 * 75 * Time.deltaTime;
		gameObject.transform.RotateAround (target.transform.position,Vector3.up,angle);
	}
}
