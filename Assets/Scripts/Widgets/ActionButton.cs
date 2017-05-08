using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionButton : MonoBehaviour {

	Renderer rend;
	Material mat;
	Color color;
	float ogZscale;

	void Start () {
		rend = GetComponent<Renderer> ();
		mat = rend.material;
		color = Color.cyan * Mathf.LinearToGammaSpace (0.1f);
		mat.SetColor ("_EmissionColor", color);
		ogZscale = transform.localScale.z;
	}

	public void turnON(){
		if(transform.localScale.z >= ogZscale){
			transform.localScale -= new Vector3(0, 0, 0.1f);	
		}
		color = Color.yellow * Mathf.LinearToGammaSpace (0.3f);
		mat.SetColor ("_EmissionColor", color);	
	}

	public void turnOFF(){
		if (transform.localScale.z <= ogZscale){
			transform.localScale += new Vector3(0, 0, 0.1f);	
		}
		color = Color.cyan * Mathf.LinearToGammaSpace (0.1f);
		mat.SetColor ("_EmissionColor", color);		
	}
	
}
