using UnityEngine;
using System.Collections;

/*
 * Path script which sets the waypoints and draws the path (if in debug mode)
 * 
*/
public class Path : MonoBehaviour {

	//Debug mode, if true the positions will be drawn as gizmos in the editor
	public bool bDebug = true;

	//Radius range to determine if waypoint is reached
	public float Radius = 2.0f;

	//Fill Vector3 array with x,y and z values for waypoints. 
	public Vector3[] pointA = new[] { 
		new Vector3(0f,0f,0f),new Vector3(0f,0f,25f),new Vector3(10f,0f,30f),
		new Vector3(20f,0f,30f),new Vector3(25f,0f,25f),new Vector3(30f,0f,20f),
		new Vector3(35f,0f,10f), new Vector3(20f,0f,-5f), new Vector3(0f, 0f, -5f)
	};

	public float Length {
		get {
			return pointA.Length;
		}
	}

	public Vector3 GetPoint(int index) {
		return pointA [index];
	}

	void OnDrawGizmos() {
		if (!bDebug) {
			return;
		}

		for (int i = 0; i < pointA.Length; i++) {
			if (i + 1 < pointA.Length) {
				Debug.DrawLine (pointA [i], pointA [i + 1], Color.red);
			}
		}
		
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
