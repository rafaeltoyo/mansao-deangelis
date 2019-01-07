using UnityEngine;
using System.Collections;

public class DoorEaterEggBehaviour : MonoBehaviour {

	public Animator anim;

	// 0 a 9 portas de entrada nos estagios / 10 eh porta padrao (saida dos estagios)
	bool inportal ;
	bool error;
	
	// Use this for initialization
	void Start () {
		inportal = false;
		error = true;
	}
	void Awake () {
		anim = GetComponent<Animator>();
	}
	// Update is called once per frame
	void Update () {
		if( Input.GetKeyDown(KeyCode.UpArrow) && inportal && error)
				StartCoroutine(EnterInPortal());

	}
		void OnTriggerStay2D (Collider2D alerta) {
		if (alerta.collider2D.tag == "Player") 
			inportal = true;
	}
	void OnTriggerExit2D (Collider2D alerta) {
		if (alerta.collider2D.tag == "Player") {
			inportal = false;
			error = true;
		}
	}

	IEnumerator EnterInPortal () {
		anim.SetBool ("Open", true);
		error = false;
		yield return new WaitForSeconds(1.0f);
		anim.SetBool ("Open", false);
		error = true;
	}
}

