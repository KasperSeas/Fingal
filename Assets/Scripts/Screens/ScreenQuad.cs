using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenQuad : MonoBehaviour {

	public Vector2[] uvs = new Vector2[4];
	
	void Awake(){
		uvs [0] = new Vector2 (0,1);
		uvs [1] = new Vector2 (1,1);
		uvs [2] = new Vector2 (0,0);
		uvs [3] = new Vector2 (1,0);
	}


}
