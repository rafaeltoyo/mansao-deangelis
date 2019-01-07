using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NpcTalk : MonoBehaviour {

	//Player
	public GameObject player;
	// Variaveis de armazenamento de texto do NPC ( Editavel pelo usuario )

	public string[] pergunta;
	public string[] questoes;
	public int opResposta;
	public string msgAcerto, msgErro;

	// Variaveis de controle de status ( escondidas no Inspector )
	[HideInInspector]
	public bool inrange, acertou;
	[HideInInspector]
	public int i,f, controlStats;
	/* 
		controlStats
		0- Nada
		1- Perguntando
		2- Questoes
		3- 
	 */
	// ---------------------------------------------------------------------------------------------------------------------------------------------------------
	void Start () {
		player = GameObject.Find("Character"); // Procura o Player
		// Definiçoes de reset em cada execuçao
		controlStats = 0;
		acertou = false;
		i = 0;
	}
	// ---------------------------------------------------------------------------------------------------------------------------------------------------------	
	// Update is called once per frame
	void Update () {
		// Controladora de Stats - Parte onde define a açao apos apertar o botao E
		if ( Input.GetKeyDown (KeyCode.E) && inrange) {
			switch ( controlStats ){
				case 0:
					controlStats = 1;
					break;
				case 1:
					i ++;
					break;
				case 2:
					
					break;
				case 3: // Editar !!!
					PlayerControl.ChangePlayerStats(true);
					controlStats = 0; // PS: MODIFICAR DEPOIS
											// Caso seja certa a resposta, alterar o Level(Codigo necessita fases prontas), se nao permanecer nesse (Codigo atual).
					break;
				default:
					controlStats = 0;
					break;
			}
		}
		// Quando terminar as frases da pergunta, acionar as respostas
		if (pergunta.Length <= i) {
			controlStats = 2;
			i = 0;
		}

		// Resetador de stats apos sair do range do NPC
		if (!inrange)
			controlStats = 0;
	
	}//fim Update
	// ---------------------------------------------------------------------------------------------------------------------------------------------------------
	void OnGUI () {
		// Controladora de stats - Parte de controle dos baloes que aparecerao em tela
		if (inrange) {
		if ( controlStats == 0 )
			GUI.Box (new Rect (Screen.width / 2 - 100, Screen.height / 12, 200, 50), "aperte E");
		if ( controlStats == 1 )
			GUI.Box (new Rect (0, 0, Screen.width, Screen.height / 4), pergunta [i]);
		if ( controlStats == 2 ) {
			for (f = 0; f <= questoes.Length; f++) {
				float altura = 0 + f * Screen.height / 12;
				float largura = Screen.width /2;
				if ( GUI.Button (new Rect (Screen.width/2 - largura/2, altura, largura, Screen.height / 12), questoes [f])) {
					if ( f == opResposta ) {
						acertou = true;
						controlStats = 3;
					} else {
						acertou = false;
						controlStats = 3;
					}
				}
			}
		}
		if ( controlStats == 3 ) {
			if ( acertou )
				GUI.Box (new Rect (Screen.width / 2 - 100, Screen.height / 12, 200, 50), msgAcerto);
			else if ( !acertou )
				GUI.Box (new Rect (Screen.width / 2 - 100, Screen.height / 12, 200, 50), msgErro);
		}
		
	}
	}// fim OnGUI
	// ---------------------------------------------------------------------------------------------------------------------------------------------------------
	// Parte de controle da posiçao de Player em relaçao ao NPC
	void OnTriggerStay2D (Collider2D alerta) {
		if (alerta.collider2D.tag == "Player") 
			inrange = true;
	}
	void OnTriggerExit2D (Collider2D alerta) {
		if (alerta.collider2D.tag == "Player") {
			inrange = false;
			i = 0;
		}
	}
	// ---------------------------------------------------------------------------------------------------------------------------------------------------------
}
