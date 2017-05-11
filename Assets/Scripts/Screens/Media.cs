using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Media : MonoBehaviour, IPlayable {

    public bool isPlaying;

    protected float Speed;
    protected float TotalTime;

	void Awake () {
        isPlaying = false;
	}
	
	void Update () {
		
	}

    public virtual void Play() {
        isPlaying = true;
    }

    public virtual void Pause()
    {
        isPlaying = false;
    }

    public virtual void Reset() { }

    public virtual void Seek(float time) { }

    public virtual void SetSpeed(float speed)
    {
        Speed = speed;
    }

    public virtual float GetSpeed()
    {
        return Speed;
    }

    public float GetTotalTime()
    {
        return TotalTime;
    }
}
