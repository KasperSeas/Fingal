using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public partial class SpotlightRotation : MonoBehaviour {
	



	void xAxis(){
		//=== XAxis Controller ===

		// Auto Sin() Oscillation Update
		if(xSin) OscillateXDirectionCheck();

		// xAngles check bounds
		if (xAngles.x > upperBoundX) xAngles.x = upperBoundX;
		if (xAngles.x < lowerBoundX) xAngles.x = lowerBoundX;

		// Update Angles
		//xaxis.localEulerAngles = xAngles;
		xRotator.localEulerAngles = xAngles;

		xaxis.transform.rotation = Quaternion.Slerp(xaxis.transform.rotation, (Quaternion.LookRotation(  xLookPoint.transform.position - xaxis.transform.position)), Time.deltaTime * xSpeed);
	}


	//==Alt Flip==
	public void AltFlipX(){
		if (xSin) return;
		xAlt = !xAlt;
		if (transform.GetSiblingIndex () % 2 == 1) {
			xAngles.x = -xAngles.x;
		}
		if (!xAlt)
			upperDirX = true;
	}

	//==Oscillate==
	public void OscillateActivateX(){

		xSin = !xSin;
		if (xSin) {
			if (xAlt) {
				upperDirX = (transform.GetSiblingIndex () % 2 == 1) ? !upperDirX : upperDirX;
			} 
			StartCoroutine (xOscillateCoroutine);
		} else {
			StopCoroutine (xOscillateCoroutine);
			xLookPoint.transform.localPosition = -Vector3.forward;
			upperDirX = true; // Reset Oscillate Direction
		} 
	}

	public void OscillateSpeedX(Change change){
		if (change == Change.increase) {
			xSinSpeed += 5f; 
		}
		if (change == Change.decrease) {
			xSinSpeed -= 5f; 
		}
		// xSinSpeed Bounds
		if(xSinSpeed < 0f) xSinSpeed = 0f;
		if(xSinSpeed > 200f) xSinSpeed = 200f;
	}

	void OscillateXDirectionCheck(){
		if (upperDirX) {
			if(xAngles.x > 85f)
				upperDirX = false;
		} else {
			if(xAngles.x < -85f)
				upperDirX = true;
		}
	}


	IEnumerator _OscillateX(){
		while(true){
			if (upperDirX) {
				xAngles.x += Time.deltaTime * xSinSpeed;
			} else {
				xAngles.x -= Time.deltaTime * xSinSpeed;
			}
			yield return new WaitForSeconds (0);
		}
	}

	// X axis Manual
	public void AxisMoveX(Direction direction){
		// Don't change current xAngles when oscillating
		if (xSin) return;
		//== Angles ==
		if (direction == Direction.up) {
			if (xAlt) {
				xAngles.x = (transform.GetSiblingIndex () % 2 == 1) ? xAngles.x - xSpeed : xAngles.x + xSpeed; 
			} else {
				xAngles.x += xSpeed;
			}	
		}
		if (direction == Direction.down) {
			if (xAlt) {
				xAngles.x = (transform.GetSiblingIndex () % 2 == 1) ? xAngles.x + xSpeed : xAngles.x - xSpeed;
			} else {
				xAngles.x -= xSpeed;	
			} 
		}
	}


}