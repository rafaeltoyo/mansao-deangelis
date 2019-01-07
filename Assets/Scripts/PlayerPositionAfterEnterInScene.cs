using UnityEngine;
using System.Collections;

public class PlayerPositionAfterEnterInScene : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("Character");
		player.transform.position = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
