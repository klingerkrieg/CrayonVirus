using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instancier : MonoBehaviour {

	public GameObject[] objects;
	private bool isLeft;
	public float velocity = 0.15f;
	public float maxDelay;

	public float instancierTime;
	public float instancierDelay;

	public float movementTime;
	public int minRandom;
	// Use this for initialization
	void Start () {
		InvokeRepeating ("Spawn", instancierTime, instancierDelay);
	}
	
	// Update is called once per frame
	void Update () {
		movement ();
	}

	void Spawn(){
		int index = Random.Range (minRandom, objects.Length);
		Instantiate (objects [index], transform.position, objects [index].transform.rotation);
	}

	void movement(){
		movementTime += Time.deltaTime;

		if (movementTime <= maxDelay) {
			if (isLeft) { 
				transform.Translate (-Vector2.right * velocity * Time.deltaTime); 

			} else { 
				transform.Translate (Vector2.right * velocity * Time.deltaTime); 
			}
		} 
		else {
			isLeft = !isLeft;
			movementTime = 0;
		}
	}
}
