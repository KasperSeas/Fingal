using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenProjector : MonoBehaviour {
	private Camera camera;
	private DeckController MainDeck;
	private Transform MainDeckPosition;
	private Transform OffDeckPosition;

	public DeckController[] Decks;

	void Awake(){
		camera = transform.FindChild ("CameraRig").GetComponent<Camera>();
		MainDeckPosition = transform.FindChild ("MainDeckPosition");
		OffDeckPosition = transform.FindChild ("OffDeckPosition");
		MainDeck = Decks[0];
		MainDeckLoad (0);
	}


	public void MainDeckLoad(int deckID){
		MainDeck.transform.position = OffDeckPosition.position;
		MainDeck = Decks [deckID];
		MainDeck.transform.position = MainDeckPosition.position;
	}

	public bool DeckMovieIsPlaying(int deckID){
		return Decks [deckID].MovieIsPlaying ();
	}

	public void ResetDeck(int deckID){
		Decks [deckID].ResetMovie ();	
	}
		
	public void PlayDeck(int deckID){
		Decks [deckID].PlayMovie ();	
	}

	public void PauseDeck(int deckID){
		Decks [deckID].PauseMovie ();	
	}

}
