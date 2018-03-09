using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GameStates{
	public class PlaceCueBallState :AbstractGameObjectState 
	{
		private PoolGameController gameController;
		private GameObject cueBall;
		private GameObject cue;
		private float timer=15.0f;



		public PlaceCueBallState(MonoBehaviour parent) : base(parent) {
			gameController = (PoolGameController)parent;
			cueBall = gameController.cueBall;
			cue = gameController.cue;
		
		
		
		}


		public override void Update()
		{
			gameController.currentState = new GameStates.WaitingForNextTurnState (gameController);
			gameController.gameState = StatesOfGame.WAITING_FOR_NEXT_PLAYER_STATE;
		
		}
		public override void FixedUpdate()
		{

		}
		public override void LateUpdate()
		{
			
		}
	}
}
