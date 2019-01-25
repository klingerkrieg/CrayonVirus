using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config {

	Itens iten = new Itens();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool checkIten(){
		if (iten.active == true) {
			return true;
		} else {
			return false;
		}
	}
}
