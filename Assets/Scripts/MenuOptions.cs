using UnityEngine;
using System.Collections;

public class MenuOptions : MonoBehaviour {

	public float posx;
	public float posxSave;
	public float posy;
	public float Lar;
	public float Alt;
	public GUISkin button;
	public GUISkin text;
	public int option;
	public string nameChar;
	public string currentSave;
	public AudioClip menu;
	public string hover;
	//memoria Save
	public int save;
	public int saveNow;
	public bool veref;
	// Use this for initialization
	void Start () {
		if (PlayerPrefs.GetString ("Personagem1"+"nome") == "")
			PlayerPrefs.SetString ("Personagem1"+"nome", "Empty");
		if (PlayerPrefs.GetString ("Personagem2"+"nome") == "")
			PlayerPrefs.SetString ("Personagem2"+"nome", "Empty");
		if (PlayerPrefs.GetString ("Personagem3"+"nome") == "")
			PlayerPrefs.SetString ("Personagem3"+"nome", "Empty");
		option = 1;
		saveNow = PlayerPrefs.GetInt ("currentSave");
		veref = false;
	}
	
	// Update is called once per frame
	void Update () {
		Lar = Screen.width / 2;
		Alt = Screen.height / 10;
		posx = Screen.width / 2 - Lar/2;
		posy = Screen.height / 10;
		posxSave = Screen.width / 6;
		currentSave = PlayerStatsController.GetSave();
		save = PlayerPrefs.GetInt(PlayerStatsController.CurrentSave ()+"Save");
		if (hover != "") {
			onhover = true;
		} else if (hover == "") {
			onhover = false;
			played = false;
		}
		if (onhover && !played) {
			AudioSource.PlayClipAtPoint (menu, transform.position);
			played = true;
		}
	}
	void OnGUI () {
				if (option == 1) {//Tela Inicial
						GUI.skin = button;
						if (GUI.Button (new Rect (posx, posy * 4, Lar, Alt), new GUIContent ( "PLAY" , "ok"))) {
								option = 3;
						}
						if (GUI.Button (new Rect (posx, posy * 6, Lar, Alt), new GUIContent ( "CREDITS" , "ok"))) {
								option = 2;
						}
						if (GUI.Button (new Rect (posx, posy * 8, Lar, Alt), new GUIContent ( "EXIT" , "ok"))) {
								Application.Quit ();
						}
				}
				if (option == 2) { // creditos
						GUI.skin = button;
						if (GUI.Button (new Rect (posx, posy * 8, Lar/2, Alt), new GUIContent ( "BACK" , "ok"))) {
								option = 1;
						}
				}
				if (option == 3) { // Tela dos saves
						GUI.skin = button;
						if (GUI.Button (new Rect (posxSave, posy * 2, Lar/2, Alt), new GUIContent (PlayerPrefs.GetString ("Personagem1"+"nome"), "ok"))) {
								PlayerPrefs.SetInt("currentSave", 1);
								saveNow = PlayerPrefs.GetInt("currentSave");
								veref = true;
								nameChar = "";
						}
						if (GUI.Button (new Rect (posxSave, posy * 4, Lar/2, Alt), new GUIContent (PlayerPrefs.GetString ("Personagem2"+"nome"), "ok"))) {
								PlayerPrefs.SetInt("currentSave", 2);
								saveNow = PlayerPrefs.GetInt("currentSave");
								veref = true;
								nameChar = "";
						}
						if (GUI.Button (new Rect (posxSave, posy * 6, Lar/2, Alt), new GUIContent (PlayerPrefs.GetString ("Personagem3"+"nome"), "ok"))) {
								PlayerPrefs.SetInt("currentSave", 3);
								saveNow = PlayerPrefs.GetInt("currentSave");
								veref = true;
								nameChar = "";

						}
						//Vereficador se ha dados no Save
						if (veref) {
						if ( saveNow == 1 && save == 1) {
						if (GUI.Button (new Rect (posxSave + Lar, posy * 6, Lar/2, Alt), new GUIContent ( "START" , "ok"))) {
								Application.LoadLevel ("Stage 1");
						} }
						else if ( saveNow == 2 && save == 1) {
						if (GUI.Button (new Rect (posxSave + Lar, posy * 6, Lar/2, Alt), new GUIContent ( "START" , "ok"))) {
								Application.LoadLevel ("Stage 1");
						} }
						else if ( saveNow == 3 && save == 1) {
						if (GUI.Button (new Rect (posxSave + Lar, posy * 6, Lar/2, Alt), new GUIContent ( "START" , "ok"))) {
								Application.LoadLevel ("Stage 1");
						} } else {
						GUI.skin = text;
						string nameChar2 = GUI.TextField ( new Rect (posxSave+Lar, posy * 2, Lar/2, Alt), nameChar);
						nameChar = nameChar2;
						
						GUI.skin = button;
						if (GUI.Button (new Rect (posxSave + Lar, posy * 6, Lar/2, Alt), new GUIContent ( "CREATE" , "ok"))) {
						if (nameChar != "") {
							PlayerPrefs.SetInt(PlayerStatsController.CurrentSave ()+"newChar", 1);
							PlayerPrefs.SetInt(PlayerStatsController.CurrentSave ()+"Save", 1);
							PlayerPrefs.SetString (currentSave+"nome",nameChar);
						} 
				
						} }
						
						if (GUI.Button (new Rect (posxSave + Lar, posy * 8, Lar/2, Alt), new GUIContent ( "DELET" , "ok"))) {
						PlayerPrefs.SetInt(PlayerStatsController.CurrentSave ()+"Save", 0);
					 	PlayerPrefs.SetString (currentSave+"nome", "Empty");
						nameChar="";
						}
						}
						
						if (GUI.Button (new Rect (posxSave, posy * 8, Lar/2 , Alt), new GUIContent ( "BACK" , "ok"))) {
								option = 1;
								veref = false;
						}
		}
		if (option == 4) {
		}
			
		hover = GUI.tooltip;


	}
	// controla som menu
	public bool onhover = false;
	public bool played = false;
}
