using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	public Texture2D background;
	public Font djb;

	// Use this for initialization
	void Start () {
		Debug.Log (Screen.height);
	}

	// Update is called once per frame
	void Update () {
	}

	void OnGUI() {
		GUI.DrawTexture (new Rect(0, 0, Screen.width, Screen.height), background);
		GUI.skin.font = djb;
		GUI.color = Color.black;

		if (GUI.Button (new Rect (Screen.width/2, (Screen.height/2)+20, 70, 35), "Play")) {
			SceneManager.LoadScene("teste", LoadSceneMode.Single);
		}
		if(GUI.Button (new Rect (Screen.width/2, (Screen.height/2)+70, 70, 35), "Sair")){
			Application.Quit();
		}
	}
}
