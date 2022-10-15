using UnityEngine;
using System.Collections;

/*
 * Not completed yet, continue on page 68.
*/

public class VehicleFollowing : MonoBehaviour {
	public Path path;
	// Default speed = 20.0f, mass=5.0f
	public float speed = 20.0f;
	public float mass = 5.0f;
	public bool isLooping = false;

	//Actual speed of the vehicle
	private float curSpeed;

	private int curPathIndex;
	private float pathLength;
	private Vector3 targetPoint;

	Vector3 velocity;

	// Use this for initialization
	void Start () {
		path = new Path ();
		pathLength = path.Length;
		curPathIndex = 0;

		//get the current velocity of the vehicle;
		velocity = transform.forward;
	}
	
	// Update is called once per frame
	void Update () {
		//Unify the speed
		curSpeed = speed * Time.deltaTime;

		targetPoint = path.GetPoint (curPathIndex);

		//If reach the radius within the path then move to next point in the path
		if (Vector3.Distance (transform.position, targetPoint) < path.Radius) {
			//Don't move the vehicle if path is finished
			if (curPathIndex < pathLength - 1) {
				curPathIndex++;
			} else if (isLooping) {
				curPathIndex = 0;
			} else {
				return;
			}
		}
		// Move the vehicle until the endpoint of the path is reached
		if (curPathIndex >= pathLength) {
			return;
		}
		// Calculate the next velocity towards the path
		if (curPathIndex >= pathLength - 1 && !isLooping) {
			velocity += Steer (targetPoint, true);
		} else {
			velocity += Steer(targetPoint);
		}

		


		//Move the vehicle according to the velocity
		transform.position += velocity;
		// Rotate the vehicle towards the desired velocity
		transform.rotation = Quaternion.LookRotation(velocity);
	}

	/* Steering algorithm to steer the Vector towards the target
	 * @params target: position to next waypoint
	 * 			bFinalpoint: is final waypoint reached of path
	*/
	public Vector3 Steer(Vector3 target, bool bFinalPoint = false) {
		// Calculate the directional vector from the current position
		// towards the target point
		Vector3 desiredVelocity = (target -transform.position);
		float dist = desiredVelocity.magnitude;

		// Normalise the desired velocity
		desiredVelocity.Normalize();

		// Calculate the velocity according to the speed
		if (bFinalPoint && dist < 10.0f) {
			desiredVelocity *= (curSpeed * (dist / 20.0f));
		} else {
			desiredVelocity *= curSpeed;
		}

		// Calculate the force Vector
		Vector3 steeringForce = desiredVelocity - velocity;
		Vector3 acceleration = steeringForce / mass;

		return acceleration;
	}
}
