using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformFall : MonoBehaviour {

	private float timeFall = 0.5f;
	private float time;
	private bool onPlataform;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (onPlataform) {
			time += Time.deltaTime;

			if (time >= timeFall) {
				gameObject.AddComponent<Rigidbody2D>();
				Destroy (gameObject,2f);
			}
		}
	}

	void OnCollisionEnter2D(Collision2D colisor) {
		if (colisor.gameObject.name == "Player") {
			onPlataform = true;
		}
	}
}
