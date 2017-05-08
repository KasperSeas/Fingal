using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightGroup : MonoBehaviour {

	public SpotlightRotation[] spotlights;
	public float offsetX = 0f;
	public float offsetY = 0f;

	private bool symmetricalX = true;
	private bool symmetricalY = true;

	float mid = 0f;
	bool evenNumLights = false;

	void Awake(){
		mid = transform.childCount / 2f;
		evenNumLights = (transform.childCount % 2 == 0); 
		spotlights = new SpotlightRotation[transform.childCount];

		for(int i = 0; i < transform.childCount; i++){
			SpotlightRotation spotlight = transform.GetChild(i).GetComponent<SpotlightRotation> ();
			spotlights [i] = spotlight;
		}	
	}

	public void Move(Axis axis, Direction direction){
		switch (axis) {
		case Axis.x:
			foreach (SpotlightRotation s in spotlights) {
				s.AxisMoveX (direction);	
			}
			break;
		case Axis.y:
			foreach (SpotlightRotation s in spotlights) {
				s.AxisMoveY (direction);	
			}	
			break;
		case Axis.z:
			foreach (SpotlightRotation s in spotlights) {
				s.AxisMoveZ (direction);	
			}	
			break;
		}
	}

	public void Oscillate(Axis axis){
		switch (axis) {
		case Axis.x:
			foreach (SpotlightRotation s in spotlights) {
				s.OscillateActivateX ();
			}
			break;
		case Axis.y:
			foreach (SpotlightRotation s in spotlights) {
				s.OscillateActivateY ();
			}
			break;
		}
	}

	public void OscillateSpeed(Axis axis, Change change){
		switch (axis) {
		case Axis.x:
			foreach (SpotlightRotation s in spotlights) {
				s.OscillateSpeedX (change);
			}	
			break;
		case Axis.y:
			foreach (SpotlightRotation s in spotlights) {
				s.OscillateSpeedY (change);
			}	
			break;
		}
	}

	public void AltFlip(Axis axis){
		switch (axis) {
		case Axis.x:
			foreach (SpotlightRotation s in spotlights) {
				s.AltFlipX ();
			}		
			break;
		case Axis.y:
			foreach (SpotlightRotation s in spotlights) {
				s.AltFlipY ();
			}		
			break;
		}
	}

	public void Offset(Axis axis, Change change){
		switch (axis) {
		case Axis.x:
			if (change == Change.increase) {
				offsetX += 0.1f;
				//xAngles.x += (transform.GetSiblingIndex() * xOffset );	
			}

			if (change == Change.decrease) {
				offsetX -= 0.1f;
				//xAngles.x += (transform.GetSiblingIndex() * xOffset );	
			}
			// OffsetX Bounds
			if(offsetX < -1f) offsetX = -1f;
			if(offsetX > 1f) offsetX = 1f;

			if (symmetricalX)
				SymmetricalOffsetX ();
			else 
				AsymmetricalOffsetX ();	
			break;
		case Axis.y:
			if (change == Change.increase) {
				offsetY += 0.1f;
				//xAngles.x += (transform.GetSiblingIndex() * xOffset );	
			}

			if (change == Change.decrease) {
				offsetY -= 0.1f;
				//xAngles.x += (transform.GetSiblingIndex() * xOffset );	
			}
			// OffsetX Bounds
			if (offsetY < -1f)
				offsetY = -1f;
			if (offsetY > 1f)
				offsetY = 1f;

			if (symmetricalY)
				AsymmetricalOffsetY ();
			else
				SymmetricalOffsetY ();
			break;
		}


	}

	// Symmetry
	public void SwitchSymmetry(Axis axis, bool setSymmetrical){
		switch (axis) {
		case Axis.x:
			symmetricalX = setSymmetrical;	
			break;
		case Axis.y:
			symmetricalY = setSymmetrical;		
			break;
		}
	}

	private void AsymmetricalOffsetX(){
		if (!evenNumLights) {
			for (int i = 0; i < (spotlights.Length / 2 + 1); i++) {
				int k = (int)(i + Mathf.Ceil (mid) - 1);
				int k2 = (int)(-i + Mathf.Ceil (mid) - 1); 
				spotlights [k].xAngles.x = (float)((i * offsetX * 90f) / (spotlights.Length / 2));
				spotlights [k2].xAngles.x = (float)((-i * offsetX * 90f) / (spotlights.Length / 2));
			}
		} else {
			for (int i = 1; i < (spotlights.Length / 2 +1); i++) {
				int k = (int)(i + Mathf.Ceil (mid)-1);
				int k2 = (int)(-i + Mathf.Ceil (mid));
				if (i == 1) {
					spotlights [k].xAngles.x = (float)((i * offsetX/2 * 90f) / (spotlights.Length / 2));
					spotlights [k2].xAngles.x = (float)((-i * offsetX/2 * 90f) / (spotlights.Length / 2));	
				} else {
					spotlights [k].xAngles.x = (float)((i * offsetX * 90f) / (spotlights.Length / 2));
					spotlights [k2].xAngles.x = (float)((-i * offsetX * 90f) / (spotlights.Length / 2));
				}
			}	
		}	
	}

	private void AsymmetricalOffsetY(){
		if (!evenNumLights) {
			for (int i = 0; i < (spotlights.Length / 2 + 1); i++) {
				int k = (int)(i + Mathf.Ceil (mid) - 1);
				int k2 = (int)(-i + Mathf.Ceil (mid) - 1); 
				spotlights [k].yAngles.y = (float)((i * offsetY * 90f) / (spotlights.Length / 2));
				spotlights [k2].yAngles.y = (float)((-i * offsetY * 90f) / (spotlights.Length / 2));
			}
		} else {
			for (int i = 1; i < (spotlights.Length / 2 +1); i++) {
				int k = (int)(i + Mathf.Ceil (mid)-1);
				int k2 = (int)(-i + Mathf.Ceil (mid));
				if (i == 1) {
					spotlights [k].yAngles.y = (float)((i * offsetY/2 * 90f) / (spotlights.Length / 2));
					spotlights [k2].yAngles.y = (float)((-i * offsetY/2 * 90f) / (spotlights.Length / 2));	
				} else {
					spotlights [k].yAngles.y = (float)((i * offsetY * 90f) / (spotlights.Length / 2));
					spotlights [k2].yAngles.y = (float)((-i * offsetY * 90f) / (spotlights.Length / 2));
				}
			}	
		}	
	}

	private void SymmetricalOffsetX(){
		if (!evenNumLights) { // Odd Number of Spotlights
			int midOdd = (int) (Mathf.Ceil (mid) - 1); 
			int quarter =  (int) midOdd / 2; 
			int quarter1 = (int) midOdd / 2;
			int quarter3 = (int) (3*midOdd / 2);
			if (midOdd % 2 == 0) { // Any side of the median spotlight is even ex. 9 spotlights == 4 on right side of median
				for (int i = 0; i < (spotlights.Length / 4 + 1); i++) {
					if (i == 0) continue;
					int k = (int)(i + Mathf.Ceil (quarter1));
					int k2 = (int)(-i + Mathf.Ceil (quarter1));
					int k3 = (int)(i + Mathf.Ceil (quarter3));
					int k4 = (int)(-i + Mathf.Ceil (quarter3)); 
					spotlights [k].xAngles.x = (float)((i * offsetX * 90f) / (spotlights.Length / 2));
					spotlights [k2].xAngles.x = (float)((-i * offsetX * 90f) / (spotlights.Length / 2));
					spotlights [k3].xAngles.x = (float)((-i * offsetX * 90f) / (spotlights.Length / 2));
					spotlights [k4].xAngles.x = (float)((i * offsetX * 90f) / (spotlights.Length / 2));
				}	
			} else { // Any side of the median spotlight is odd ex. 7 spotlights == 3 on right side of median
				for (int i = 1; i < (spotlights.Length / 4 + 2); i++) {
					int k = (int)(-i + Mathf.Ceil (quarter1)+1);
					int k2 = (int)(i + Mathf.Ceil (quarter1));
					int k3 = (int)(-i + Mathf.Ceil (quarter3)+1);
					int k4 = (int)(i + Mathf.Ceil (quarter3));
					if (i == 1) {
						spotlights [k].xAngles.x = (float)((1 * offsetX/2 * 90f) / (spotlights.Length / 2));
						spotlights [k2].xAngles.x = (float)((-1 * offsetX/2 * 90f) / (spotlights.Length / 2));
						spotlights [k3].xAngles.x = (float)((-1 * offsetX/2 * 90f) / (spotlights.Length / 2));
						spotlights [k4].xAngles.x = (float)((1 * offsetX/2 * 90f) / (spotlights.Length / 2));		
					} else {
						spotlights [k].xAngles.x = (float)((i * offsetX * 90f) / (spotlights.Length / 2));
						spotlights [k2].xAngles.x = (float)((-i * offsetX * 90f) / (spotlights.Length / 2));
						spotlights [k3].xAngles.x = (float)((-i * offsetX * 90f) / (spotlights.Length / 2));
						spotlights [k4].xAngles.x = (float)((i * offsetX * 90f) / (spotlights.Length / 2));	
					}
				}	
			}
		} else { // Even number of Spotlights
			int quarter1 = (int)Mathf.Ceil (mid) / 2;
			int quarter3 = (int)(3*Mathf.Ceil (mid) / 2);

			for (int i = 1; i < (spotlights.Length / 4 +1); i++) {
				int k = (int)(i + Mathf.Ceil (quarter1)-1);
				int k2 = (int)(-i + Mathf.Ceil (quarter1));
				int k3 = (int)(i + Mathf.Ceil (quarter3)-1);
				int k4 = (int)(-i + Mathf.Ceil (quarter3));
				if (i == 1) {
					spotlights [k].xAngles.x = (float)((i * offsetX/2 * 90f) / (spotlights.Length / 2));
					spotlights [k2].xAngles.x = (float)((-i * offsetX/2 * 90f) / (spotlights.Length / 2));
					spotlights [k3].xAngles.x = (float)((-i * offsetX/2 * 90f) / (spotlights.Length / 2));
					spotlights [k4].xAngles.x = (float)((i * offsetX/2 * 90f) / (spotlights.Length / 2));	
				} else {
					spotlights [k].xAngles.x = (float)((i * offsetX * 90f) / (spotlights.Length / 2));
					spotlights [k2].xAngles.x = (float)((-i * offsetX * 90f) / (spotlights.Length / 2));
					spotlights [k3].xAngles.x = (float)((-i * offsetX * 90f) / (spotlights.Length / 2));
					spotlights [k4].xAngles.x = (float)((i * offsetX * 90f) / (spotlights.Length / 2));
				}
			}	
		}	
	}

	private void SymmetricalOffsetY(){
		if (!evenNumLights) { // Odd Number of Spotlights
			int midOdd = (int) (Mathf.Ceil (mid) - 1); 
			int quarter =  (int) midOdd / 2; 
			int quarter1 = (int) midOdd / 2;
			int quarter3 = (int) (3*midOdd / 2);
			if (midOdd % 2 == 0) { // Any side of the median spotlight is even ex. 9 spotlights == 4 on right side of median
				for (int i = 0; i < (spotlights.Length / 4 + 1); i++) {
					if (i == 0) continue;
					int k = (int)(i + Mathf.Ceil (quarter1));
					int k2 = (int)(-i + Mathf.Ceil (quarter1));
					int k3 = (int)(i + Mathf.Ceil (quarter3));
					int k4 = (int)(-i + Mathf.Ceil (quarter3)); 
					spotlights [k].yAngles.y = (float)((i * offsetY * 90f) / (spotlights.Length / 2));
					spotlights [k2].yAngles.y = (float)((-i * offsetY * 90f) / (spotlights.Length / 2));
					spotlights [k3].yAngles.y= (float)((-i * offsetY * 90f) / (spotlights.Length / 2));
					spotlights [k4].yAngles.y = (float)((i * offsetY * 90f) / (spotlights.Length / 2));
				}	
			} else { // Any side of the median spotlight is odd ex. 7 spotlights == 3 on right side of median
				for (int i = 1; i < (spotlights.Length / 4 + 2); i++) {
					int k = (int)(-i + Mathf.Ceil (quarter1)+1);
					int k2 = (int)(i + Mathf.Ceil (quarter1));
					int k3 = (int)(-i + Mathf.Ceil (quarter3)+1);
					int k4 = (int)(i + Mathf.Ceil (quarter3));
					if (i == 1) {
						spotlights [k].yAngles.y  = (float)((1 * offsetY/2 * 90f) / (spotlights.Length / 2));
						spotlights [k2].yAngles.y = (float)((-1 * offsetY/2 * 90f) / (spotlights.Length / 2));
						spotlights [k3].yAngles.y = (float)((-1 * offsetY/2 * 90f) / (spotlights.Length / 2));
						spotlights [k4].yAngles.y = (float)((1 * offsetY/2 * 90f) / (spotlights.Length / 2));		
					} else {
						spotlights [k].yAngles.y = (float)((i * offsetY * 90f) / (spotlights.Length / 2));
						spotlights [k2].yAngles.y = (float)((-i * offsetY * 90f) / (spotlights.Length / 2));
						spotlights [k3].yAngles.y = (float)((-i * offsetY * 90f) / (spotlights.Length / 2));
						spotlights [k4].yAngles.y = (float)((i * offsetY * 90f) / (spotlights.Length / 2));	
					}
				}	
			}
		} else { // Even number of Spotlights
			int quarter1 = (int)Mathf.Ceil (mid) / 2;
			int quarter3 = (int)(3*Mathf.Ceil (mid) / 2);

			for (int i = 1; i < (spotlights.Length / 4 +1); i++) {
				int k = (int)(i + Mathf.Ceil (quarter1)-1);
				int k2 = (int)(-i + Mathf.Ceil (quarter1));
				int k3 = (int)(i + Mathf.Ceil (quarter3)-1);
				int k4 = (int)(-i + Mathf.Ceil (quarter3));
				if (i == 1) {
					spotlights [k].yAngles.y = (float)((i * offsetY/2 * 90f) / (spotlights.Length / 2));
					spotlights [k2].yAngles.y = (float)((-i * offsetY/2 * 90f) / (spotlights.Length / 2));
					spotlights [k3].yAngles.y = (float)((-i * offsetY/2 * 90f) / (spotlights.Length / 2));
					spotlights [k4].yAngles.y = (float)((i * offsetY/2 * 90f) / (spotlights.Length / 2));	
				} else {
					spotlights [k].yAngles.y = (float)((i * offsetY * 90f) / (spotlights.Length / 2));
					spotlights [k2].yAngles.y = (float)((-i * offsetY * 90f) / (spotlights.Length / 2));
					spotlights [k3].yAngles.y = (float)((-i * offsetY * 90f) / (spotlights.Length / 2));
					spotlights [k4].yAngles.y = (float)((i * offsetY * 90f) / (spotlights.Length / 2));
				}
			}	
		}	
	}



	// Reset
	public void ResetAll(){
		foreach(SpotlightRotation s in spotlights){
			s.Reset (Axis.all);
		}
	}

	public void ResetAxis(Axis axis){
		switch (axis) {
		case Axis.x:
			foreach(SpotlightRotation s in spotlights){
				s.Reset (Axis.x);
			}
			break;
		case Axis.y:
			foreach(SpotlightRotation s in spotlights){
				s.Reset (Axis.y);
			}		
			break;
		}
	}


	public IEnumerator Wait(){
		float time = 1f;
		yield return new WaitForSeconds (time);
	}

}
