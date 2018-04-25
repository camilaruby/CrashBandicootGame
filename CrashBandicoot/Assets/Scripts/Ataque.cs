using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataque : MonoBehaviour {

	public float forcaHorizontal = 15;
	public float forcaVertical = 10;
	public float tempoDeDestruicao = 1;

	float forcaHorizontalPadrao;


	// Use this for initialization
	void Start () {

		forcaHorizontalPadrao = forcaHorizontal;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){

		if (other.gameObject.CompareTag ("Enemy")) {

			other.gameObject.GetComponent<Enemy>().enabled = false;

			BoxCollider2D[] boxes = other.gameObject.GetComponents<BoxCollider2D> ();
			foreach (BoxCollider2D box in boxes) {
				box.enabled = false;
			}

			if (other.transform.position.x < transform.position.x) {

				forcaHorizontal *= -1;
			}

			other.gameObject.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (forcaHorizontal, forcaVertical), ForceMode2D.Impulse);
			Destroy (other.gameObject, tempoDeDestruicao);

			forcaHorizontal = forcaHorizontalPadrao;
		}



	}
}
