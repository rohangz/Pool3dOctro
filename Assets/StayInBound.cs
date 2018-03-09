using System.Collections;
using System.Collections.Generic;
using UnityEngine;
class Velocity 
{
	public float x;
	public float y;
	public float z;

	private const float lineFactor=2.0f;



	public Velocity(float x=0,float y=0,float z=0)
	{
		this.x = x;
		this.y = y;
		this.z = z;
	}
	public Velocity(Vector3 velocity)
	{
		this.x = velocity.x;
		this.y = velocity.y;
		this.z = velocity.z;
	}

}
public class StayInBound : MonoBehaviour {
	private Vector3 orignalPosition;
	private GameObject obj;
	private bool outOfBound;

	public static bool resetBall=false;

	public static StayInBound Instance {
		private set;
		get;
	}


	public static string isCollidingWith;
	public static Vector3 direction;
	public static float factor;
	private Rigidbody rb;

	private Ray ray;
	private RaycastHit hit;


	private Velocity velocityBeforeCollisionCueBall;
	private Velocity velocityAfterCollisionCueBall;
	private Velocity velocityAfterCollisionRedBall;


	private GameObject cue;
	private Vector3 requiredDirection;


	#region LineRenderer

	private LineRenderer line;
	private LineRenderer line2;
	private LineRenderer line3;

	#endregion


	private Vector3 myDirection;
	private GameObject cueBallPredictionSprite;


	#region Constants
		
	private const float minLengthOfLine = 0.0f;
	private const float maxLenghtOfLine = 3.0f;
	private const float raduisOfSphereCast = 0.35f;
	private const float line3Y = 5.0f;

	#endregion



	[SerializeField]
	Vector3 axisOfRotation;

	void Awake()
	{
		Instance = this;
		direction = Vector3.zero;
		factor = 0;
		isCollidingWith = "";
		rb = gameObject.GetComponent<Rigidbody> ();
		rb.velocity = Vector3.zero;
		rb.angularVelocity = Vector3.zero;
	}


	// Use this for initialization
	void Start () {

		outOfBound = false;
		obj = GameObject.FindGameObjectWithTag ("Finish");
		if (obj != null) {
			Debug.Log("Found cube");
			Debug.Log(obj.transform.position);

			Debug.Log (obj.transform.localPosition);
		}
		orignalPosition = gameObject.transform.position;
		line = gameObject.GetComponent<LineRenderer> ();


		cue = PoolGameController.GameInstance.cue;
		line2 = cue.GetComponent<LineRenderer> ();
		if (line2 == null) {
			Debug.Log ("Line render not present");
		}
		if (PoolGameController.GameInstance != null) {
			cueBallPredictionSprite = PoolGameController.GameInstance.cueBallPredictionSprite;
			line3 = PoolGameController.GameInstance.line3;
		}


	}
	
