using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuePosition : MonoBehaviour {
	Vector3 orignalPosition;
	public GameObject cueBall;
	private Vector3 direction;
	private Vector3 cueBallDirection;

	void Awake()
	{
		cueBallDirection=new Vector3(0,0.5354336f,-13.7f);
	}
	// Use this for initialization
	void Start () {
		
		cueBall = GameObject.FindGameObjectWithTag ("CueBall");
	//	gameObject.transform.position = cueBall.transform.position + PoolGameController.GameInstance.strikeDirection*(28.5f);
	//	gameObject.transform.position = new Vector3 (gameObject.transform.position.x,4.55f,gameObject.transform.position.z);
	//	gameObject.transform.RotateAround (cueBall.transform.position, Vector3.down, 0);
	}
	
	// Update is called once per frame
	void Update () {
//		direction = (cueBall.transform.position - gameObject.transform.position).normalized;

	
	}
	public void OnEnable(){
//		Debug.LogError ("Cue is active ");

	}


	public void OnDisable(){
//		Debug.LogError ("Cue is not active ");
	}





}
