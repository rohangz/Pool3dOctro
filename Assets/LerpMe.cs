using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpMe : MonoBehaviour {
	public GameObject obj;
	// Use this for initialization
	void Start () {

	}
	void Update()
	{
		Vector3 newPosition = gameObject.GetComponent<RectTransform> ().position;
		newPosition.x = Mathf.Lerp
			(gameObject.GetComponent<RectTransform>().position.x,
				obj.GetComponent<RectTransform>().position.x,0.07f);
		gameObject.GetComponent<RectTransform> ().position = newPosition;
	}
	

		
	}

