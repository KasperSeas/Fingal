using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrobeLight : MonoBehaviour {
	public bool isActive;

	Renderer rend;
	Material mat;

	void Start () {
		isActive = false;
		if(transform.GetComponent<Renderer>() != null){
			rend = transform.GetComponent<Renderer> ();
			mat = rend.material;
		}
	}

	public void setActive(bool activate){
		isActive = activate;
	}

	public void setColor(Color color){
		if (mat == null) return;
		mat.SetColor ("_EmissionColor", color);	
	}

}
