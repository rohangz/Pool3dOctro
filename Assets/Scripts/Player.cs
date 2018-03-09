using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Player {
	private IList<Int32> ballsCollected = new List<Int32>();
	private GameObject panel;
	public void Reset()
	{
		
		ballsCollected.Clear ();
		ballsCollected = new List<Int32> ();
		for (int i = 0; i < panel.transform.childCount; i++) {
			Transform ithChild = panel.transform.GetChild (i);
			Transform childText = ithChild.GetChild (0);
			childText.GetComponent<Text> ().text = "";
			ithChild.GetComponent<Image> ().sprite = null;

		}
	}


	public Player(string name,string panelName) {
		Name = name;
		panel = GameObject.Find (panelName);
		if (panel == null) {
			Debug.LogError ("Error occure panel not found for "+name);
		}

	
	}

	public string Name {
		get;
		private set;
	}

	public int Points {
		
		get { return ballsCollected.Count; }
	}

	public void Collect(int ballNumber) {
		Debug.Log(Name + " collected ball " + ballNumber);
		ballsCollected.Add(ballNumber);
		Transform ithChild = panel.transform.GetChild (ballsCollected.Count - 1);
		Image image = ithChild.GetComponent<Image> ();
		//image.sprite = GameObject.FindGameObjectWithTag ("Sprite").GetComponent<SpriteRenderer>().sprite;

		//Needs to change 
		image.sprite=GameObject.Find("Ball"+ballNumber.ToString()).GetComponent<SpriteRenderer>().sprite;
	
		Transform childText = ithChild.GetChild (0);
		//childText.GetComponent<Text>().text = ballNumber.ToString ();

		}


}
