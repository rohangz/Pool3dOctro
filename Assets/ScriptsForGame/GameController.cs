using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	public Text player1Score;
	public Text player2Score;
	private GamePlayer player1;
	private GamePlayer player2;
	// Use this for initialization
	void Start () 
	{
		player1 = new GamePlayer ("John",true);
		player2 = new GamePlayer ("Axle");

		player1Score.text = player1.name+":"+player1.score.ToString();
		player2Score.text = player2.name+":"+player2.score.ToString();

	}
	void Update()
	{
		if (Input.GetButtonDown ("Fire1")) {
			Debug.Log ("Code for this is to be written ");
		}
		if (Input.GetButtonUp ("Fire1")) {
			Debug.Log ("Code for this is to be written your mouse button is up ");
		}
		if (player1.isPlayerTurn == true) {
			player1.isMyTurn ();

			//Game Logic to be written

			player2.isMyTurn (true);
		}
		else if (player2.isPlayerTurn == true) {
			player2.isMyTurn ();

			//Game Logic to be written 

			player1.isMyTurn (true);
		}
	}

}
