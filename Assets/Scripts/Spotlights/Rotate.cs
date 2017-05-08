using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

	private Quaternion originalRot;
	private Quaternion up;
	private Quaternion down;
	private Quaternion left;
	private Quaternion right;
//	private Vector3 up;

	public GameObject point;

	private Quaternion currentRot;
	private Vector3 euler;
	private float zRotation = 0f;
	private float yRotation = 0f;
	private float xRotation = 0f;
	public float rotationSpeed = 5f;
	// Rotation Limits
	// Vertical
	float vertTop = 90; // Top
	float vertBot = -90; // Bottom
	// Horizontal
	float horiLeft; // Left
	float horiRight; // Right

	float Vert = 0.0f;


	void Start(){
		originalRot = transform.rotation;
//		up = transform.up;
		up = Quaternion.LookRotation(transform.up);
		down =  Quaternion.LookRotation(-transform.up);
		left =  Quaternion.LookRotation(-transform.right);
		right =  Quaternion.LookRotation(transform.right);
		

		euler = originalRot.eulerAngles;
		currentRot = originalRot;
		// Rotation Limits
//		vertTop   = originalRot.eulerAngles.x - 90f;
//		vertBot   = originalRot.eulerAngles.x + 90f;
//		horiLeft  =	originalRot.eulerAngles.y + 90f;
//		horiRight = originalRot.eulerAngles.y - 90f;
		Debug.Log ("ogrot: "+originalRot);
		Debug.Log ("up: "+euler);
	}

	void Update () {
//		Debug.Log (euler);
		euler = transform.localEulerAngles;
//		Debug.Log (transform.name+": "+euler);

		if (Input.GetKey (KeyCode.I)) {
//			transform.rotation = up;
			transform.rotation = Quaternion.Lerp (transform.rotation, up, 0.3f);
//			euler.x += rotationSpeed;
//			euler.x += rotationSpeed;
//			Quaternion.Fro
//			transform.LookAt (up);
		} else if (Input.GetKey (KeyCode.K)) {
//			transform.rotation = down;	
			transform.rotation = Quaternion.Lerp (transform.rotation, down, 0.3f);
//			euler.x -= rotationSpeed;
		} else if (Input.GetKey (KeyCode.J)) {
//			transform.rotation = left;
			transform.rotation = Quaternion.Lerp (transform.rotation, right, 0.3f);
//			euler.y += rotationSpeed;
		} else if (Input.GetKey (KeyCode.L)) {
//			transform.rotation = right;
			
			transform.rotation = Quaternion.Lerp (transform.rotation, left, 0.3f);
//			euler.y -= rotationSpeed;
		} else {
			transform.rotation = Quaternion.Lerp (transform.rotation, originalRot, 0.3f);
		}



		// Rotation Limits
		// Vertical
//		if(euler.x < vertTop) // Top
//			euler.x = vertTop;
//		if(euler.x > vertBot) // Bottom
//			euler.x = vertBot;
		// Horizontal
//		if (euler.y > horiLeft) // Left
//			euler.y = horiLeft;
//		if (euler.y < horiRight) // Right
//			euler.y = horiRight;

//		Vector3 lookDirection = Vector3.zero;
//		Debug.Log(euler);
//		transform.localEulerAngles = euler;


		float xAxis = (Input.GetAxis ("Vertical"));
		float yAxis = (Input.GetAxis ("Horizontal"));
		Debug.Log ("xAxis: "+xAxis);
		float xdeg = xAxis * Mathf.Rad2Deg;
		float ydeg = yAxis * Mathf.Rad2Deg;
//		transform.Rotate (xdeg, ydeg, 0);
		transform.Rotate(Vector3.right, 45);
		transform.Rotate(Vector3.up, yAxis);
		Debug.Log ("rotation: " + transform.rotation);
//		transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.Euler (xAxis+transform.position.x, yAxis+transform.position.y, 0), 0.3f);
//		Vert += xAxis;
//		if (xAxis < 0)
//			lookDirection = Vector3.down;
//		if (xAxis > 0)
//			lookDirection = Vector3.up;
//		if (yAxis < 0)
//			lookDirection = Vector3.right;
//		if (yAxis > 0)
//			lookDirection = Vector3.left;
//		transform.localRotation = Quaternion.LookRotation (lookDirection);
		Quaternion rotRight = Quaternion.Euler(transform.right * 10);
//		transform.Rotate (xAxis, yAxis, 0);
//		transform.RotateAround(transform.position, transform.up, -yAxis);
//		transform.RotateAround(transform.position, transform.right, -xAxis);



		Debug.DrawLine (
			transform.position,
			transform.position + transform.right,
			Color.red,
			2.0f
		);
		Debug.DrawLine (
			transform.position,
			transform.position + transform.up,
			Color.blue,
			2.0f
		);
//		transform.rotation = originalRot;
		

//		transform.rotation = 
//		transform.rotation = Quaternion.Euler(euler); 
	

//		Debug.Log ("y: "+euler.y);
//		Debug.Log ("z: "+euler.z);
//		transform.eulerAngles = new Vector3(0, yRotation, zRotation);


//		currentRot = Quaternion.Euler (euler);
//		transform.rotation = currentRot;
	}
}
