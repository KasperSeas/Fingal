using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightGroup : MonoBehaviour {

	StrobeLight[] strobes; // Each LightGroup has array of StrobeLights
	Color baseColor;
	Color finalColor;
	Color offColor;

	private Coroutine currrentMode = null;

	// Strober
	IEnumerator strober; bool strober_on;
	float strobeSpeed;

	// Brightness
	float brightness;

	// Alt
	IEnumerator alt; public bool alt_on;
	float altSpeed;

	// Cycle
	IEnumerator cycle; public bool cycle_on;
	float cycleSpeed;
	bool isPosDir;
	int numOfLights_cycle;
	int width_cycle;

	void Start () {
		// initialize array of StrobeLights of all children
		strobes = new StrobeLight[transform.childCount];
		for(int i = 0; i < transform.childCount; i++){
			StrobeLight strobe = transform.GetChild(i).GetComponent<StrobeLight> ();
			strobes [i] = strobe;
		}
			
		// Strober Mode
		// create reusable  coroutines
		strober = _strobe (); strober_on = false;
		strobeSpeed = 0.05f; //initial strobe speed
		// Brightness Mode
		brightness = 0.5f; // inital brightness
		// Alt Mode
		// create reusable coroutines
		alt = _alt (); alt_on = false; 
		altSpeed = 0.05f; // inital speed
		// Cycle Mode
		// create reusable coroutines
		cycle = _cycle (); cycle_on = false;
		cycleSpeed = 0.05f; // initial speed
		isPosDir = false;	// initial direction
		numOfLights_cycle = 1; // initial number of lights
		width_cycle = 1;	// inital width

		// Color
		baseColor = Color.white;
		finalColor = baseColor * Mathf.LinearToGammaSpace (brightness); // Fully Emissive
		offColor = baseColor * Mathf.LinearToGammaSpace (0); // No Emission
	}

	public void allOn(){
		foreach (StrobeLight s in strobes) {
			s.setActive (true);
		}
	}
	public void allOff(){
		foreach (StrobeLight s in strobes) {
			s.setActive (false);
		}
	}

	////////// STROBE SETTINGS \\\\\\\\\\
	public void startStrober(){
		if(strober_on == false)
			StartCoroutine(strober);	
		strober_on = true;
	}
	public void stopStrober(){
		StopCoroutine(strober);
		strober_on = false;
	}
	public void setStrobeSpeed(float speed){
		strobeSpeed = speed;
	}
	IEnumerator _strobe(){
		while (true) {
			for (int i = 0; i < strobes.Length; i++) {
				if (strobes [i].isActive) {
					strobes [i].setColor (finalColor);	
				}
			}
			yield return new WaitForSeconds(strobeSpeed);
			for (int i = 0; i < strobes.Length; i++) {
				if (strobes [i].isActive) {
					strobes[i].setColor (offColor);	
				}
			}
			yield return new WaitForSeconds(strobeSpeed);
		}
	}
	/////////////////////////////////////
	////////// BRIGHTNESS SETTINGS \\\\\\
	public void setBrightness(float bright){
		brightness = bright;
		finalColor = baseColor * Mathf.LinearToGammaSpace (brightness);
	}
	/////////////////////////////////////
	////////// ALT SETTINGS \\\\\\\\\\\\\
	public void startAlt(){
		if(alt_on == false)
			StartCoroutine(alt);	
		alt_on = true;
	}
	public void stopAlt(){
		StopCoroutine(alt);
		alt_on = false;
		allOff ();
	}
	public void setAltSpeed(float speed){
		altSpeed = speed;
	}
	void evenOn(){
		for(int i=0; i<strobes.Length; i++){
			if (i % 2 == 0) {
				strobes [i].setActive(true);		
			}
		}
	}
	void oddOn(){
		for(int i=0; i<strobes.Length; i++){
			if (i % 2 == 1) {
				strobes [i].setActive(true);			
			}
		}
	}
	IEnumerator _alt(){
		while (true) {
			allOff ();
			evenOn ();
			yield return new WaitForSeconds(altSpeed);
			allOff ();
			oddOn ();
			yield return new WaitForSeconds(altSpeed);
		}
	}
	///////////////////////////////////////
	////////// Cycle SETTINGS \\\\\\\\\\\\\
	public void startCycle(){
		if(cycle_on == false)
			StartCoroutine(cycle);	
		cycle_on = true;
	}
	public void stopCycle(){
		StopCoroutine(cycle);
		cycle = null;
		cycle = _cycle();
		cycle_on = false;
		allOff ();
	}
	public void setCycleSpeed(float speed){
		cycleSpeed = speed;
	}
	public void setCycleDirection(bool posDir){
		isPosDir = posDir;
	}
	public void setCycleLightNum(int numLights){
		numOfLights_cycle = numLights;
	}
	public void setCycleWidth(int width){
		width_cycle = width;
	}
	void activateLightCycle(int iter){
		for (int i = 0; i < width_cycle; i++) {
			strobes [(iter + i)%strobes.Length].setActive(true);	
		}
	}
	IEnumerator _cycle(){
		int i = 0;
		while (true) {
			if (i < 0)
				i = strobes.Length-1;
			if(i >= strobes.Length)
				i = 0;
			if (isPosDir) {
				if (numOfLights_cycle == 1) {
					activateLightCycle (i++);
				} else if (numOfLights_cycle > 1) {
					for(int j = 1; j < numOfLights_cycle; j++){
						activateLightCycle ((i+(strobes.Length)*j/numOfLights_cycle));	
					}
					activateLightCycle (i++);
				}
				yield return new WaitForSeconds(cycleSpeed);
				allOff ();
			} else {
				if (numOfLights_cycle == 1) {
					activateLightCycle (i--);
				} else if (numOfLights_cycle > 1) {
					for(int j = 1; j < numOfLights_cycle; j++){
						activateLightCycle ((i+(strobes.Length)*j/numOfLights_cycle));	
					}
					activateLightCycle (i--);
				}
				yield return new WaitForSeconds(cycleSpeed);
				allOff ();
			}	
		}
	}
	/////////////////////////////////////
	void Update(){
		for (int i = 0; i < strobes.Length; i++) {
			if (strobes [i].isActive) {
				strobes [i].setColor (finalColor);	
			} else {
				strobes [i].setColor (offColor);	
			}
		}
	}
}
