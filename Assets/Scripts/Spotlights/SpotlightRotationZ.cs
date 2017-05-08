using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class SpotlightRotation : MonoBehaviour {

	void zAxis(){
		//=== YAxis Controller ===

		// Auto Sin() Oscillation Update
		//if(ySin) OscillateYDirectionCheck();

		// xAngles check bounds
//		if (yAngles.y > upperBoundY) yAngles.y = upperBoundY;
//		if (yAngles.y < lowerBoundY) yAngles.y = lowerBoundY;

		// Update Angles
		//xaxis.localEulerAngles = xAngles;
//		zRotator.localEulerAngles = zAngles;
//		zaxis.transform.rotation = Quaternion.Slerp(zaxis.transform.rotation, (Quaternion.LookRotation(zLookPoint.transform.position - zaxis.transform.position)), Time.deltaTime * zSpeed);
	}


	//==Alt Flip==
	public void AltFlipZ(){
//		if (ySin) return;
		zAlt = !zAlt;
		if (transform.GetSiblingIndex () % 2 == 1) {
			zAngles.z = -zAngles.z;
		}
		if (!zAlt)
			upperDirZ = true;
	}

	//==Oscillate== (Auto Spin)
//	public void OscillateActivateZ(){
//
//		zSin = !zSin;
//		if (zSin) {
//			if (zAlt) {
//				upperDirZ = (transform.GetSiblingIndex () % 2 == 1) ? !upperDirZ : upperDirZ;
//			} 
//			StartCoroutine (zOscillateCoroutine);
//		} else {
//			StopCoroutine (zOscillateCoroutine);
//			zLookPoint.transform.localPosition = -Vector3.forward;
//			upperDirZ = true; // Reset Oscillate Direction
//		} 
//	}

//	public void OscillateSpeedZ(Change change){
//		if (change == Change.increase) {
//			ySinSpeed += 5f; 
//		}
//		if (change == Change.decrease) {
//			ySinSpeed -= 5f; 
//		}
//		// ySinSpeed Bounds
//		if(ySinSpeed < 0f) ySinSpeed = 0f;
//		if(ySinSpeed > 200f) ySinSpeed = 200f;
//	}

//	void OscillateYDirectionCheck(){
//		if (upperDirY) {
//			if(yAngles.y > 85f)
//				upperDirY = false;
//		} else {
//			if(yAngles.y < -85f)
//				upperDirY = true;
//		}
//	}


//	IEnumerator _OscillateY(){
//		while(true){
//			if (upperDirY) {
//				yAngles.y += Time.deltaTime * ySinSpeed;
//			} else {
//				yAngles.y -= Time.deltaTime * ySinSpeed;
//			}
//			yield return new WaitForSeconds (0);
//		}
//	}

	// Z axis Manual
//	public void AxisMoveZ(Direction direction){
//		// Don't change current yAngles when oscillating
//		if (zSin) return;
//		//== Angles ==
//		if (direction == Direction.left) { 
//			if (zAlt) {
//				zAngles.z = (transform.GetSiblingIndex () % 2 == 1) ? zAngles.z - zSpeed : zAngles.z + zSpeed; 
//			} else {
//				zAngles.z += zSpeed;	
//			}
//		}
//		if (direction == Direction.right) { 
//			if (zAlt) {
//				zAngles.z = (transform.GetSiblingIndex () % 2 == 1) ? zAngles.z + zSpeed : zAngles.z - zSpeed;
//			} else {
//				zAngles.z -= zSpeed;	
//			} 
//		}
//	}
	public void AxisMoveZ(Direction direction){
		// Don't change current yAngles when oscillating
		if (zSin) return;
		//== Angles ==
		if (direction == Direction.left) { 
//			zaxis.Rotate (0,0,5);	
			transform.Rotate (0,0,5);
		}
		if (direction == Direction.right) { 
			transform.Rotate (0,0,-5);	
		}
	}
}
