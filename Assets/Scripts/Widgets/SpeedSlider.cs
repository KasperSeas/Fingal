using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedSlider : MonoBehaviour {

	Transform handle;
	float maxHeight;
	float minHeight;
	float slideHeight;
	float handleIncrement;

	// Material
	Renderer rend;
	Material mat;
	Color color;
	float matIntensity;

	void Start () {
		handle = transform.FindChild ("Handle");
		slideHeight = transform.FindChild ("Slide").localScale.z;
		maxHeight = slideHeight * 5;
		minHeight = -maxHeight;
		handleIncrement = maxHeight / 10;
		// Material
		matIntensity = 0.02f;
		rend = handle.GetComponent<Renderer> ();
		mat = rend.material;
		color = Color.cyan * Mathf.LinearToGammaSpace (matIntensity);
		mat.SetColor ("_EmissionColor", color);
	}

	public void slideUp(){
		if (handle.localPosition.y+handleIncrement < maxHeight ){
			handle.Translate (new Vector3 (0, handleIncrement, 0));
			matIntensity += 0.005f;
			color = Color.cyan * Mathf.LinearToGammaSpace (matIntensity);
			mat.SetColor ("_EmissionColor", color);
		} 
	}

	public void slideDown(){
		if(handle.localPosition.y-handleIncrement > minHeight){
			handle.Translate (new Vector3(0, -handleIncrement, 0));
			matIntensity -= 0.005f;
			color = Color.cyan * Mathf.LinearToGammaSpace (matIntensity);
			mat.SetColor ("_EmissionColor", color);
		} 
	}

	public float getCurrentVal(){
		// Returns values 0.0-1.0 with 0.05 increments (20 values total)
		float val = (handle.localPosition.y+maxHeight)/maxHeight/2;
		return Mathf.Round( (val)*100f ) / 100f;	
	}

}
