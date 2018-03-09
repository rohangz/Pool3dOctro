using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayer {
	public string name { private set; get;}
	public bool isPlayerTurn { private set; get;}
	public int score { private set; get;}
	public GamePlayer()
	{
		this.name = "";
		this.isPlayerTurn = false;
		score = 0;
	}
	public GamePlayer(string name,bool isPlayerTurn=false)
	{
		this.name = name;
		this.isPlayerTurn = isPlayerTurn;
		score = 0;
	}
	public void isMyTurn(bool myTurn=false)
	{
		this.isPlayerTurn = myTurn;
	}


}
