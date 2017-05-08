using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour {
	bool isPosDir;
	Transform handle;
	float slideHeight;
	Vector3 posPos;
	Vector3 negPos;

	void Start () {
		if(transform.FindChild("Handle") != null){
			handle = transform.FindChild ("Handle");	
		}

		slideHeight = transform.FindChild ("Slide").localScale.z;
		isPosDir = false;
		posPos = new Vector3(-2*handle.localPosition.x, 0, 0);
		negPos = new Vector3(2*handle.localPosition.x, 0, 0);
	}

	public void switchPos(){
		if(!isPosDir){
			handle.Translate (posPos);
			isPosDir = true;
		}
	}

	public void switchNeg(){
		if(isPosDir){
			handle.Translate ( negPos);
			isPosDir = false;
		}
	}
}