	// Update is called once per frame
	void Update () {
		if(gameObject.transform.position.z>=40.0f || gameObject.transform.position.z<=-40 || gameObject.transform.position.x>=22 || gameObject.transform.position.x<=-22)
		{
			gameObject.transform.position = orignalPosition;
			gameObject.GetComponent<Rigidbody> ().Sleep ();
		}

		string name = "";
	
		if (PoolGameController.GameInstance.gameState == StatesOfGame.WAITING_FOR_STRIKE_STATE )
		{	
			line.enabled = true;
			ray = new Ray ();
			ray.origin = gameObject.transform.position;
			ray.direction = PoolGameController.GameInstance.strikeDirection;
			Vector3 direction = Vector3.zero;
			Vector3 directionToCalculate;
			if (Physics.SphereCast (ray,raduisOfSphereCast, out hit)) {


				if (hit.collider.gameObject.tag == "redball") 
				{



					line3.enabled = true;
					line2.enabled = true;
					directionToCalculate = hit.point;

					#region RegionForChangingLengthOfLine1

					float lenghtOfLine3 = Vector3.Angle ((hit.point-gameObject.transform.position),(hit.collider.gameObject.transform.position-
						gameObject.transform.position));

					#endregion

					line.SetPosition (0, gameObject.transform.position);
					line.SetPosition (1, cueBallPredictionSprite.transform.position);
					direction = (hit.collider.gameObject.transform.position - hit.point).normalized;
					float lengthToDraw = ((maxLenghtOfLine - minLengthOfLine) /(2f*lenghtOfLine3)+ minLengthOfLine);
					if (lengthToDraw > maxLenghtOfLine+15f)
						lengthToDraw = maxLenghtOfLine;
					Vector3 desiredPoint = hit.collider.gameObject.transform.position +10.0f* direction;
					//line.SetPosition (2, desiredPoint);
					Vector3 initialPointLine3=hit.collider.gameObject.transform.position-0.6f*direction;
					initialPointLine3.y = 6f;
					line3.SetPosition (0, new Vector3(hit.collider.gameObject.transform.position.x,line3Y,hit.collider.gameObject.transform.position.z));


				


					line3.SetPosition (1, new Vector3(desiredPoint.x,line3Y,desiredPoint.z));


					line.startWidth = 0.3f;
					line.endWidth = 0.0f;
					line3.startWidth = 0.3f;
					line3.endWidth = 0.0f;
					name = hit.collider.gameObject.name;


				

					Vector3 baseLineDirection = (hit.collider.gameObject.transform.position - gameObject.transform.position);
					Vector3 hitPointDirection = (hit.point - gameObject.transform.position);
				
					baseLineDirection.y = 0;
				 	hitPointDirection.y = 0;

					Vector3 cross = Vector3.Cross (baseLineDirection,hitPointDirection);
					cross = cross.normalized;

		
		

		
					#region FinalCode


					cueBallPredictionSprite.SetActive(true);
					float lengthOfLine=Vector3.Angle((hit.collider.gameObject.transform.position-gameObject.transform.position),
						(hit.point-gameObject.transform.position)
					);
				
					Debug.Log("lengthOfLine:=="+lengthOfLine);
					Vector3 hitToCenter=hit.collider.gameObject.transform.position-hit.point;
					Vector3 centerOfTheCast=hit.point-(raduisOfSphereCast+0.4f)*hitToCenter.normalized;
					cueBallPredictionSprite.transform.position=new Vector3(centerOfTheCast.x,centerOfTheCast.y,centerOfTheCast.z);
					float angleInDegrees=0;
					if(cross.Equals(Vector3.up))
					{
						angleInDegrees=-90;
					}
					else if(cross.Equals(Vector3.down))
					{
						angleInDegrees=90;
					}

					hitToCenter=Quaternion.AngleAxis(angleInDegrees,Vector3.down)*hitToCenter;
					hitToCenter=hitToCenter.normalized;
				

					line2.SetPosition(0,cueBallPredictionSprite.transform.position);
					line2.SetPosition(1,(cueBallPredictionSprite.transform.position+ ((maxLenghtOfLine-minLengthOfLine)*lengthOfLine + minLengthOfLine)*hitToCenter));
					line2.startWidth=0.3f;
					line2.endWidth=0;

					myDirection=(line2.GetPosition(1)-line2.GetPosition(0)).normalized;







				


					#endregion
				



					}



				else 
				{
					line.SetPosition (0, gameObject.transform.position);
					line.SetPosition (1, hit.point);
					//line.SetPosition (2, line.GetPosition (1));
					line.startWidth = 0.3f;
					Vector3 secondDirection = (line.GetPosition(1)-line.GetPosition(0)).normalized;
					Vector3 hitToCenter = (hit.collider.gameObject.transform.position - hit.point).normalized;
					Vector3 centerOfTheCast = hit.point-(0.5f+raduisOfSphereCast)*secondDirection;

					centerOfTheCast.y=5f;



					//line.SetPosition (1,centerOfTheCast);
				//	centerOfTheCast = hit.point;
					cueBallPredictionSprite.transform.position = centerOfTheCast;
					line2.startWidth = 0;
					line2.endWidth = 0;
					line2.enabled = false;
					line.endWidth = 0.0f;
//					line2.startWidth = 0;
//					line2.endWidth = 0;
					line3.startWidth = 0;
					line3.endWidth = 0;
					line3.enabled = false;
//					Debug.LogError (hit.collider.gameObject.name);
//					Debug.LogError ("hitPoint :"+hit.point.ToString()+"line endinf position "+line.GetPosition(1));

				//	if (cueBallPredictionSprite.activeInHierarchy == true) {
				//		cueBallPredictionSprite.SetActive (false);
				//	}

				}
			} else {
				
			
				line.SetPosition (0, gameObject.transform.position);
				line.SetPosition (1, gameObject.transform.position + PoolGameController.GameInstance.strikeDirection * 10.0f);
			//	line.SetPosition (2, line.GetPosition (1));
				line.startWidth = 0.3f;
				line.endWidth = 0.0f;
				line3.startWidth = 0;
				line3.endWidth = 0;
				line2.startWidth = 0;
				line2.endWidth = 0;
				line2.enabled = false;
				line3.enabled = false;


			
			}
			if (Input.GetMouseButtonUp (0	)) {
				StayInBound.isCollidingWith = name;
				StayInBound.direction = direction;
			}

		}
		else 
		{
			line.startWidth = 0;
			line.endWidth = 0;
			line2.enabled = false;
			//	line2.startWidth = 0;
	//		line2.endWidth = 0;
			line3.enabled = false;
			//line3.startWidth = 0;
			//line3.endWidth = 0;
			if (cueBallPredictionSprite.activeInHierarchy == true) {
				cueBallPredictionSprite.SetActive (false);
			}
	}



		
	}


