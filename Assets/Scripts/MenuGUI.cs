using UnityEngine;
using System.Collections;

public class MenuGUI : MonoBehaviour {
	public GUISkin ButtonOneSide, ButtonMultiSide, LabelSkin;

	//dimensoes dos botoes
	string hover;
	int  com, alt, stats, currentSave;
	int[] acrescimo = new int[3];
	string nameChar;
	// Use this for initialization
	void Start () {
		transform.position = new Vector3 (0,0,2);
		stats = 1;

		if (PlayerPrefs.GetString ("Personagem1"+"nome") == "")
			PlayerPrefs.SetString ("Personagem1"+"nome", "Empty");
		if (PlayerPrefs.GetString ("Personagem2"+"nome") == "")
			PlayerPrefs.SetString ("Personagem2"+"nome", "Empty");
		if (PlayerPrefs.GetString ("Personagem3"+"nome") == "")
			PlayerPrefs.SetString ("Personagem3"+"nome", "Empty");
	}
	
	// Update is called once per frame
	void Update () {

		if (hover == "PLAY")
			acrescimo[0] = Screen.width* 1/15;
		else if (hover == "HOW TO PLAY")
			acrescimo[1] = Screen.width* 1/15;
		else if (hover == "QUIT")
			acrescimo[2] = Screen.width* 1/15;
		else {
			acrescimo[0] =0;
			acrescimo[1] =0;
			acrescimo[2] =0;
		}
		currentSave = PlayerPrefs.GetInt ("currentSave");

		switch (stats) {
			case 1: // INICIO
					break;
			case 2: // SELECIONAR SAVE
					break;
			case 3: // CREDITOS
					transform.position = new Vector3 (0,0,-2);
					break;
			case 4: // SAIR
					Application.Quit ();
					break;
			case 5: // ENTRAR NO JOGO
					Application.LoadLevel ("Loading");
					break;
			default:
					break;
		}
	}
	void OnGUI () {
		com = Screen.width* 2/3;
		alt = Screen.height / 12;
		if (stats == 1) {
			// TELA DO MENU INICIAL
			com = Screen.width* 1/5;
			alt = Screen.height / 12;

			GUI.skin = LabelSkin;
			//GUI.Box (new Rect ((Screen.width - com) / 2, alt * 2, com, alt * 2), "Mansao do Deagelis");
			GUI.skin = ButtonOneSide;
			if ( GUI.Button (new Rect ((Screen.width - com - acrescimo[0]) , alt * 5, com + acrescimo[0], alt), new GUIContent ( "PLAY" , "PLAY")) )
				stats = 2;
			if ( GUI.Button (new Rect ((Screen.width - com - acrescimo[1]) , alt * 7, com + acrescimo[1], alt), new GUIContent ( "HOW TO PLAY" , "HOW TO PLAY")) )
				stats = 3;
			if ( GUI.Button (new Rect ((Screen.width - com - acrescimo[2]) , alt * 9, com + acrescimo[2], alt), new GUIContent ( "QUIT" , "QUIT")) )
				stats = 4;
			hover = GUI.tooltip;

		} else if (stats == 2) {
			// TELA DE SAVES

			GUI.skin = ButtonMultiSide;
			if ( GUI.Button (new Rect ((Screen.width - com) / 2, alt * 2, com/2, alt), new GUIContent (PlayerPrefs.GetString ("Personagem1"+"nome"), "ok")) )
			{
				PlayerPrefs.SetInt ("currentSave",1);
				nameChar = "";
			}
			if ( GUI.Button (new Rect ((Screen.width - com) / 2, alt * 4, com/2, alt), new GUIContent (PlayerPrefs.GetString ("Personagem2"+"nome"), "ok")) )
			{
				PlayerPrefs.SetInt ("currentSave",2);
				nameChar = "";
			}
			if ( GUI.Button (new Rect ((Screen.width - com) / 2, alt * 6, com/2, alt), new GUIContent (PlayerPrefs.GetString ("Personagem3"+"nome"), "ok")) )
			{
				PlayerPrefs.SetInt ("currentSave",3);
				nameChar = "";
			}
			if ( GUI.Button (new Rect ((Screen.width - com) / 2, alt * 9, com/2, alt), new GUIContent ("BACK", "ok")) )
			{
				PlayerPrefs.SetInt ("currentSave",0);
				nameChar = "";
				stats = 1;
			}

			// BOTAO START/CREATE FUNCAO

			if (currentSave >= 1)
			{
				if ( PlayerPrefs.GetInt (PlayerStatsController.CurrentSave()+"save") == 1 )
				{
					if (GUI.Button (new Rect ((Screen.width/2 + com/4), alt * 9, com/3, alt), new GUIContent ( "START" , "ok"))) {
						stats = 5;
					}
				} 
				else
				{

					//CRIAR SAVE
					string nameChar2 = GUI.TextField ( new Rect ((Screen.width/2 + com / 4), alt * 2, com/3, alt*2), nameChar);
					nameChar = nameChar2;
					if (GUI.Button (new Rect ((Screen.width/2 + com/4), alt * 9, com/3, alt), new GUIContent ( "CREATE" , "ok"))) {
						if (nameChar != "") {
							PlayerPrefs.SetInt(PlayerStatsController.CurrentSave ()+"save", 1);
							PlayerPrefs.SetString (PlayerStatsController.CurrentSave ()+"nome",nameChar);
							PlayerPrefs.SetInt (PlayerStatsController.CurrentSave ()+"progresso",0);
						}
					}

				}
				if (GUI.Button (new Rect ((Screen.width/2 + com/4), alt * 10, com/3, alt), new GUIContent ( "DELET" , "ok"))) {
					PlayerPrefs.SetInt(PlayerStatsController.CurrentSave ()+"save", 0);
					PlayerPrefs.SetString (PlayerStatsController.CurrentSave ()+"nome", "Empty");
					PlayerStatsController.ResetScore(PlayerStatsController.CurrentSave());
					nameChar="";
				}

			}
		} else if (stats == 3)
		{
			GUI.skin = ButtonMultiSide;
			if ( GUI.Button (new Rect ((Screen.width - com) / 2, alt * 10, com/2, alt), new GUIContent ("BACK", "ok")) )
			{
				PlayerPrefs.SetInt ("currentSave",0);
				transform.position = new Vector3 (0,0,2);
				stats = 1;
			}
		}
	}// fim OnGUI
}
