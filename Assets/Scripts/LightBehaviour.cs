using UnityEngine;
using System.Collections;

public class LightBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		light.intensity = Random.Range (.75f, .9f);
	}
}
