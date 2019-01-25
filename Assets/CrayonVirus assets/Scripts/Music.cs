using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour {
	//public Texture2D musicOn; 
	//public Texture2D musicOff; 
	public bool active;
	// Use this for initialization
	void Start () {
		active = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (active) {
			gameObject.GetComponent<AudioSource>().mute = false;
			//gameObject.GetComponent<GUITexture>().texture = musicOn;
		//} else {
			//gameObject.GetComponent<AudioSource>().mute = true;
			//gameObject.GetComponent<GUITexture>().texture = musicOff;
		}
	}

	/*void OnMouseDown() {
		active = !active;
	}*/
}
