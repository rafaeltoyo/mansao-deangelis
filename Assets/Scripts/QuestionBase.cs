using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/*
[System.Serializable]
public class Question{
	public string pergunta;
	public string[] opcoes;
	public int resposta;
}
*/
[System.Serializable]
public class QuestionBase  {
	public string pergunta;
	public string[] opcoes = new string[5];
	public int resposta;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	// Criar pergunta
	public void SetQuestion (string question, string option1, string option2, string option3, string option4, string option5, int answer) {
		pergunta = question;
		opcoes[0] = option1;
		opcoes[1] = option2;
		opcoes[2] = option3;
		opcoes[3] = option4;
		opcoes[4] = option5;
		resposta = answer;
	}
	// Vereficador de resposta
	public bool CheckAnswer (int answer) {
		if (answer == resposta)
						return true;
		return false;
	}
}
