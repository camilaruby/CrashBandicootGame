using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static GameManager gm;

	private int vidas = 2;
	private int frutas = 0;


	void Awake () {
		
		if (gm == null) {

			gm = this;
			DontDestroyOnLoad (gameObject);

		} else {
			Destroy (gameObject);
		}
	}

	void Start(){

		AtualizaHud ();
	}
	

	void Update () {
		
	}

	public void setVidas(int vida){

		vidas += vida;
		if (vidas >= 0) {
			AtualizaHud ();
		}

	}

	public int GetVidas(){

		return vidas;
	}

	public void SetFrutas(int fruta){

		frutas += fruta;

		if(frutas >= 15){

			frutas = 0;
			vidas += 1;
		}

		AtualizaHud ();
	}

	public void AtualizaHud(){
		GameObject.Find ("VidasText").GetComponent<Text> ().text = vidas.ToString ();
		GameObject.Find ("FrutaText").GetComponent<Text> ().text = frutas.ToString ();
	}


	void OnLevelWasLoaded(){

		if(SceneManager.GetActiveScene().buildIndex == 0){
			
			vidas = 2;
			frutas = 0;
		}
		
	}

}
