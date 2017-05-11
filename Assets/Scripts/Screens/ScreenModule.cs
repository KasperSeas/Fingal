using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ScreenModule : MonoBehaviour
{

    public enum Widget { Fader, LoopSpeedA, LoopSpeedB }

    //public ScreenSet[] screenSets;
    public ScreenProjector projector;
    float fade = 0f;
    bool strobe = false;
    float BPM = 128f;
    float Beat1; // every beat
    float Beat2; // every 2 beats




    private bool mainDeckSwitch = true;

    private void Awake()
    {

        Beat1 = 60f / BPM; // every beat
        Beat2 = 2 * (60f / BPM); // every 2 beats
    }

    private void Start()
    {

        InvokeRepeating("moo", 0f, Beat2);
    }

    void Update()
    {
        DeckCtrl();
        DeckACtrl();
        DeckBCtrl();
    }

    void DeckCtrl()
    {
        if (Input.GetKeyUp(KeyCode.Alpha3))
        { // Fader Switch Main Screen A<->B
            mainDeckSwitch = !mainDeckSwitch;

            if (mainDeckSwitch)
            {

                projector.MainDeckLoad(0);
            }
            else
            {
                projector.MainDeckLoad(1);
            }
        }
    }

    void DeckACtrl()
    {
        // Reset
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            projector.ResetDeck(0);
        }
        // Play/Pause
        if (Input.GetKeyUp(KeyCode.Q))
        {
            if (projector.DeckMovieIsPlaying(0))
            {
                projector.PauseDeck(0);
            }
            else
            {
                projector.PlayDeck(0);
            }
        }

        // Seek
        if (Input.GetKeyUp(KeyCode.A))
        {
            projector.SeekDeck(0, 0.5f);
        }
        if (Input.GetKeyUp(KeyCode.Z))
        {
            projector.SeekDeck(0, 0.75f);
        }

        // Brightness
        if (Input.GetKeyUp(KeyCode.S))
        {
            projector.OverlayAlpha(100 / 255f);
        }
        if (Input.GetKeyUp(KeyCode.X))
        {
            projector.OverlayAlpha(0f);
        }



        // Strobe
        if (Input.GetKeyUp(KeyCode.D))
        {
            StartCoroutine(ScreenSwitch2BeatStrobe());
            strobe = true;
        }
        if (Input.GetKey(KeyCode.F))
        {
            //StartCoroutine(ColorStrobe());
            strobe = false;
        }

    }

    void DeckBCtrl()
    {
        // Reset
        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            projector.ResetDeck(1);
        }
        // Play/Pause
        if (Input.GetKeyUp(KeyCode.W))
        {
            if (projector.DeckMovieIsPlaying(1))
            {
                projector.PauseDeck(1);
            }
            else
            {
                projector.PlayDeck(1);
            }
        }
    }

    //STROBE Coroutines
    IEnumerator ColorStrobe()
    {
        float val = 0.9f;
        float timeInval = 60f / BPM;
        float d = (1f / timeInval) * Time.deltaTime / 2f;
        float startTime = Time.time;
        while (true)
        {
            if (val <= 0.0f) break;
            projector.Overlay(val -= d, 0f, 0f, val -= d);
            yield return null;
        }
        projector.Overlay(0f, 0f, 0f, 0f);
        yield return null;
    }

    IEnumerator ScreenSwitch2BeatStrobe()
    {
        float timeInval = 60f / BPM;
        projector.MainDeckLoad(1);
        yield return new WaitForSeconds(timeInval);
        projector.MainDeckLoad(0);
    }

    void moo()
    {
        StartCoroutine(ScreenSwitch2BeatStrobe());
    }

    public void SetValue(Widget widget, float value)
    {
        switch (widget)
        {
            case Widget.Fader:
                Fader(value);
                break;
            case Widget.LoopSpeedA:
                Fader(value);
                break;
            default: break;

        }
    }

    private void Fader(float value)
    {
        projector.Fader(0, 1, value);
    }

    private void LoopSpeedA(float value)
    {



    }
}
