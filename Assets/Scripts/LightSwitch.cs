using UnityEngine;
using System.Collections;

public class LightSwitch : MonoBehaviour {
	public bool lightswitch, inrange, canChange;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (!lightswitch)
			light.intensity = 0;
		else if (lightswitch)
			light.intensity = Random.Range (0.35f, 0.45f);


		canChange = PlayerControl.liberado;
		if (Input.GetKeyDown (KeyCode.E) && inrange && canChange)
			lightswitch = !lightswitch;
	}


	void OnTriggerStay2D (Collider2D alerta) {
		if (alerta.collider2D.tag == "Player") {
			inrange = true;
		}
	}
	void OnTriggerExit2D (Collider2D alerta) {
		if (alerta.collider2D.tag == "Player") {
			inrange = false;
		}
	}
}
