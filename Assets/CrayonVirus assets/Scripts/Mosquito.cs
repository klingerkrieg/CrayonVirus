using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mosquito : MonoBehaviour{
	public float velocity; //velocidade do mosquito
	public bool direction; //sentido para o qual ele está indo
	public float duringDirection; //tempo que ele vai seguir na direção

	//public GameObject mosquito;

	private float timeDirection; //tempo transcorrido na direção

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//informar qual a direção o mosquito deve ir (false = esquerda; true = direita)
		if (direction) {
			transform.eulerAngles = new Vector2(0, 180);
		} else {
			transform.eulerAngles = new Vector2(0, 0);
		}
		transform.Translate(-Vector2.right * velocity * Time.deltaTime);
		//verificar o tempo - se este for maior ou igual a duração da direção, o mosquito inverte a posição
		timeDirection += Time.deltaTime;
		if (timeDirection >= duringDirection) {
			timeDirection = 0;
			direction = !direction;
		}
	}

	/*void OnCollisionEnter2D (Collision2D colisor){
		if (colisor.gameObject.tag == "Player") {
			colisor.gameObject.GetComponent<Player>().enemy = (GameObject) mosquito;
		}
	}*/
		
}
