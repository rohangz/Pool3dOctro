using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {
	public Text player1;
	//public Text player2;
	private Player Player1;
	//private Player Player2;


	public Text text;



	float timer=15.0f;
	public static ScoreController Instance {
		private set;
		get;
	}



	int c1=0;
	int c2=0;
	// Use this for initialization
	void Awake()
	{

		Instance = this;
	}
	void Start () {

		Player1 = PoolGameController.GameInstance.CurrentPlayer;
		text = GameObject.FindGameObjectWithTag ("Timer").GetComponent<Text> ();

	}
	public void Reset()
	{
		Player1.Reset ();
	}



	
	// Update is called once per frame
	void Update () {

		player1.text = Player1.Name + ":" + Player1.Points.ToString ();
		float minutes = PoolGameController.GameInstance.t.Minutes;
		float seconds = PoolGameController.GameInstance.t.Seconds;

		string time = minutes.ToString () + ":"+(seconds<10?"0"+seconds.ToString():seconds.ToString());
		text.text = time;

	//	if (PoolGameController.GameInstance.CurrentPlayer != null && c1 == 0) {
		//	Player1 = PoolGameController.GameInstance.CurrentPlayer;
		//	c1 = 1;
	//	}
	//	if (PoolGameController.GameInstance.OtherPlayer != null && c2==0) {
		//	Player2 = PoolGameController.GameInstance.OtherPlayer;
		//	c2 = 1;
		//}
		//var text = GetComponent<UnityEngine.UI.Text>();
	//	var currentPlayer = PoolGameController.GameInstance.CurrentPlayer;
	//	var otherPlayer = PoolGameController.GameInstance.OtherPlayer;
	//	text.text = String.Format("* {0} - {1}\n{2} - {3}", currentPlayer.Name, currentPlayer.Points, otherPlayer.Name, otherPlayer.Points);
	//	player1.text = Player1.Name+":"+Player1.Points.ToString();
	//	player2.text = Player2.Name + ":" + Player2.Points.ToString ();


	//	if (Player1 == PoolGameController.GameInstance.CurrentPlayer) {
	//		player1.GetComponentInParent<Image> ().color = Color.green;
	//		player2.GetComponentInParent<Image> ().color = Color.white;
		//}
	//	else if (Player2 == PoolGameController.GameInstance.CurrentPlayer) {
	//		player2.GetComponentInParent<Image> ().color = Color.green;
	//		player1.GetComponentInParent<Image> ().color = Color.white;
	//	}


	/*	if (Player1 == PoolGameController.GameInstance.CurrentPlayer) {
			Image player1Transform = player1.GetComponentInParent<Image> ();
			if (player1Transform != null) {
				Color color = new Color ();

					
				if (timer > 0) {
					if (timer <= 15 && timer >= 12) {
						ColorUtility.TryParseHtmlString ("#008000",out color);
						player1Transform.color = color;
					
					} else if (timer <= 12 && timer >= 9) {
						ColorUtility.TryParseHtmlString ("#32CD32",out color);
						player1Transform.color = color;
						
						
					} else if (timer <= 9 && timer >= 6) {


						ColorUtility.TryParseHtmlString ("#FFFF00",out color);
						player1Transform.color = color;

					} else if (timer <= 6 && timer >= 3) {


						ColorUtility.TryParseHtmlString ("#FFA500",out color);
						player1Transform.color = color;
					} else if (timer <= 3 && timer >= 0) {

						ColorUtility.TryParseHtmlString ("#FF0000",out color);
						player1Transform.color = color;
					}
					timer -= Time.deltaTime;
				}
				if (timer <= 0) {
					player1Transform.color = Color.white;
					var temp = PoolGameController.GameInstance.CurrentPlayer;
					PoolGameController.GameInstance.CurrentPlayer= PoolGameController.GameInstance.OtherPlayer;
					PoolGameController.GameInstance.OtherPlayer = temp;
					timer = 15.0f;
				}
			}
		}
		else if (Player2 == PoolGameController.GameInstance.CurrentPlayer) {
			Image player2Transform = player2.GetComponentInParent<Image> ();
			if (player2Transform != null) {

				if (timer > 0) {
					Color color = new Color ();
					if (timer <= 15 && timer >= 12) {
						ColorUtility.TryParseHtmlString ("#008000",out color);
						player2Transform.color = color;

					} else if (timer <= 12 && timer >= 9) {
						ColorUtility.TryParseHtmlString ("#32CD32",out color);
						player2Transform.color = color;


					} else if (timer <= 9 && timer >= 6) {


						ColorUtility.TryParseHtmlString ("#FFFF00",out color);
						player2Transform.color = color;

					} else if (timer <= 6 && timer >= 3) {


						ColorUtility.TryParseHtmlString ("#FFA500",out color);
						player2Transform.color = color;
					} else if (timer <= 3 && timer >= 0) {

						ColorUtility.TryParseHtmlString ("#FF0000",out color);
						player2Transform.color = color;
					}
					timer -= Time.deltaTime;

				}
				if (timer <= 0) {
					player2Transform.color = Color.white;
					var temp = PoolGameController.GameInstance.CurrentPlayer;
					PoolGameController.GameInstance.CurrentPlayer= PoolGameController.GameInstance.OtherPlayer;
					PoolGameController.GameInstance.OtherPlayer = temp;
					timer = 15.0f;
				}
			}
		

		}*/

	}
}
