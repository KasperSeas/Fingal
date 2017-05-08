using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckController : MonoBehaviour {

	private MovieTexture movie;



	void Awake () {
		movie = gameObject.transform.FindChild ("Movie").GetComponent<MeshRenderer>().material.mainTexture as MovieTexture;
		movie.loop = true;
	}

	public bool MovieIsPlaying(){
		return movie.isPlaying;
	}

	public void ResetMovie(){
		movie.Stop ();
	}

	public void PlayMovie(){
		movie.Play ();
	}

	public void PauseMovie(){
		movie.Pause ();
	}




}
