using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knob : MonoBehaviour {

	int low;
	int high;
	int totalDegree;
	int degreeVal;
	void Start () {
		// off set 180 by 10 degrees so you can tell if knob is on the low end or high end
		transform.Rotate (new Vector3 (0, 10, 0));
		low = -170; // off set 180 by 10
		high = 170;
		totalDegree = 340; // from -170 to 170 is 340
		degreeVal = low; // start at low
	}

	public void turnClockwise(int degree){
		if(degreeVal < 170){
			transform.Rotate (new Vector3 (0, degree, 0));
			degreeVal = degreeVal + degree;
		}
	}

	public void turnCounterClockwise(int degree){
		if( degreeVal > -170){
			transform.Rotate (new Vector3 (0, -degree, 0));
			degreeVal = degreeVal - degree;
		}
			
	}

	public float getDegreeVal(){
		return degreeVal;
	}

	public int getDividedVal(int numOfValues){
		float curVal = totalDegree;
		float curVal2 = 0;
		int notchVal = -1;
		float dividedVal = totalDegree/(numOfValues-1);
		for(int i=0; i<numOfValues; i++){
			curVal2 = Mathf.Abs ((degreeVal+(totalDegree/2)) - (i * dividedVal));
			if (curVal2 < curVal) {
				curVal = curVal2;
				notchVal = i;
			}
		}
		return notchVal;
	}

}
