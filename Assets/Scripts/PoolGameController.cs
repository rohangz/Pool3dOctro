using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using GameStates;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public enum StatesOfGame
{
	WAITING_FOR_STRIKE_STATE,
	STRIKING_STATE,
	STRIKE_STATE,
	WAITING_FOR_NEXT_PLAYER_STATE,
	PLACE_CUE_BALL_STATE,
	FINISH_STATE
}
public class PoolGameController : MonoBehaviour {

	#region ObjectsToLoad 

	public GameObject poolTable;
	public GameObject cue;
	public GameObject cueBall;
	public GameObject redBalls;

	public GameObject canvas;
	#endregion





	#region timers 

	public float timer=0;
	public int timerMinutes=0;
	public int timerSeconds=0;
	public TimeSpan t;
	#endregion


	#region others
	public GameObject mainCamera;
	public GameObject scoreBar;
	public GameObject winnerMessage;
	public static Vector3 cuePosition;
	public float factor;
	public StatesOfGame gameState;
	public GameObject image;
	public GameObject imagePanel;
	public GameObject cueBallCanvas;
	public GameObject pausePanel;
	public GameObject cueBallPredictionSprite;

	#endregion


	#region check
	public int check = 0;
	// check is used for knowing that cueBall was potted in order to  change the
	// player if even if a red ball was potted

	public int check2 = 1;
	// for giving the privellage of moving the ball, incase the other player was 
	// unable to hit a red ball
	#endregion

	public float maxForce;
	public float minForce;
	public Vector3 strikeDirection;

	public const float MIN_DISTANCE = 27.5f;
	public const float MAX_DISTANCE = 50f;
	
	public IGameObjectState currentState;

	public Player CurrentPlayer;
	public Player OtherPlayer;

	public GameObject currentCollectedBalls;
	public GameObject otherCollectedBalls;

	public LineRenderer line3;



//	public Text text;

	#region booleans

	public bool currentPlayerContinuesToPlay = false;
	public bool cueBallWasPotted = false;
	public bool isFirstTime=true;
	private bool isGamePaused = false;


	#endregion

	#region PauseGameState

	public PauseGameState pausedGame {
		private set;
		get;
	}

	#endregion



	#region reset

	private Vector3 cueResetPosition;
	private Vector3 cueBallResetPosition;
	private List<Vector3> redBallsResetPosition;	
	private Vector3 cueResetRotation;
	private GameObject collectionBox;
	private Vector3 resetStrikeDirection;




	public void Reset()
	{

		SceneManager.LoadSceneAsync(1);

		//cue.transform.position = cueResetPosition;
		//strikeDirection = resetStrikeDirection;
//		cueBall.SetActive (false);
//		cueBall.transform.position = cueBallResetPosition;
//		cueBall.SetActive (true);
//		//cue.transform.RotateAround (cueBall.transform.position-1f*strikeDirection,Vector3.down,0);
//		cueBall.GetComponent<Rigidbody> ().Sleep ();
//
//
//		for (int i = 0; i<redBallsResetPosition.Count; i++)
//		{
//			collectionBox.transform.GetChild (0).position = redBallsResetPosition [i];
//			collectionBox.transform.GetChild (0).transform.gameObject.SetActive (true);
//			collectionBox.transform.GetChild (0).GetComponent<Rigidbody> ().Sleep ();
//			collectionBox.transform.GetChild (0).transform.parent = redBalls.transform;
//
//
//		}
//
//	
//
//		if (StayInBound.Instance != null) {
//			StayInBound.resetBall = true;
//		}
//		PoolGameController.GameInstance.currentState = new GameStates.WaitingForStrikeState(PoolGameController.GameInstance);
//		cue.SetActive (true);
//		//cue.GetComponent<Renderer> ().enabled = true;
//		//cue.transform.rotation = Quaternion.Euler (cueResetRotation);
//
//		winnerMessage.GetComponent<Canvas> ().enabled = false;
//		PoolGameController.GameInstance.isFirstTime = true;
//		ScoreController.Instance.Reset ();
//		timer = 0;
	}


	#endregion 












