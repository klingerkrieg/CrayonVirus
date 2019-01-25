using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {
	public Texture2D background;
	public float time;
	private float count;
	// Use this for initialization
	void Start () {
		gameObject.GetComponent<AudioSource>().mute = false;
	}
	
	// Update is called once per frame
	void Update () {
		
		count += Time.deltaTime;
		if (count >= time) {
			SceneManager.LoadScene("Menu", LoadSceneMode.Single);
		}
	}

	void OnGUI() {
		GUI.DrawTexture (new Rect(0, 0, Screen.width, Screen.height), background);
	}
}
