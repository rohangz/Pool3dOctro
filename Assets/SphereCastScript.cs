using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereCastScript : MonoBehaviour {

	private StatesOfGame gameState;
	private LineRenderer line;
	public static SphereCastScript Instance;



	void Awake()
	{
		Instance = this;
	}
	void Start()
	{
		gameState = PoolGameController.GameInstance.gameState;
		line = gameObject.GetComponent<LineRenderer> ();
	}
	void Update(){


		gameState = PoolGameController.GameInstance.gameState;
		switch (gameState) {
		case StatesOfGame.STRIKE_STATE:
			{
				break;
			}
		case StatesOfGame.STRIKING_STATE:
			{
				break;
			}
		case StatesOfGame.WAITING_FOR_NEXT_PLAYER_STATE:
			{
				break;
			}
		case StatesOfGame.WAITING_FOR_STRIKE_STATE:
			{
			/*(	RaycastHit hit;
				Ray ray = new Ray ();
				ray.origin = gameObject.transform.position;
				ray.direction = PoolGameController.GameInstance.strikeDirection;
				if (Physics.Raycast(ray,out hit)) {
					if (hit.collider.tag == "redball") {
						
						line.SetPosition (0, gameObject.transform.position);
						line.SetPosition (1, hit.point);
						Debug.LogError (hit.point+"+++++++++++++++++++"+hit.collider.transform.position);
						//line.SetPosition (2, hit.point);
						line.SetPosition (2, hit.collider.gameObject.transform.position);

						Vector3 direction = (hit.point - hit.collider.gameObject.transform.position).normalized;
						direction = direction * (-1);
						Vector3 desiredPoint = hit.collider.gameObject.transform.position - 2.0f * direction;
						line.SetPosition (3, desiredPoint);
						line.startWidth = 1;
						line.endWidth = 0;
						line.startColor = Color.white;
						line.endColor = Color.white;

					}
					else {
						line.SetPosition (2, Vector3.zero);
						line.SetPosition (3, Vector3.zero);
					//	line.SetPosition (4, Vector3.zero);
					}
				}*/
				break;
			}
		}

	}
}
