using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed;
	public float jumpForce;


	private Rigidbody2D rb;
	private bool facingRight = true;
	private bool jump = false;
	private Animator anim;
	private bool noChao = false;
	private Transform groundCheck;

	void Start () {

		rb = gameObject.GetComponent<Rigidbody2D>();
		anim = gameObject.GetComponent<Animator>();
		groundCheck = gameObject.transform.Find ("GroundCheck");
	}
	

	void Update () {

		noChao = Physics2D.Linecast (transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

		if (Input.GetButtonDown ("Jump") && noChao) {

			jump = true;
			anim.SetTrigger("Pulou");
		}
		
	}

	void FixedUpdate(){

		float h = Input.GetAxisRaw("Horizontal");
		anim.SetFloat ("Velocidade", Mathf.Abs (h));

		rb.velocity = new Vector2 (h * speed, rb.velocity.y);

		if(h > 0 && !facingRight){

			Flip();

		}else if(h < 0 && facingRight){
			
			Flip ();
		}


		if (jump) {

			rb.AddForce (new Vector2 (0, jumpForce));
			jump = false;
		}

	}

	void Flip(){

		facingRight = !facingRight;

		Vector3 theScale = transform.localScale;

		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
