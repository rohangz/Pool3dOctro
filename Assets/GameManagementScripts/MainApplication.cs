using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;


public class MainApplication :MonoBehaviour {

	public GameObject panel;
	private PoolGameController gameController;
	private static MainApplication instance;
	public static MainApplication Instance
	{
		get 
		{
			if (instance == null)
			{
				instance = (MainApplication)FindObjectOfType (typeof(MainApplication))as MainApplication;
				if (FindObjectsOfType (typeof(MainApplication)).Length > 1)
				{
					return null;
				}
				if (instance == null) 
				{
					GameObject singleton = new GameObject ();
					instance = singleton.AddComponent<MainApplication> ();
					singleton.name="singleTonMainApplication";
					DontDestroyOnLoad (singleton);
					return instance;

				}
				return instance;
			}
			return instance;
		}
	}


	private MainApplication()
	{
	}








	void Start()
	{
		if (panel == null) {
			GameObject.Instantiate (panel);
		}
		else 
		{
			panel.SetActive (true);
		}

	}





	void Awake()
	{

	}














}
