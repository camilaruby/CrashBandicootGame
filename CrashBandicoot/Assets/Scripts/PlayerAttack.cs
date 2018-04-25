using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

	Animator anim;

	public float intervaloDeAtaque;
	private float proximoAtaque;

	public AudioClip spinSound;
	private AudioSource audioS;



	void Start () {
		anim = gameObject.GetComponent<Animator>();
		audioS = gameObject.GetComponent<AudioSource> ();
	}
	

	void Update () {

		if(Input.GetButtonDown("Fire1") && Time.time > proximoAtaque){

			Atacando ();
		}
		
	}

	void Atacando(){

		audioS.clip = spinSound;
		audioS.Play (); //toca o som
		anim.SetTrigger ("Ataque");
		proximoAtaque = Time.time + intervaloDeAtaque;
	}
}
