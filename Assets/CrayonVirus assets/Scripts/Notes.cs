using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Notes : MonoBehaviour {
	public GameObject notes;
	public GameObject btn;
	public Button btn_click;
	//public Image notes_img;

	// Use this for initialization
	void Start () {
		//notes_img.enabled = false;
		btn.SetActive(false);
		notes.gameObject.SetActive (false);
		btn_click.onClick.AddListener(TaskOnClick);
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Cancel")) {
			notes.gameObject.SetActive (false);
			//notes_img.enabled = false;
			btn.SetActive(false);
			Time.timeScale = 1;
			Debug.Log ("ok");
		}
	}	

	void TaskOnClick(){
		notes.gameObject.SetActive (false);
		//notes_img.enabled = false;
		btn.SetActive(false);
		Time.timeScale = 1;
	}

	void OnCollisionEnter2D (Collision2D colisor){
		if (colisor.gameObject.tag == "Player") {
			//notes_img.enabled = true;
			btn.SetActive (true);
			notes.SetActive (true);
			Time.timeScale = 0;
			Destroy (gameObject);
		}
	}

}
