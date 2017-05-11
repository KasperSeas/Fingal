using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenProjector : MonoBehaviour {
	private Camera camera;
    private Material MainCameraOverlay;
    private Color MainCameraOverlayColor;
	private Transform MainDeck;
	private Transform MainDeckPosition;
	private Transform OffDeckPosition;
    private Video[] Videos;
    private Shader[] CameraEffects;

	public Transform[] Decks;

	void Awake(){

        if (Decks != null)
        {
            Videos = new Video[Decks.Length];
            for (int i = 0; i < Decks.Length; i++)
            {
                Videos[i] = Decks[i].FindChild("Video").GetComponent<Video>();
            }
        }
        else {
            Debug.LogError("Decks are not connected!");
        }

        CameraEffects = Resources.LoadAll<Shader>("Shaders/Camera");

		camera = transform.FindChild ("CameraRig").GetComponent<Camera>();
        MainCameraOverlay = transform.FindChild("MainOverlay").GetComponent<Renderer>().material;
        MainCameraOverlayColor = new Color(1f,1f,1f,0f);
        MainCameraOverlay.SetColor("_TintColor", MainCameraOverlayColor);
		MainDeckPosition = transform.FindChild ("MainDeckPosition");
		OffDeckPosition = transform.FindChild ("OffDeckPosition");
		MainDeck = Decks[0];
		MainDeckLoad (0);
	}




    // OVERLAY
    public void OverlayColor(float r, float g, float b) {
        MainCameraOverlayColor.r = r;
        MainCameraOverlayColor.g = g;
        MainCameraOverlayColor.b = b;
        MainCameraOverlay.SetColor("_TintColor", MainCameraOverlayColor);
    }

    public void OverlayAlpha(float a) {
        MainCameraOverlayColor.a = a;
        MainCameraOverlay.SetColor("_TintColor", MainCameraOverlayColor);
    }

    public void Overlay(float r, float g, float b, float a){
        MainCameraOverlayColor.r = r;
        MainCameraOverlayColor.g = g;
        MainCameraOverlayColor.b = b;
        MainCameraOverlayColor.a = a;
        MainCameraOverlay.SetColor("_TintColor", MainCameraOverlayColor);
    }


    // DECK Control
    public void MainDeckLoad(int deckID)
    {
        MainDeck.transform.position = OffDeckPosition.position;
        MainDeck = Decks[deckID];
        MainDeck.transform.position = MainDeckPosition.position;
    }

    public bool DeckMovieIsPlaying(int deckID){
		return Videos [deckID].isPlaying;
	}

	public void ResetDeck(int deckID){
        Videos[deckID].Reset();
    }
		
	public void PlayDeck(int deckID){
        Videos[deckID].Play();	
	}

	public void PauseDeck(int deckID){
        Videos[deckID].Pause();
	}

    public void SeekDeck(int deckID, float percent) {
        Videos[deckID].Seek(percent);
    }

    public void Fader(int deckID1, int deckID2, float fadeLevel) { 
        fadeLevel = Mathf.Clamp(fadeLevel, -1f, 1f);
        float f1 = ((-1f * fadeLevel) + 1f) / 2f;
        float f2 = 1f - f1;
        Videos[deckID1].Tint(1f,1f,1f,f1);
        Videos[deckID2].Tint(1f,1f,1f,f2);
    }

}
