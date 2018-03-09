using UnityEngine;
using System.Collections;

namespace GameStates {
	public class WaitingForNextTurnState : AbstractGameObjectState {
		private PoolGameController gameController;
		private GameObject cue;
		private GameObject cueBall;
		private GameObject redBalls;
		private GameObject mainCamera;

		private Vector3 cameraOffset;
		private Vector3 cueOffset;
		private Quaternion cameraRotation;
		private Quaternion cueRotation;

		public WaitingForNextTurnState(MonoBehaviour parent) : base(parent) {
			gameController = (PoolGameController)parent;
			gameController.gameState = StatesOfGame.WAITING_FOR_NEXT_PLAYER_STATE;

			cue = gameController.cue;
			cueBall = gameController.cueBall;
			redBalls = gameController.redBalls;
			mainCamera = gameController.mainCamera;

			PoolGameController.GameInstance.gameState = StatesOfGame.WAITING_FOR_NEXT_PLAYER_STATE;

			cue.transform.position = cueBall.transform.position + gameController.strikeDirection * (-1) * PoolGameController.MIN_DISTANCE;
			cue.transform.position = new Vector3 (cue.transform.position.x,9f,cue.transform.position.z);
			cue.transform.RotateAround (cueBall.transform.position, Vector3.down, 0);


			cameraOffset = cueBall.transform.position - mainCamera.transform.position;
			cameraRotation = mainCamera.transform.rotation;
			cueOffset = cueBall.transform.position - cue.transform.position;
			cueRotation = cue.transform.rotation;
			Debug.Log ("waiting for next Player ");
		}

		public override void FixedUpdate() {
//			Debug.Log(redBalls.GetComponentsInChildren<Transform>().Length);
			if (redBalls.GetComponentsInChildren<Transform>().Length == 1) {
				gameController.EndMatch();
			} else {
				var cueBallBody = cueBall.GetComponent<Rigidbody>();
				if (!(cueBallBody.IsSleeping() || cueBallBody.velocity == Vector3.zero))
					return;

				foreach (var rigidbody in redBalls.GetComponentsInChildren<Rigidbody>()) {
					if (!(rigidbody.IsSleeping() || rigidbody.velocity == Vector3.zero))
						return;
				}
				if (PoolGameController.GameInstance.check == 1) {
						PoolGameController.GameInstance.check = 0;
						PoolGameController.GameInstance.currentPlayerContinuesToPlay = false;

				}

			//	gameController.NextPlayer();

				// If all balls are sleeping, time for the next turn
				// This is kinda hacky but gets the job done
				gameController.currentState = new WaitingForStrikeState(gameController);
			}
		}

		public override void LateUpdate() {
			//mainCamera.transform.position = cueBall.transform.position - cameraOffset;
			//this is mainCamera 2
		//	mainCamera.transform.rotation = cameraRotation;

			cue.transform.position = cueBall.transform.position - cueOffset;
			cue.transform.rotation = cueRotation;
		}
	}
}
