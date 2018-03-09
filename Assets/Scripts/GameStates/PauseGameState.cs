using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GameStates{
	/*public class PauseGameState : AbstractGameObjectState {

		private PoolGameController gameController;


		public PauseGameState(MonoBehaviour parent): base(parent){
			gameController = (PoolGameController)parent;

		}*/

//}

	public class PauseGameState: MonoBehaviour{
		public AbstractGameObjectState gameState {
			private set;
			get;
		}

		public StatesOfGame stateOfGame {
			private set;
			get;
		}
		public PauseGameState()
		{
			
		}

	
	
	}


}