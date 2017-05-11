using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

[RequireComponent (typeof(VideoPlayer))]
[RequireComponent (typeof(Renderer))]
public class Video : Media {

    VideoPlayer VP;
    Material Mat;
    Color TintColor;

	void Awake () {
        VP = GetComponent<VideoPlayer>();
        Mat = GetComponent<Renderer>().material;
        TintColor = new Color(0,0,0,1);
	}

    public override void Play() {
        base.Play();
        VP.Play();
    }

    public override void Pause()
    {
        base.Pause();
        VP.Pause();
    }

    public override void Reset()
    {
        Seek(0f);
    }

    public override void Seek(float percent)
    {   // percent = 0.0 - 1.0
        long f = (long)(percent * VP.frameCount);
        VP.frame = f;
    }

    // MATERIAL SETTINGS
    public void Tint(float r, float g, float b, float a) {
        TintColor.r = r;
        TintColor.g = g;
        TintColor.b = b;
        TintColor.a = a;
        Mat.SetColor("_TintColor", TintColor);
    }

   

    


}
