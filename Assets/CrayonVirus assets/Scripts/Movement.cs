using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	public float velocity;
	public float timePosition;
	private float time;
	public bool position;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		//Incrementa o tempo da direção
		time += Time.deltaTime;

		//Se o tempo for maior ou igual o tempo limite da direção atual, ele passa para outra
		if (time >= timePosition) {
			//Zera contagem
			time = 0;

			//Muda a posiçao
			if (position) {
				position = false;
			} else {
				position = true;
			}
		}
		//movimenta
		if (position) {
			transform.Translate (Vector2.right * velocity * Time.deltaTime);
		} else {
			transform.Translate (-Vector2.right * velocity * Time.deltaTime);
		}

	}
	//O Player se move na direção da plataforma
	void OnCollisionStay2D(Collision2D colisor) {
		if (colisor.gameObject.name == "Player") {
			colisor.gameObject.transform.parent = transform;
		}
	}
	//O Player deixa de se mover na direção da plataforma
	void OnCollisionExit2D(Collision2D colisor) {
		if (colisor.gameObject.name == "Player") {
			colisor.gameObject.transform.parent = null;
		}
	}
}
