using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutOfScene : MonoBehaviour {
	private static int count = 3;
	private Transform player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		GameObject.Find("Chances").GetComponent<UnityEngine.UI.Text>().text= count+"x";
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D colisor) {
		if (colisor.gameObject.tag == "Player") {
			player.position = new Vector3(1, 1, 0);
			SceneManager.LoadScene("teste", LoadSceneMode.Single);
			count--;
			GameObject.Find("Score").GetComponent<UnityEngine.UI.Text>().text= count+"x";
		}

		if (count == 0) {
			GameObject.Find("Score").GetComponent<UnityEngine.UI.Text>().text= count+"x";
			SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
			count = 3;
		}

	}
		
}