	public void OnDrawGizmosSelected()
	{
//		Gizmos.color = Color.red;
	//	Vector3 position=(hit.point-gameObject.transform.position).normalized;
		//position.y = gameObject.transform.position.y;
	//	Gizmos.DrawWireSphere (hit.collider.transform.position, 0.5f);
	}


	public void OnCollisionEnter(Collision col)
	{
		if (col.collider.gameObject.tag == "redball") {
			PoolGameController.GameInstance.check2 = 0;
		}
		if (col.collider.gameObject.tag == "redball" && col.collider.gameObject.name==isCollidingWith) {
			//Add force Logic 
			velocityBeforeCollisionCueBall=new Velocity(gameObject.GetComponent<Rigidbody>().velocity);
			Rigidbody rb = col.collider.gameObject.GetComponent<Rigidbody> ();
			if (rb != null) {
				//rb.velocity = Vector3.zero;
			//	rb.angularVelocity = Vector3.zero;

			}
		
		
		}
	}
	public void OnCollisionStay(Collision col)
	{
		if(col.gameObject.tag=="redball" && col.collider.gameObject.name==isCollidingWith){
		
			Rigidbody rb = col.collider.gameObject.GetComponent<Rigidbody> ();	
	
		}

	}
	public void OnCollisionExit(Collision col)
	{
		if (col.collider.tag == "redball" && col.collider.gameObject.name==isCollidingWith) {

			velocityAfterCollisionCueBall=new Velocity(gameObject.GetComponent<Rigidbody>().velocity);




			Rigidbody rb = col.collider.gameObject.GetComponent<Rigidbody> ();	

			float massOfCueBall = gameObject.GetComponent<Rigidbody> ().mass;
			float massOfRedBall=rb.mass;
			float constantK = massOfCueBall / massOfRedBall;
			velocityAfterCollisionRedBall = new Velocity ();

			velocityAfterCollisionRedBall.x = (velocityBeforeCollisionCueBall.x - velocityAfterCollisionCueBall.x) * constantK;
			velocityAfterCollisionRedBall.y = (velocityBeforeCollisionCueBall.y - velocityAfterCollisionRedBall.y) * constantK;
			velocityAfterCollisionRedBall.z = (velocityBeforeCollisionCueBall.z - velocityAfterCollisionCueBall.z) * constantK;

			float magnitude = Mathf.Sqrt (velocityAfterCollisionRedBall.x*velocityAfterCollisionRedBall.x+velocityAfterCollisionRedBall.z*velocityAfterCollisionRedBall.z);


			gameObject.GetComponent<Rigidbody>().velocity=gameObject.GetComponent<Rigidbody>().velocity.magnitude*myDirection.normalized	;
		//	Debug.LogError ("Not working ");

			float force = (PoolGameController.MAX_DISTANCE - PoolGameController.MIN_DISTANCE) * factor
				+ PoolGameController.MIN_DISTANCE;
			force = force * factor*3.0f;
		//	rb.velocity =magnitude*3.0f * direction;
			rb.velocity=rb.velocity.magnitude*direction;
//			Debug.LogError ("Rb velocity "+rb.velocity.x+"    "+rb.velocity.y+"       "+rb.velocity.z+"Magnitude =="+rb.velocity.magnitude+"    Mag =="+magnitude);
			direction = Vector3.zero;
				isCollidingWith = null;
		}
	}
}
