using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenController : MonoBehaviour {

	MovieTexture movie;


	// Use this for initialization
	void Start () {
		movie = gameObject.transform.FindChild ("Movie").GetComponent<MeshRenderer>().material.mainTexture as MovieTexture;
		movie.loop = true;

//		movie.Play ();
	}
	
	// Update is called once per frame
	void Update () {
			
	}
}
