using UnityEngine;
using System.Collections;

public class DoorBehaviour : MonoBehaviour {

	public Animator anim;
	public GUISkin text;
	[SerializeField]
	int numberStage, score, numberKey;
	// 0 a 9 portas de entrada nos estagios / 10 eh porta padrao (saida dos estagios)
	bool inportal ;
	bool error;

	// Use this for initialization
	void Start () {
		inportal = false;

	}
	void Awake () {
		anim = GetComponent<Animator>();
	}
	// Update is called once per frame
	void Update () {
		if (numberKey <= PlayerStatsController.GetTotalScore ())
			anim.SetBool ("Locked", false);
		else
			anim.SetBool ("Locked", true);

		if (numberKey <= PlayerStatsController.GetTotalScore ())
						error = false;
				else
						error = true;
		if( ( Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) ) && inportal ) {
			if ( numberKey <= PlayerStatsController.GetTotalScore() )
				StartCoroutine(EnterInPortal());
			//else
			//	StartCoroutine(ErrorMsg());
		}
	}
	void OnGUI () {	
		//Controle de tela (mostrar score da fase)
		GUI.skin = text;
		if ( inportal  && (CheckStage(numberStage) || numberStage == 11)  && !PlayerHudController.paused) {

			score = PlayerPrefs.GetInt (PlayerStatsController.CurrentSave()+numberStage+"score");
			if ( error )
				GUI.Box (new Rect ( (Screen.width-Screen.width*3/4 ) / 2, 0, Screen.width*3/4 , Screen.height / 12), "Door locked. ( You need "+numberKey+" points )" );
			else if ( score != 0 && !error )
				GUI.Box (new Rect ( (Screen.width-Screen.width*3/4 ) / 2, 0, Screen.width*3/4 , Screen.height / 12), "Score: "+score.ToString() );
			else if ( score == 0 && !error )
				GUI.Box (new Rect ( (Screen.width-Screen.width*3/4 ) / 2, 0, Screen.width*3/4 , Screen.height / 12), "Don't have score." );

		}
	}
	void OnTriggerStay2D (Collider2D alerta) {
		if (alerta.collider2D.tag == "Player") 
			inportal = true;
	}
	void OnTriggerExit2D (Collider2D alerta) {
		if (alerta.collider2D.tag == "Player") {
			inportal = false;
			error = false;
		}
	}
	public string GetStage (int number) {
		if (CheckStage(number))
			return "Sala "+number.ToString();
		if (number == 9)
			return "Corredor Boss";
		if (number == 10)
			return "Principal";
		if (number == 11)
			return "Sala Boss";
		return "Principal";
	}
	public bool CheckStage (int number) {
		if ( (number >=0 && number < 9) )
			return true;
		return false;
	}
	IEnumerator EnterInPortal () {
		PlayerControl.liberado = false;
		anim.SetBool ("Open", true);
		yield return new WaitForSeconds(1.0f);
		PlayerPrefs.SetInt (PlayerStatsController.CurrentSave()+"currentStage",numberStage);
		PlayerControl.liberado = true;
		anim.SetBool ("Open", false);
		Application.LoadLevel(GetStage(numberStage));
	}
	IEnumerator ErrorMsg () {
		error = true;
		yield return new WaitForSeconds(3.0f);
		error = false;
	}
}
