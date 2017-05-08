using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Widget : MonoBehaviour {

	private Transform thisTransform {get; set;}
	private Vector3 pos {get; set;}

//	public Widget () {
//		Debug.Log (gameObject);
//		gameObject.AddComponent<Transform> ();
//		thisTransform = transform;
//		this.pos = new Vector3 (0, 0, 0);
//	}
//
//	public Widget (Vector3 pos) {
//		thisTransform = transform;
//		this.pos = pos;
//	}

//	public virtual void Trigger(){
//		Debug.Log ("Widget Triggered!");
//	}

//	public Widget(): this(0, 0, 0){}

	public virtual void Trigger(){
		Debug.Log ("Widget Triggered");
	}
}
