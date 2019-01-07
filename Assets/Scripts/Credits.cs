using UnityEngine;
using System.Collections;

public class Credits : MonoBehaviour {
	bool block;
	float contador, alphaController;
	int direction, numberText;

	public GUISkin skin;
	[Range(0, 1)]
	[SerializeField] float speed = 1;	
	[SerializeField] string[] text;
	// Use this for initialization
	void Start () {
		text [0] = "Parabens por finalizar nosso jogo "+ PlayerPrefs.GetString (PlayerStatsController.CurrentSave ()+"nome");
		PlayerPrefs.SetInt (PlayerStatsController.CurrentSave () + "progresso", 2);
		PlayerHudController.DeleteControllers ();
		light.intensity = 0;
		alphaController = 0;
		direction = 1;
		block = true;
		numberText = 0;
	}
	//GetComponent(SpriteRenderer).color.a = 1.0; ALPHA
	//GUI.color = new Color(1,1,1,0.5f); ALPHA EM GUI

	// Update is called once per frame
	void Update () {
		contador = Time.deltaTime * speed;
		if (block) {
			if (alphaController < 1 && direction > 0)
				alphaController += contador * direction;
			else if (alphaController > 1 && direction > 0)
				StartCoroutine (FlipLight () );

			if (alphaController >= 0.01f && direction < 0)
				alphaController += contador * direction;
			else if (alphaController < 0.01f && direction < 0) {
				StartCoroutine (FlipLight () );
			}
		}

		if ( numberText >= text.Length )
			StartCoroutine (QuitCredit () );

	}

	void OnGUI () {

		GUI.skin = skin;
		GUI.color = new Color(1,1,1,alphaController);
		GUI.Label (new Rect ((Screen.width - Screen.width * 2/3) /2, (Screen.height - Screen.height * 2/3) /2, Screen.width * 2/3, Screen.height * 2/3), text[numberText]);

	}


	IEnumerator FlipLight () {
		block = false;
		yield return new WaitForSeconds(2.0f);
		direction = -direction;
		if ( direction == 1 && numberText < text.Length)
			numberText ++;
		block = true;
	}
	IEnumerator QuitCredit () {
		yield return new WaitForSeconds(2.0f);
		Application.LoadLevel ("Menu");
	}
}
