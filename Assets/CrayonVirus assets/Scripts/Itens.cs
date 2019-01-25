using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Itens : MonoBehaviour {
	public GameObject iten;
	public float imageTime;
	public bool active;

	public Player player;
	// Use this for initialization
	void Start () {
		iten.SetActive (false);
		active = false;
	}

	// Update is called once per frame
	void Update () {
	}

	void OnCollisionEnter2D (Collision2D colisor){
		if (colisor.gameObject.tag == "Player") {
			iten.SetActive (true);
			active = true;
			colisor.gameObject.GetComponent<Player>().iten = this;
			StartCoroutine (WaitTime(imageTime));
			//Deixa invisivel
			GetComponent<BoxCollider2D>().enabled = false;
			GetComponent<SpriteRenderer>().enabled = false;
		}
	}


	IEnumerator WaitTime(float time){
		Debug.Log (time);

		yield return new WaitForSeconds (time);
		iten.SetActive (false);
		active = false;
		Debug.Log ("Pronto");
		//Nao pode destruir la no collision se nao ele
		//para de executar tudo, inclusive o WaitForSeconds
		Destroy (gameObject);
		player.dano = 5;
		player.jumpForce = 250;
		player.velocity = 5;
	}
}