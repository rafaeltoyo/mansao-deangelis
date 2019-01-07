using UnityEngine;
using System.Collections;

public class PlayerHudController : MonoBehaviour {

	int alt, com;
	public GUISkin button, textArea;
	public static GameObject player,lvlcontrol;
	public static PlayerHudController intance;
	// Use this for initialization
	public static bool paused;


	void Start () {
		intance = this;
		DontDestroyOnLoad(gameObject);
		paused = false;
	}
	
	// Update is called once per frame
	void Update () {
		//Verefica quando o player for encontrado, evitando poder pausar o jogo nas telas de menu.
		if (player == null)
			player = GameObject.Find("Character");
			lvlcontrol = GameObject.Find("LevelController");
		// Começo do funcionamento do PAUSE -------------------------------------------------------------------------------------------
		if ( player != null ) {
		// Pausar o game
		if (paused)
						Time.timeScale = 0;
				else
						Time.timeScale = 1;
		// Tecla do Pause
		if (Input.GetKeyDown (KeyCode.Escape))
						paused = !paused;

		}// FINAL DO PAUSE -------------------------------------------------------------------------------------------------------------------
	}
	//TELA DE PAUSE --------------------------------------------------------------------------------------------------------------------------
	void OnGUI () {
		GUI.skin = button;



		if (paused) {
			com = Screen.width* 2/3;
			alt = Screen.height / 12;
			GUI.skin = textArea;
			GUI.Box (new Rect ((Screen.width - com) / 2, alt * 2, com, alt * 2), "PAUSE");
			GUI.skin = button;
			if ( GUI.Button (new Rect ((Screen.width - com) / 2, alt * 5, com, alt), new GUIContent ( "CONTINUE" , "ok")) )
				paused = false;
			if ( GUI.Button (new Rect ((Screen.width - com) / 2, alt * 7, com, alt), new GUIContent ( "BACK TO MENU" , "ok")) )
				BackMenu ();
			if ( GUI.Button (new Rect ((Screen.width - com) / 2, alt * 9, com, alt), new GUIContent ( "QUIT" , "ok")) )
				Application.Quit();

		
		}
		else if (!paused) {
			GUI.skin = textArea;
			com = Screen.width / 6;
			alt = Screen.height / 20;
			GUI.Box (new Rect (1, Screen.height - alt, com, alt), "Total points: "+PlayerStatsController.GetTotalScore ().ToString() );
			GUI.skin = button;
		}
	}
	public static void BackMenu () {
		DestroyObject(player);
		DestroyObject(lvlcontrol);
		Application.LoadLevel("Menu");
	}
	public static void DeleteControllers () {
		DestroyObject(player);
		DestroyObject(lvlcontrol);
	}

}
