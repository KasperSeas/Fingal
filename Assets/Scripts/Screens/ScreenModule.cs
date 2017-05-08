using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenModule : MonoBehaviour {
	//public ScreenSet[] screenSets;
	public ScreenProjector projector;

	private bool mainDeckSwitch = true;

	void Update(){
		DeckCtrl ();
		DeckACtrl ();
		DeckBCtrl ();
	}

	void DeckCtrl(){
		if (Input.GetKeyUp (KeyCode.Alpha3)) { // Fader Switch Main Screen A<->B
			mainDeckSwitch = !mainDeckSwitch;

			if(mainDeckSwitch){
				
				projector.MainDeckLoad (0);
			} else {
				projector.MainDeckLoad (1);	
			}
		}	
	}

	void DeckACtrl(){
		// Reset
		if (Input.GetKeyUp (KeyCode.Alpha1)) {
			projector.ResetDeck (0);
		}
		// Play/Pause
		if (Input.GetKeyUp (KeyCode.Q)) {
			if (projector.DeckMovieIsPlaying(0)) {
				projector.PauseDeck (0);	
			} else {
				projector.PlayDeck (0);
			}


		}
	}

	void DeckBCtrl(){
		// Reset
		if (Input.GetKeyUp (KeyCode.Alpha2)) {
			projector.ResetDeck (1);	
		}
		// Play/Pause
		if (Input.GetKeyUp (KeyCode.W)) {
			if (projector.DeckMovieIsPlaying(1)) {
				projector.PauseDeck (1);	
			} else {
				projector.PlayDeck (1);
			}
		}
	}

}
