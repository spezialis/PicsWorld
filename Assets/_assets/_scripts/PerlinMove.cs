using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinMove : MonoBehaviour {

	public float elapsedTime = 0f;
	public float perlinNoise = 0f;
	public float multiplayer = 0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		elapsedTime = Time.time; // amoun t of time passed since the app started
		perlinNoise = Mathf.PerlinNoise(elapsedTime, 0f);

//		transform.position = new Vector3 (transform.position.x, perlinNoise * multiplayer, transform.position.z);

		// Transform scale in Y
//		transform.localScale = new Vector3 (transform.localScale.x, perlinNoise * multiplayer, transform.localScale.z);

		// Transfor scale in Z
		transform.localScale = new Vector3 (transform.localScale.x, transform.localScale.y, perlinNoise * multiplayer);
	}
}
