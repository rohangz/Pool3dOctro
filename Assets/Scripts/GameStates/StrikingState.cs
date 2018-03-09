using UnityEngine;
using System.Collections;

namespace GameStates {
	public class StrikingState : AbstractGameObjectState {
		private PoolGameController gameController;

		private GameObject cue;
		private GameObject cueBall;

		private float cueDirection = -1;
		private float speed = 7;

		private float factor;
		private LineRenderer line;
		private LineRenderer line2;


		private float K;

		public StrikingState(MonoBehaviour parent) : base(parent) { 
			gameController = (PoolGameController)parent;
			cue = gameController.cue;
			cueBall = gameController.cueBall;
			gameController.gameState = StatesOfGame.STRIKING_STATE;
			line = cueBall.GetComponent<LineRenderer> ();
			line.startWidth = 0;
			line.endWidth = 0;
			line.enabled = false;

			PoolGameController.GameInstance.gameState = StatesOfGame.STRIKING_STATE;

			factor = PlayerPrefs.GetFloat ("factor", factor);
			K = 0.1f;
		


		}

		public override void Update() {
		//	if (Input.GetButtonUp("Fire1")) {
				gameController.currentState = new GameStates.StrikeState(gameController);
			//}
		}

		public override void FixedUpdate () {
			
			var distance = Vector3.Distance(cue.transform.position, cueBall.transform.position);
			float newSpeed =speed / K;
			K = 0.1f * K;
			if(distance < PoolGameController.MIN_DISTANCE || distance > PoolGameController.MAX_DISTANCE)
				cueDirection *= -1;
			cue.transform.Translate(Vector3.down * newSpeed * cueDirection * Time.fixedDeltaTime);
		}
	}
}