using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

	public float velocity; //velocidade do personagem
	public float jumpForce; //força do pulo
	private bool onFloor; //verificar se o personagem está no chão
	public Transform floorTest; //objeto do chão

	public Transform player; //objeto do player
	private Animator animator; //animação

	public float jumpTime = 0.4f; //tempo do pulo
	public float jumpDelay = 0.4f; //delay do pulo
	public bool jumped; //retorna verdadeiro se o boneco tiver pulado
	public Transform ground;

	public int maxLife;
	private int nowLife = 100;

	private int maxNotes = 10;
	private int nowNotes = 0;

	private int score = 0;

	public Config conf = new Config();
	public Itens iten;

	public AudioSource audioData_m;
	public AudioSource audioData_n;
	public AudioSource audioData_i;

	public Color white = new Color(1f, 1f, 1f, 1f);
	public Color black = new Color(0f, 0f, 0f, 0f);
	public Color red = new Color(1f, 1.5f, 0f);

	//public GameObject racketRay;
	//Vector3 rayPos;
	// Use this for initialization
	void Start () {
		animator = player.GetComponent<Animator> (); //a variavel animator recebe os componentes do Animator
		GameObject.Find("Life").GetComponent<UnityEngine.UI.Text>().text= "HP: " + nowLife + "/" + maxLife;
		GameObject.Find("Notes").GetComponent<UnityEngine.UI.Text>().text= "Anotações: " + nowNotes + "/" + maxNotes;
		GameObject.Find("Score").GetComponent<UnityEngine.UI.Text>().text= "Score: " + score;

	}
		
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButton("Cancel")){
			SceneManager.LoadScene("Menu", LoadSceneMode.Single);
		}
		/*if (racketRay != null && Input.GetButtonDown ("Fire1")) {
	
			Racket scriptRacket = racketRay.GetComponent<Racket> ();

			if (Input.GetAxis("Horizontal") > 0)
			{
				rayPos = transform.position;
				//rayPos += 0.5f;
			}

			GameObject ray = Instantiate(racketRay, rayPos, Quaternion.identity);
		}*/
		updatePlayerPosition (); //movimentação do personagem
	}

	void updatePlayerPosition (){
		animator.SetFloat ("movement", Mathf.Abs (Input.GetAxisRaw ("Horizontal"))); //atualizar a posição do player referente ao eixo horizontal
		//<< operador de deslocamento para a esquerda
		onFloor = Physics2D.Linecast(transform.position, floorTest.position, 1 << LayerMask.NameToLayer("Floor"));

		if (Input.GetAxisRaw("Horizontal") > 0 ) { //se seta para direita
			transform.Translate (Vector2.right * velocity * Time.deltaTime); //alterar a posiçao do vetor direito | time.deltatime - tempo por segundos e nao por frame
			transform.eulerAngles = new Vector2(0, 0); //girar o personagem para a direção que ele anda
		}

		if (Input.GetAxisRaw("Horizontal") < 0 ) { //se seta para a esquerda
			transform.Translate (Vector2.right * velocity * Time.deltaTime); //alterar a posição
			transform.eulerAngles = new Vector2(0, 180);
		}

		if (Input.GetButtonDown("Jump") && onFloor && !jumped) {
			gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * jumpForce);
			jumpTime = jumpDelay;
			animator.SetTrigger("jump");
			jumped = true;
			onFloor = false;
			//Debug.Log ("Jumped:" + jumped);
			//Debug.Log ("onFloor:" + onFloor);
		}
			
		jumpTime -= Time.deltaTime;

		if (jumpTime <= 0 && onFloor && jumped) {
			animator.SetTrigger("OnFloor");
			jumped = false;
			//Debug.Log ("Jumped:" + jumped);
			//Debug.Log ("onFloor:" + onFloor);
		}	
			
	}

	public int dano = 5;	
	void OnCollisionEnter2D(Collision2D colisor) {

		if (colisor.gameObject.tag == "Vaccine") {

			if (iten != null && iten.active) {
				dano = 0;
			}
				
			//Debug.Log ("Vacina");
		}

		if (colisor.gameObject.tag == "Enemy") {
			audioData_m.Play ();
			Debug.Log (dano);
			nowLife -= dano;

			if (nowLife <= 20) {
				GameObject.Find("Life").GetComponent<UnityEngine.UI.Text>().color = red;
			}

			if (nowLife <= 0) {
				SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
			} 
				
			GameObject.Find("Life").GetComponent<UnityEngine.UI.Text>().text= "HP: " + nowLife + "/" + maxLife;
		}

		if (colisor.gameObject.tag == "Notes") {
			audioData_n.Play ();
			nowNotes++;
			score += 20;
			GameObject.Find("Notes").GetComponent<UnityEngine.UI.Text>().text = "Anotações: " + nowNotes + "/" + maxNotes;
			GameObject.Find("Score").GetComponent<UnityEngine.UI.Text>().text = "Score: " + score;
		}

		if (colisor.gameObject.tag == "Iten") {
			audioData_i.Play ();
			score += 5;
			GameObject.Find("Score").GetComponent<UnityEngine.UI.Text>().text = "Score: " + score;
		}



		if (colisor.gameObject.tag == "Repellent") {
			if (iten != null && iten.active) {
				velocity = 7;
				jumpForce = 300;
			}
		}

		if (colisor.gameObject.tag == "End") {
			SceneManager.LoadScene("Credits", LoadSceneMode.Single);
		}

		/*if (colisor.gameObject.tag == "Tube_01") {
			player.position = new Vector3(95, -7, 0);
			GameObject.Find("Life").GetComponent<UnityEngine.UI.Text>().color = white;
			GameObject.Find("Notes").GetComponent<UnityEngine.UI.Text>().color = white;
			GameObject.Find("Score").GetComponent<UnityEngine.UI.Text>().color = white;
			Debug.Log (GameObject.Find("Score").GetComponent<UnityEngine.UI.Text>().alignment);
		} 

		if (colisor.gameObject.tag == "Tube_02") {
			player.position = new Vector3(103, 3, 0);
			if(player.position != new Vector3(95, -7, 0)){
			GameObject.Find("Life").GetComponent<UnityEngine.UI.Text>().color =  black;
			GameObject.Find("Notes").GetComponent<UnityEngine.UI.Text>().color = black;
			GameObject.Find("Score").GetComponent<UnityEngine.UI.Text>().color = black;
				Debug.Log (GameObject.Find("Score").GetComponent<UnityEngine.UI.Text>().color);
				Debug.Log (GameObject.Find("Score").GetComponent<UnityEngine.UI.Text>().alignment);
			}
		}*/
				
		

		if (colisor.gameObject.tag == "House") {
			player.position = new Vector3(201, 1, 0);
			GameObject.Find("Life").GetComponent<UnityEngine.UI.Text>().color = white;
			GameObject.Find("Notes").GetComponent<UnityEngine.UI.Text>().color = white;
			GameObject.Find("Score").GetComponent<UnityEngine.UI.Text>().color = white;
		}
			
	}

}
