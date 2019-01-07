using UnityEngine;
using System.Collections;

public class PlataformBehaviour : MonoBehaviour {
	[SerializeField] bool collisionP;
	[SerializeField] BoxCollider2D colliderX;
	// Use this for initialization
	void Start () {
		colliderX.isTrigger = true;
		collisionP = false;
		gameObject.layer = 11;
	}

	void Awake () {
		colliderX = GetComponent<BoxCollider2D>();
	}
	// Update is called once per frame
	void Update () {
		/*
		if (trigger)
			colliderX.isTrigger = true;
		else if (!trigger)
			colliderX.isTrigger = false;
		*/

		if (!colliderX.isTrigger && collisionP) {
		
			if ( Input.GetKey (KeyCode.DownArrow) ) {
				DesativarPlataforma ();
			}

		}

	}
	void OnTriggerEnter2D (Collider2D alerta) {
		if (alerta.collider2D.tag == "Checker") {
			AtivarPlataforma ();
			collisionP = true;
		}
	}
	void OnTriggerExit2D (Collider2D alerta) {
		if (alerta.collider2D.tag == "Checker") {
			DesativarPlataforma ();
			collisionP = false;
		}
		if (alerta.collider2D.tag == "Player") {
			DesativarPlataforma ();
			collisionP = false;
		}
	}

	void AtivarPlataforma () {
		colliderX.isTrigger = false;
		gameObject.layer = 10;
	}
	void DesativarPlataforma () {
		colliderX.isTrigger = true;
		gameObject.layer = 11;
	}

}