	// This is kinda hacky but works
	static public PoolGameController GameInstance {
		get;
		private set;
	}
	void Awake()
	{	
		GameInstance = this;
		pausedGame = null;
//		Input.simulateMouseWithTouches = true;
		if (cue == null) {
		}
		CurrentPlayer = new Player("John","Player1CollectedBalls");
		line3 = gameObject.GetComponent<LineRenderer> ();
		if (line3 == null) {
			Debug.LogError ("Line rendered error ");
		}



		
	}
	void Start() {
		collectionBox = GameObject.FindGameObjectWithTag ("CollectionBox");
		if (canvas.activeInHierarchy ==false) {
			Debug.LogError ("canvas is not active");
			canvas.SetActive (true);
		}
		if (poolTable.activeInHierarchy == false) {
			poolTable.SetActive (true);
		}

		if (cueBall.activeInHierarchy == false) {
			cueBall.SetActive (true);
		}

		if (cue.activeInHierarchy == false) {
			cue.SetActive (true);
		}

		if (redBalls.activeInHierarchy == false) {
			redBalls.SetActive (true);
		}
		if (cueBallPredictionSprite == null) {
			Debug.LogError ("cueBAllPrediction sprite is not present");
		}
		if (cueBallPredictionSprite != null) {
			cueBallPredictionSprite.SetActive (false);
		}


	
		#region resetVariables

		redBallsResetPosition=new List<Vector3>();
		cueResetPosition = cue.transform.position;
		cueResetRotation=cue.transform.rotation.eulerAngles;
		resetStrikeDirection=PoolGameController.GameInstance.strikeDirection;
		for(int i=0;i<redBalls.transform.childCount;i++)
		{
			redBallsResetPosition.Add(redBalls.transform.GetChild(i).position);
			Debug.Log(redBallsResetPosition[i]);
		}

		#endregion
		factor = 0;
		cuePosition =Vector3.zero;
		strikeDirection = Vector3.forward;
		CurrentPlayer = new Player ("John","Player1CollectedBalls");
		//OtherPlayer = new Player("Doe","Player2CollectedBalls");
		imagePanel = GameObject.FindGameObjectWithTag ("imagePanel");
		imagePanel.SetActive (false);
		image = GameObject.FindGameObjectWithTag ("cueImage");
		if (image != null) {
			Debug.LogError (image.name);
		}


		if (cueBallCanvas==null) {
			Debug.LogError ("Not found error ");	
		}

		winnerMessage.GetComponent<Canvas>().enabled = false;
		gameState = StatesOfGame.WAITING_FOR_STRIKE_STATE;

		currentState = new GameStates.WaitingForStrikeState(this);
	
	}






	void Update() {
		currentState.Update();
		if (PoolGameController.GameInstance.gameState != StatesOfGame.FINISH_STATE) {
			timer += Time.deltaTime;
			t = TimeSpan.FromSeconds (timer);
		}
	//	timerMinutes = Mathf.FloorToInt (timer / 60.0f);
	}

	void FixedUpdate() {
		currentState.FixedUpdate();
	}

	void LateUpdate() {
		currentState.LateUpdate();
	}

	public void BallPocketed(int ballNumber) {
		Debug.Log ("Cue ball was pocketed "+ballNumber);
		currentPlayerContinuesToPlay = true;
		CurrentPlayer.Collect(ballNumber);
	}

	public void NextPlayer() {
		
		
		if (currentPlayerContinuesToPlay) {
			currentPlayerContinuesToPlay = false;
			Debug.Log(CurrentPlayer.Name + " continues to play");
			return;
		}

		Debug.Log(OtherPlayer.Name + " will play");
		var aux = CurrentPlayer;
		CurrentPlayer = OtherPlayer;
		OtherPlayer = aux;
	}

	public void EndMatch() {
		Player winner = null;
		//if (CurrentPlayer.Points > OtherPlayer.Points)
		//	winner = CurrentPlayer; 
	//	else if (CurrentPlayer.Points < OtherPlayer.Points)
	//	PoolGameController.GameInstance.currentState=new GameStates.FinishState(PoolGameController.GameInstance);
		//	winner = OtherPlayer;
		winner=CurrentPlayer;
		var msg = "Game Over\n";

		if (winner != null)
		//	msg += string.Format("The winner is '{0}'", winner.Name);
			msg+="Time taken by "+winner.Name +"is "+PoolGameController.GameInstance.t.Minutes.ToString()+":"+PoolGameController.GameInstance.t.Seconds.ToString();
		else
			msg += "It was a draw!";

		var text = winnerMessage.GetComponentInChildren<UnityEngine.UI.Text>();
		text.text = msg;
		winnerMessage.GetComponent<Canvas>().enabled = true;
	}
	public void OnClickLeftButton()
	{
		PlayerPrefs.SetFloat ("MoveCue",1.0f);
	}
	public void OnClickRightButton()
	{
		PlayerPrefs.SetFloat ("MoveCue",-1.0f);
	}
	public void OnClickStop()
	{
		PlayerPrefs.SetFloat ("MoveCue",0);
	}




}
