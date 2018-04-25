using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public float speed;
	Rigidbody2D rb;
	bool facingRight = false;
	bool noChao = false;
	Transform groundCheck;

	public float jumpForce = 700;

	AudioSource audioS;


	void Start () {

		rb = gameObject.GetComponent<Rigidbody2D> ();
		groundCheck = transform.Find("EnemyGroundCheck");
		audioS = gameObject.GetComponent<AudioSource> ();
		
	}
	

	void Update () {

		noChao = Physics2D.Linecast (transform.position, groundCheck.position, 1 << LayerMask.NameToLayer ("Ground"));
		if(!noChao){
			speed *= -1;
		}
	}

	void FixedUpdate(){

		rb.velocity = new Vector2 (speed, rb.velocity.y);

		if(speed > 0 && !facingRight){

			Flip ();

		}else if(speed < 0 && facingRight){

			Flip ();
		}
	}


	void Flip(){

		facingRight = !facingRight;

		Vector3 theScale = transform.localScale;
		theScale.x *= -1;

		transform.localScale = theScale;
	}

	void OnTriggerEnter2D(Collider2D other){

		if (other.gameObject.CompareTag ("Player")) {

			audioS.Play ();
			BoxCollider2D[] boxes = gameObject.GetComponents<BoxCollider2D> ();
			foreach (BoxCollider2D box in boxes) {

				box.enabled = false;
			}

			other.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
			other.gameObject.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, jumpForce));

			speed = 0;
			transform.Rotate (new Vector3 (0, 0, -180));
			Destroy (gameObject, 3);
		}
	}

	void OnCollisionEnter2D(Collision2D other){

		if (other.gameObject.CompareTag ("Player")) {

			other.gameObject.GetComponent<PlayerLife> ().PerdeVidas ();
		}
	}
}
