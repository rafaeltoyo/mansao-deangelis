using UnityEngine;
using System.Collections;

public class NPCBehaviour : MonoBehaviour {

	// Inteiros
	public int numberLifeNPC;
	public int numberLifePlayer;


	private int statsController /* Controle de estado */, 
		questionNumber /* Salva a questao atual que esta sendo feita */,
		score /* Contador de acertos */,
		maxQuestions /* Controla perguntas a serem puxadas */,
		numberLifePlayerMemory /* Memoria do max score da fase */,
		numberLifeNPCMemory /* Memoria do max score da fase */;
	// Booleanos
	private bool playerAlert /* Vereficador de alerta de colisao com player */, 
		havequestions /* Vereficador de se foi feito o loading das questoes */, 
		finished /* Verefica se todas questoes foram feitas */;
	// Skins para uso na funcao OnGUI
	public GUISkin textBox;
	// Banco de questoes do NPC
	//public QuestionBase[] pergunta = new QuestionBase[numberLifeNPC];
	private QuestionBase pergunta1 = new QuestionBase ();
	private int[] questionMemory = new int[QuestionNPC.intance1.pergunta.Length];

	// Use this for initialization
	void Start () {
		// Stats iniciais --------------------------------------------------------------------------------------------------------------------
		havequestions = false;
		questionNumber = 0;
		statsController = 0;
		score = 0;
		finished = false;
		numberLifePlayerMemory = numberLifePlayer;
		numberLifeNPCMemory = numberLifeNPC;

		for (int y = 0; y < questionMemory.Length; y++)
						questionMemory [y] = 0;
	}
	
	// Update is called once per frame
	void Update () {
		// Loading de perguntas sortidas ----------------------------------------------------------------------------------------------
		/* 
		if (!havequestions) {
			for (int x = 0; x <= numberLifeNPC; x++) {
				pergunta[x] = QuestionNPC.intance1.pergunta[Random.Range(0,6)];
			}
			havequestions = true;
		}
		*/
		// Prints de teste -----------------------------------------------------------------------------------------------------------------
		/*
		print (pergunta [0].pergunta);
		print (pergunta [1].pergunta);
		print (pergunta [2].pergunta);
		print ("teste");
		*/
		// Resetador de stats ------------------------------------------------------------------------------------------------------------
		if (!playerAlert)
			statsController = 0;
		// Detector de inicio da bateria de perguntas -------------------------------------------------------------------------------
		if (playerAlert && !finished && statsController == 0)
			statsController = 1;
		// Detector de teclas ------------------------------------------------------------------------------------------------------------
		if ( Input.GetKeyDown (KeyCode.E) && playerAlert ) {
			if ( statsController == 1 ) // Passar para as opcoes
				statsController = 2;
			if ( statsController == 3 && !finished ) { // Passar para a proxima pergunta
				statsController = 1;
				questionNumber ++;
			} else if ( statsController == 3 && finished ) { // Sair das perguntas
				statsController = 0;
				PlayerControl.ChangePlayerStats (true);
			}
		}

		//Maquina de Stats (Controladora de estado) -------------------------------------------------------------------------------
		// 1- PERGUNTA
		// 2- OPCOES
		// 3- CONTADOR DE PERGUNTAS REALIZADAS
		// 4- RESETAR PERGUNTA
		// 0- FORA DE ATIVIDADE
		switch (statsController) {
		case 1:
			PlayerControl.ChangePlayerStats (false); // Desabilita o personagem
			if ( !havequestions )
				statsController = 4;
			break;
		case 2:
			break;
		case 3:
			if ( numberLifePlayer == 0 || numberLifeNPC == 0 ) {
				if ( numberLifeNPC == 0 )
					score = numberLifePlayer;
				finished = true;
				CheckRecord (score);
				break;
			}
				statsController = 4;
			break;
		case 4:
			//pergunta1 = QuestionNPC.intance1.pergunta[Random.Range(0,20)];
			int randomNumber;
			randomNumber = Random.Range (0, QuestionNPC.intance1.pergunta.Length);
			if ( GetQuestion(randomNumber) ) {
				pergunta1 = QuestionNPC.intance1.pergunta[randomNumber];
				havequestions = true;
				statsController = 1;
			}

			break;
		default:
			break;
		}



	}

	void OnGUI () {
		// Controle de tela (Pergunta e opcoes)
		GUI.skin = textBox;
		switch (statsController) {
		case 1:
			GUI.Label (new Rect (1, 1, Screen.width - 2, Screen.height / 12 * 2 - 2), "Acertos para vencer: "+(numberLifeNPCMemory-numberLifeNPC)+"/"+numberLifeNPCMemory+" // Chances: "+numberLifePlayer+"/"+numberLifePlayerMemory);

			break;
		case 2:
			GUI.Label (new Rect (1, 1, Screen.width - 2, Screen.height / 12 * 2 - 2) , pergunta1.pergunta);
			for (int f = 0; f <= 4; f++) {
				float altura = (2 + f) * Screen.height / 12 + 1;
				float largura = Screen.width * 3/4;
				GUI.Label (new Rect ((Screen.width - largura)/2 + 1, altura, largura - 2, Screen.height / 12 - 2), /*pergunta[questionNumber].opcoes[f]*/ pergunta1.opcoes[f] );
				if ( GUI.Button (new Rect ((Screen.width - largura)/2 + 1, altura, largura - 2, Screen.height / 12 - 2), "" )) {
					//if ( f == pergunta[questionNumber].resposta ) {
					if ( f == pergunta1.resposta ) {
						numberLifeNPC --;
						statsController = 3;
					} else {
						numberLifePlayer --;
						statsController = 3;
					}
				}
			}

			break;
		case 3:
			GUI.Box (new Rect (0, 0, Screen.width, Screen.height / 4), "Score: "+score+"/"+numberLifePlayerMemory);
			break;
		default:


			break;
		}
	
	} // Fim OnGUI e Controladora de Stats -----------------------------------------------------------------------------------------

	// Vereficador de colisao com Player ---------------------------------------------------------------------------------------------
	void OnTriggerStay2D (Collider2D alerta) {
		if (alerta.collider2D.tag == "Player") 
			playerAlert = true;
	}
	void OnTriggerExit2D (Collider2D alerta) {
		if (alerta.collider2D.tag == "Player") {
			playerAlert = false;
		}
	}
	// Vereficador de Recordes
	void CheckRecord (int score) {
		if ( score > PlayerStatsController.GetScore (PlayerPrefs.GetInt(PlayerStatsController.CurrentSave()+"currentStage")) )
			PlayerStatsController.SetScore(PlayerPrefs.GetInt(PlayerStatsController.CurrentSave()+"currentStage"), score);
	}
	bool GetQuestion (int randomNumber) {
		if ( questionMemory[randomNumber] == 0 ) {
			questionMemory[randomNumber] = 1;
			return true;
		}
		return false;
	}
}
