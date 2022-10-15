using UnityEngine;
using System.Collections;

public class VehicleAvoidance : MonoBehaviour {
	public float speed = 20.0f;
	public float mass = 5.0f;
	public float force = 50.0f;
	public float minimumDistToAvoid = 20.0f;

	// Actual speed of the agent
	private float curSpeed;
	private Vector3 targetPoint;

	// Use this for initialization
	void Start () {
		mass = 5.0f;
		targetPoint = Vector3.zero;
	}

	void OnGUI() {
		GUILayout.Label("Click anywhere to move the agent.");
	}
	
	// Update is called once per frame
	void Update () {
		// Agent move by mouseclick
		RaycastHit hit;
		var ray = Camera.main.ScreenPointToRay (Input.mousePosition);

		if (Input.GetMouseButtonDown (0) && Physics.Raycast (ray, out hit, 100.0f)) {
			targetPoint = hit.point;
		}

		//Directional vector to the target position
		Vector3 dir = (targetPoint - transform.position);
		dir.Normalize ();

		//Apply obstacle avoidance
		AvoidObstacles(ref dir);

		//Don't move the agent when the target point is reached
		if (Vector3.Distance (targetPoint, transform.position) < 3.0f) {
			return;
		}

		//Assign the speed with the delta time
		curSpeed = speed * Time.deltaTime;

		//Rotate the agent to it's target directional vector
		var rot = Quaternion.LookRotation(dir);
		transform.rotation = Quaternion.Slerp (transform.rotation, rot, 5.0f * Time.deltaTime);

		//Move the agent towards
		transform.position += transform.forward * curSpeed;
	}

	/*
	 * Calculate the new directional vector to avoid the obstacle
	*/
	public void AvoidObstacles(ref Vector3 dir) {
		RaycastHit hit;

		//Only detect layer 8 (Obstacles) objects
		int layerMask = 1<<8;

		//Check the agent hit with the obstacles within minimum distance to avoid
		if (Physics.Raycast (transform.position, transform.forward, out hit, minimumDistToAvoid, layerMask)) {
			//Get the normal of the hitpoint to calculate the new direction
			Vector3 hitNormal = hit.normal;
			//No movement in y space (up or down)
			hitNormal.y = 0.0f;
			//Get the new directional vector by adding force to agent's current forward vector
			dir = transform.forward + hitNormal * force;
		}
	}
}
