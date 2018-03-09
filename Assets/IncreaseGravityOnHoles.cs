using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseGravityOnHoles : MonoBehaviour {
	private  Vector3 directionOfForce = Vector3.down;
	private const float  speed=10.0f;
	[SerializeField]
	private const float enterForce = 1000f;
	private const float stayForce = 50f;
	private Vector3 enterVelocity=Vector3.zero;



	private void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "redball"|| col.gameObject.tag=="CueBall") {
			Rigidbody rb = col.gameObject.GetComponent<Rigidbody> ();
			enterVelocity = rb.velocity;
			Debug.Log ("rb.velocity.magnitude: "+rb.velocity.magnitude);
			rb.AddForce (enterForce *directionOfForce*rb.velocity.magnitude);
		}
	}


	private void OnTriggerStay(Collider col)
	{
		if (col.gameObject.tag == "redball"|| col.gameObject.tag=="CueBall") {
			Rigidbody rb = col.gameObject.GetComponent<Rigidbody> ();
			Debug.Log ("rb.velocity.magnitude: "+rb.velocity.magnitude);
			rb.AddForce (stayForce *directionOfForce*enterVelocity.magnitude);
		}
	}


}
