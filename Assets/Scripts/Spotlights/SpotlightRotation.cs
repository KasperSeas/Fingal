using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Axis {
	x, y, z, all
}

public enum Direction {
	up, down, left, right
}

public enum Change {
	increase, decrease
}

public partial class SpotlightRotation : MonoBehaviour {

	// Axis Transforms
	Transform xaxis;
	Transform yaxis;
	Transform zaxis;

	Transform xRotator;
	Transform yRotator;
	Transform zRotator;

	Transform zLookPoint;
	Transform xLookPoint;
	Transform yLookPoint;

	// Axis Original Rotations
	float zaxisOG, xaxisOG, yaxisOG;
	// Axis euler angles
	public Vector3 zAngles, xAngles, yAngles; 
	// Axis Speeds
	float zSpeed, xSpeed, ySpeed;

	//Angle Range // TODO: Sin Bound control

	float upperBoundX = 90f - 5f; // X
	float lowerBoundX = -90f + 5f;
	float upperBoundY = 90f - 5f; // Y
	float lowerBoundY = -90f + 5f;

	// Sin Oscillations (x)
	bool xSin = false, ySin = false, zSin = false;
	bool upperDirX = true, upperDirY = true, upperDirZ = true;
	// Sin Oscillation Speeds
	float xSinSpeed, ySinSpeed = 1f;
	// Sin Oscillation Coroutines
	IEnumerator xOscillateCoroutine, yOscillateCoroutine;

	// Alt Flip  (x, y, z)
	bool xAlt, yAlt, zAlt;

	// Asymmetrical and Symmetrical Offset
	float zOffset = 0, xOffset = 0;


	void Awake(){


		zaxis = transform.Find("zaxis");
		yaxis = zaxis.Find("yaxis");
		xaxis = yaxis.Find("xaxis");

		xRotator = yaxis.Find ("xRotator");
		xLookPoint = xRotator.Find ("xLookPoint");

		yRotator = zaxis.Find ("yRotator");
		yLookPoint = yRotator.Find ("yLookPoint");


//		zRotator = transform.Find ("zRotator");
//		zLookPoint = zRotator.Find ("zLookPoint");


		// Rotations
		zaxisOG = 0;
		yaxisOG = 0; 
		xaxisOG = 0; 

		// Speeds
		xSpeed = ySpeed = zSpeed = 5f;

		// Alt
		xAlt = yAlt = zAlt = false;

		// euler angles
		zAngles = new Vector3 (0,0,zaxisOG);
		yAngles = new Vector3 (0,yaxisOG,0);
		xAngles = new Vector3 (xaxisOG,0,0);

		// sin coroutine
		xOscillateCoroutine = _OscillateX();
		yOscillateCoroutine = _OscillateY();

		// Range
		//angleRange = Mathf.Abs( upperBound - lowerBound);

		if (zaxis == null)
			Debug.LogError ("Spotlight zaxis transform not found.");
		if(yaxis == null)
			Debug.LogError ("Spotlight yaxis transform not found.");
		if(xaxis == null)	
			Debug.LogError ("Spotlight xaxis transform not found.");
	}
	
	void Update () {
		// Update Axis
		xAxis ();
		yAxis ();
		zAxis ();
	}

	// General Functions
	public void Reset(Axis axis){
		// Reset to original rotations
		switch(axis){
		case Axis.z:
			zAngles.z = zaxisOG;
			break;
		case Axis.y:
			yAngles.y = yaxisOG;	
			break;
		case Axis.x:
			xAngles.x = xaxisOG;	
			break;
		case Axis.all:
			zAngles.z = zaxisOG;
			yAngles.y = yaxisOG;
			xAngles.x = xaxisOG;
			break;
		default:
			break;
		}
	}

}
