using UnityEngine;
using System.Collections;

public class SkyBehaviour : MonoBehaviour {
	public float speed; 
	Vector3 posiInicial;
	float cont;
	// Use this for initialization
	void Start () {
		cont = 0;
		posiInicial = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		cont = Time.deltaTime * speed;
		transform.position = new Vector3 (transform.position.x - cont, transform.position.y, 3);
	}
	void OnTriggerEnter2D (Collider2D alerta) {
		if (alerta.collider2D.tag == "Sky") 
						transform.position = posiInicial;
	}
}
