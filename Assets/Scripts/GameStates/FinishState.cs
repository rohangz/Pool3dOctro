using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


namespace GameStates{
	public class FinishState : AbstractGameObjectState {

		private PoolGameController gameController;
		private TimeSpan time;


		public FinishState(MonoBehaviour parent): base(parent){
			gameController = (PoolGameController)parent;
			time = gameController.t;
			gameController.gameState = StatesOfGame.FINISH_STATE;
			
		}
		public override void Update()
		{
		}
		public override void FixedUpdate()
		{
		}
		public override void LateUpdate()
		{
		}

}
}