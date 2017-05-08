using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class SpotlightRotation : MonoBehaviour {
	


	void yAxis(){
		//=== YAxis Controller ===

		// Auto Sin() Oscillation Update
		if(ySin) OscillateYDirectionCheck();

		// xAngles check bounds
		if (yAngles.y > upperBoundY) yAngles.y = upperBoundY;
		if (yAngles.y < lowerBoundY) yAngles.y = lowerBoundY;

		// Update Angles
		//xaxis.localEulerAngles = xAngles;
		yRotator.localEulerAngles = yAngles;

		yaxis.transform.rotation = Quaternion.Slerp(yaxis.transform.rotation, (Quaternion.LookRotation(  yLookPoint.transform.position - yaxis.transform.position)), Time.deltaTime * ySpeed);
	}


	//==Alt Flip==
	public void AltFlipY(){
		if (ySin) return;
		yAlt = !yAlt;
		if (transform.GetSiblingIndex () % 2 == 1) {
			yAngles.y = -yAngles.y;
		}
		if (!yAlt)
			upperDirY = true;
	}

	//==Oscillate==
	public void OscillateActivateY(){

		ySin = !ySin;
		if (ySin) {
			if (yAlt) {
				upperDirY = (transform.GetSiblingIndex () % 2 == 1) ? !upperDirY : upperDirY;
			} 
			StartCoroutine (yOscillateCoroutine);
		} else {
			StopCoroutine (yOscillateCoroutine);
			yLookPoint.transform.localPosition = -Vector3.forward;
			upperDirY = true; // Reset Oscillate Direction
		} 
	}

	public void OscillateSpeedY(Change change){
		if (change == Change.increase) {
			ySinSpeed += 5f; 
		}
		if (change == Change.decrease) {
			ySinSpeed -= 5f; 
		}
		// ySinSpeed Bounds
		if(ySinSpeed < 0f) ySinSpeed = 0f;
		if(ySinSpeed > 200f) ySinSpeed = 200f;
	}

	void OscillateYDirectionCheck(){
		if (upperDirY) {
			if(yAngles.y > 85f)
				upperDirY = false;
		} else {
			if(yAngles.y < -85f)
				upperDirY = true;
		}
	}


	IEnumerator _OscillateY(){
		while(true){
			if (upperDirY) {
				yAngles.y += Time.deltaTime * ySinSpeed;
			} else {
				yAngles.y -= Time.deltaTime * ySinSpeed;
			}
			yield return new WaitForSeconds (0);
		}
	}

	// Y axis Manual
	public void AxisMoveY(Direction direction){
		// Don't change current yAngles when oscillating
		if (ySin) return;
		//== Angles ==
		if (direction == Direction.left) { 
			if (yAlt) {
				yAngles.y = (transform.GetSiblingIndex () % 2 == 1) ? yAngles.y - ySpeed : yAngles.y + ySpeed; 
			} else {
				yAngles.y += ySpeed;	
			}	
		}
		if (direction == Direction.right) { 
			if (yAlt) {
				yAngles.y = (transform.GetSiblingIndex () % 2 == 1) ? yAngles.y + ySpeed : yAngles.y - ySpeed;
			} else {
				yAngles.y -= ySpeed;	
			} 
		}
	}


}