using UnityEngine;
using System.Collections;

public class ConeTremendo : MonoBehaviour {
	public float posxi, posyi, posxf, posyf;
	// Use this for initialization
	void Start () {
		posxi = transform.position.x;
		posyi = transform.position.y;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		posxf = posxi + Random.Range (-0.05f, 0.05f);
		posyf = posyi + Random.Range (-0.05f, 0.05f);
		transform.position = new Vector3 (posxf, posyf, transform.position.z);
	}
}
