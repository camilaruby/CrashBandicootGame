using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaixaScript : MonoBehaviour {

	Animator anim;

	public float jumpForce;
	public int frutas;
	public GameObject frutaPrefab;

	public AudioClip[] audios;
	AudioSource audioS;


	void Start () {
		anim = gameObject.GetComponent<Animator> ();
		audioS = gameObject.GetComponent<AudioSource> ();
	}
	

	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){

		if (other.gameObject.CompareTag ("Player")) {

			audioS.clip = audios[0];
			audioS.Play ();
			other.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
			other.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, jumpForce));
			anim.SetTrigger ("Colidindo");

			if (frutas > 0) {

				GameObject tempFruta = Instantiate (frutaPrefab, transform.position, transform.rotation) as GameObject;
				tempFruta.GetComponent<Animator> ().SetTrigger ("Coletando");

				tempFruta.GetComponent<AudioSource> ().Play ();

				frutas -= 1;
				GameManager.gm.SetFrutas (1);
				Destroy (tempFruta, 0.667f);
			} else {

				audioS.clip = audios [1];
				AudioSource.PlayClipAtPoint (audios[1], transform.position);

				Destroy (gameObject);
			}
		}
	}
}
