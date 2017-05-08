using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slider : Widget {

	private int knotches { get; set;}
	private float sliderSize { get; set;}

	public Slider(int knotches, float sliderSize) : base() {
		this.knotches = knotches;
		this.sliderSize = sliderSize;
	}

	public void Init(int knotches, float sliderSize) {
		this.knotches = knotches;
		this.sliderSize = sliderSize;
	}

	void Start(){
		Debug.Log ("Slider Triggered");	
	}

	public override void Trigger () {
		Debug.Log ("Slider Triggered");
	}
}
