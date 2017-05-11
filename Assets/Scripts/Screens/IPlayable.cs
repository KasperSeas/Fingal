using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayable {

    void Play();
    void Pause();
    void Reset();
    void Seek(float time);
    void SetSpeed(float speed);
    float GetSpeed();
    float GetTotalTime();

	
}
